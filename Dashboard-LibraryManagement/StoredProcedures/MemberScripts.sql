DELIMITER $$
Create PROCEDURE sproc_insert_memberdetails(IN memberid int(11), IN firstName varchar(255) , IN LastName varchar(255) , IN Emailid varchar(255) , 
IN Phoneno int(30)  ,IN Address VARCHAR(255) , IN dob Datetime)
BEGIN
    INSERT into Member_Details(Member_ID,First_Name,Last_Name,Email_id,Phone_no,Address)
    values (memberid,firstName,LastName,Emailid,Phoneno,Address);
END $$
DELIMITER ;


DELIMITER $$
Create PROCEDURE sproc__DeleteByMemberID(IN memberid int(11))
BEGIN
   Delete from Member_Details where Member_ID = memberid;

END$$
DELIMITER ;



DELIMITER $$
Create PROCEDURE sproc_UpdateByMemberID(IN memberid int(11), IN firstName varchar(255) , IN LastName varchar(255) , IN Emailid varchar(255) , 
IN Phoneno int(30)  ,IN address VARCHAR(255) , IN dob Datetime)
BEGIN
   update Member_Details set First_Name = firstName  , Last_Name = LastName , Email_id = Emailid , Phone_no = phoneno , Address = address , DOB = dob where Member_ID = memberid ;
   
END$$


DELIMITER $$
Create PROCEDURE sproc_getmembers()
BEGIN
   
   Select * from Member_Details ;
END$$
DELIMITER ;


DELIMITER $$
Create PROCEDURE sproc_getMemberById(IN memberid int(11))
BEGIN
   
   Select * from Member_Details where Member_ID = memberid ;
END$$
DELIMITER ;


