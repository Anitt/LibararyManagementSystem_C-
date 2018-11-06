DELIMITER $$
Create PROCEDURE sproc_insert_BookDetails(IN Bookid int(11), IN bookname varchar(255) , IN author varchar(255) , IN bookstatus varchar(255) , IN price int(11) ,
IN rackno INT(11)  ,IN noofbooks INT(11))
BEGIN
    INSERT into Book_Details(Book_id,`Name`,Author,`Status`,Price,Rack_No,No_of_books)
    values (Bookid,bookname,author,bookstatus,price,rackno,noofbooks);
END $$
DELIMITER ;


DELIMITER $$
Create PROCEDURE sproc__DeleteByBookID(IN Bookid int(11))
BEGIN
   Delete from Book_Details where Book_id = Book_id;

END$$
DELIMITER ;



DELIMITER $$
Create PROCEDURE sproc_getbooks()
BEGIN
   
   Select * from Book_Details ;
END$$
DELIMITER ;


DELIMITER $$
Create PROCEDURE sproc_getBooksById(IN Bookid int(11))
BEGIN
   
   Select * from Book_Details where Book_id = Book_id ;
END$$
DELIMITER ;


DELIMITER $$
Create PROCEDURE sproc_UpdateByBookID(IN Bookid int(11), IN bookname varchar(255) , IN author varchar(255) , IN bookstatus varchar(255) , 
IN price INT(30))
BEGIN
   update Book_Details set Name = bookname  , Author = author , Status = bookstatus , Price = price where Book_id = Bookid ;
   
END$$

DELIMITER ;





