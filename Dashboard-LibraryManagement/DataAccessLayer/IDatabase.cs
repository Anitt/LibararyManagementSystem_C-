using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_LibraryManagement.DataAccessLayer
{
    public interface IDatabase
    {
        int Execute(string commandText, Dictionary<string, object> parameters);
        object QueryValue(string commandText, Dictionary<string, object> parameters);
        List<Dictionary<string, string>> Query(string commandText, Dictionary<string, object> parameters);
        
        void EnsureConnectionClosed();
        
        string GetStrValue(string commandText, Dictionary<string, object> parameters);


    }
}
