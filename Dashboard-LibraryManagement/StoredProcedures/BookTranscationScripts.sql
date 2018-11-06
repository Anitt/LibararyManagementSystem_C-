use CSCI5308_21_DEVINT ;
DELIMITER $$
Create PROCEDURE sproc_insert_BookTransactiondetails(IN transactionid int(11), IN memberid INT(11) , IN Bookid INT(11) , IN dateofissue DATETIME , 
IN duedate DATETIME  ,IN bookstatus TINYINT(1))
BEGIN
    INSERT into Book_Transcation(Transcation_ID,Member_ID,Book_ID,Date_of_issue,Due_Date,BookStatus)
    values (transactionid,memberid,Bookid,dateofissue,duedate,bookstatus);
END $$
DELIMITER ;


DELIMITER $$
Create PROCEDURE sproc__DeleteByTransactionID(IN transactionid int(11))
BEGIN
   Delete from Book_Transcation where Transcation_ID = transactionid;

END$$
DELIMITER ;


DELIMITER $$
Create PROCEDURE sproc_gettranscation()
BEGIN
   
   Select * from Book_Transcation ;
   
END$$
DELIMITER ;




DELIMITER $$
Create PROCEDURE sproc_getBookTransactionById(IN transactionid int(11))
BEGIN
   
   Select * from Book_Transcation where Transcation_ID = transactionid ;
END$$
DELIMITER ;



DELIMITER $$
Create PROCEDURE sproc_getBookTransactionByBookId(IN bookid int(11))
BEGIN
   
   Select * from Book_Transcation where Book_ID = bookid ;
   
END$$
DELIMITER ;


DELIMITER $$
Create PROCEDURE sproc_getBookTransactionByBookId(IN bookid int(11))
BEGIN
   
   Select * from Book_Transcation where Book_ID = bookid ;
   
END$$
DELIMITER ;


DELIMITER $$
Create PROCEDURE sproc_UpdateTransaction(IN transactionid int(11), IN memberid INT(11) , IN Bookid INT(11) , IN dateofissue DATETIME , 
IN duedate DATETIME  ,IN bookstatus TINYINT(1))
BEGIN
   update Book_Transcation set Member_ID = memberid  , BOOK_ID = Bookid , Date_of_issue = dateofissue , Due_Date = duedate , BookStatus = bookstatus where Transcation_ID = transactionid ;
   
END$$








