USE /* DB Name */
GO

Create Table Employees
(
 EmployeeID int IDENTITY PRIMARY KEY,
 Name nvarchar(50),
 Gender nvarchar(10),
 Salary int
) 

/* 
Script to insert sample data. 
Notice, that in the insert statement we are not providing a value for EmployeeID column.
*/

Insert into Employees values('Mike','Male',5000)
Insert into Employees values('Pam','Female',3500)
Insert into Employees values('John','Male',2350)
Insert into Employees values('Sara','Female',5700)
Insert into Employees values('Steve','Male',4890)
Insert into Employees values('Sana','Female',4500)


/*
The stored procedure has got only 2 lines of code with in the body. 
The first line inserts a row into the Employees table. 
The second line, gets the auto generated identity value of the EmployeeID column.
*/
CREATE PROCEDURE sp_AddEmployee  
@Name nvarchar(50),  
@Gender nvarchar(20),  
@Salary int,  
@EmployeeID int Out  
AS  
BEGIN  
 INSERT INTO Employees VALUES(@Name, @Gender, @Salary)  
 SELECT @EmployeeID = SCOPE_IDENTITY()  
END