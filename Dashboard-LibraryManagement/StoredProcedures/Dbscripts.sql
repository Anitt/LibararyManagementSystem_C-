use CSCI5308_21_DEVINT ;
DELIMITER $$
Create PROCEDURE sproc_insert_userdetails(IN user_id int(11), IN firstName varchar(255) , IN LastName varchar(255) , IN Emailid varchar(255) , 
IN Userpassword varchar(255)  ,IN isadmin TINYINT(1))
BEGIN
    INSERT into User_Details(ID,First_Name,Last_Name,Email_id,`Password`,Is_admin)
    values (user_id,firstName,LastName,Emailid,Userpassword,isadmin);
END $$
DELIMITER ;

DELIMITER $$
Create PROCEDURE sproc__DeleteByUserID(IN user_id int(11))
BEGIN
   Delete from User_Details where ID = user_id;

END$$

DELIMITER ;
