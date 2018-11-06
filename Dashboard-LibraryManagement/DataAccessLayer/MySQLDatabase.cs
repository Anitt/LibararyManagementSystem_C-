using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading;
using Dashboard_LibraryManagement.DataAccessLayer;

namespace Dashboard_LibraryManagement.Models
{
  
    public class MySQLDatabase : IDisposable, IDatabase
    {
        private MySqlConnection _connection;
        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MySQLDatabase()
            : this("DefaultConnection")
        {


        }

        public MySQLDatabase(string connectionStringName)
        {
            try
            {
                if (_connection == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                    _connection = new MySqlConnection(connectionString);
                    log.Info("Creating MySql Connection object.");
                }
            }
            catch (MySqlException ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int Execute(string commandText, Dictionary<string, object> parameters)
        {
            int result = 0;

            if (String.IsNullOrEmpty(commandText))
            {
                throw new ArgumentException("Command text cannot be null or empty.");
            }

            try
            {
                EnsureConnectionOpen();
                var command = CreateCommand(commandText, parameters);
                result = command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                EnsureConnectionClosed();
            }

            return result;
        }
        public object QueryValue(string commandText, Dictionary<string, object> parameters)
        {
            object result = null;

            if (String.IsNullOrEmpty(commandText))
            {
                throw new ArgumentException("Command text cannot be null or empty.");
            }

            try
            {
                EnsureConnectionOpen();
                var command = CreateCommand(commandText, parameters);
                result = command.ExecuteScalar();
            }
            catch (MySqlException ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                EnsureConnectionClosed();
            }

            return result;
        }

        public List<Dictionary<string, string>> Query(string commandText, Dictionary<string, object> parameters)
        {
            List<Dictionary<string, string>> rows = null;
            if (String.IsNullOrEmpty(commandText))
            {
                throw new ArgumentException("Command text cannot be null or empty.");
            }

            try
            {
                EnsureConnectionOpen();
                var command = CreateCommand(commandText, parameters);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    rows = new List<Dictionary<string, string>>();
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, string>();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var columnName = reader.GetName(i);
                            var columnValue = reader.IsDBNull(i) ? null : reader.GetString(i);
                            row.Add(columnName, columnValue);
                        }
                        rows.Add(row);
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                EnsureConnectionClosed();
            }

            return rows;
        }

        private void EnsureConnectionOpen()
        {
            try
            {
                var retries = 3;
                if (_connection.State == ConnectionState.Open)
                {
                    return;
                }
                else
                {
                    while (retries >= 0 && _connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                        log.Info("Opening new My SQL Connection instance ");
                        retries--;
                        Thread.Sleep(30);
                    }
                }
            }
            catch (MySqlException ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void EnsureConnectionClosed()
        {
            try
            {
                if (_connection == null) return;
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                    log.Info("Closing My SQL Connection instance");
                }
            }
            catch (MySqlException ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private MySqlCommand CreateCommand(string commandText, Dictionary<string, object> parameters)
        {
            try
            {
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = commandText;
                AddParameters(command, parameters);

                return command;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private static void AddParameters(MySqlCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                return;
            }

            foreach (var param in parameters)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = param.Key;
                parameter.Value = param.Value ?? DBNull.Value;
                command.Parameters.Add(parameter);
            }
        }
        public string GetStrValue(string commandText, Dictionary<string, object> parameters)
        {
            string value = QueryValue(commandText, parameters) as string;
            return value;
        }

        public void Dispose()
        {
            try
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }

            catch (MySqlException ex)
            {

                throw new DatabaseException(ex.Message, ex);
            }
            catch (Exception)
            {
                throw;

            }

        }
    }
}
