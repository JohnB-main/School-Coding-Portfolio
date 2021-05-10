-- John Booker
-- CSC 585 Lab 1
-- Question 1
CREATE table Departments(
    Name VARCHAR2(15) primary key,
    managerID char(3) default null unique    
);


CREATE table Employees(
    ID char(3) primary key,
    Name VARCHAR2(25),
    Salary NUMBER(9,0),
    deptName VARCHAR2(15),
    constraint fk_Dept_Department foreign key (deptName) references Departments(Name) on delete set NULL
);



create trigger EID_managerID
After DELETE on Employees
referencing 
old as oldrow
FOR EACH ROW
begin
update Departments set managerID = NULL Where managerID=:oldrow.ID;
end;
/


create trigger HR_Salary
After insert on Employees
referencing 
new as newrow
for each row when (newrow.deptName = 'HR' AND newrow.Salary < 20000)
begin
delete from Employees Where ID=:newrow.ID AND Salary < :newrow.Salary;
end;
/

-- departments insertion
INSERT into Departments Values('HR', 666);
INSERT into Departments Values('RD', 888);
INSERT into Departments Values('SALES', 222);

-- employees insertion
INSERT into Employees Values('123', 'John', 56000, 'RD');
INSERT into Employees Values('578', 'Robert', 37500, 'HR');
INSERT into Employees Values('666', 'Jenny', 46000, 'HR');
INSERT into Employees Values('222', 'Christ', 39000, 'SALES');
INSERT into Employees Values('888', 'Bill', 50000, 'RD');
INSERT into Employees Values('101', 'Susan', 67500, 'RD');

/*
--Testing 
delete from Employees WHERE ID = '222';
select * from departments;
delete from Departments WHERE Name = 'RD';
select * from employees;

--drop statemments for testing
drop table 	DEPARTMENTS	cascade constraints;
drop table 	EMPLOYEES	cascade constraints;
Select table_name from user_tables;

/*
Question 2
    The database will refuse the insert because the
    salary for an HR member must be >= 20000, but the inserted
    amount was 18000.
    
Question 3
    The database will delete the department touple and
    set the departmentName in employee's who worked in
    that department to NULL
    
Question 4
    Deleting the employee with ID 666, would result
    in the 666 touple to be deleted from the employee
    table and his/her managerID in the Departments table
    to become NULL.
 */