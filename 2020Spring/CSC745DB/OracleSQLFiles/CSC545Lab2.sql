-- John Booker
-- CSC 585 Lab 2
-- Question 1
CREATE table CourseDescription(
    cno CHAR(3) primary key,
    credits number(1),
    prerequisite char(3) default null 
);


CREATE table CoursesSpring2020(
    crn char(5) primary key,
    cno CHAR(3),
    seatCapacity number (3) default 24,
    seatTaken number (3),
    constraint fk_Spring_Description foreign key (cno) references CourseDescription(cno) on delete CASCADE
);



create trigger matching_seating
After insert on CoursesSpring2020
referencing 
new as newrow
for each row when (newrow.seatCapacity < newrow.seatTaken)
begin
delete from CoursesSpring2020 Where crn=:newrow.crn;
end;
/


create trigger prereq_Exists
BEFORE insert on CourseDescription
referencing 
new as newrow
for each row when (newrow.prerequisite IS NOT null)
begin
delete from CourseDescription Where :newrow.prerequisite NOT IN (select cno from CourseDescription);
end;
/


create trigger prereq_setnullOnDelete
Before DELETE on CourseDescription
referencing 
old as oldrow
FOR EACH ROW
begin
update CourseDescription set prerequisite = NULL Where prerequisite=:oldrow.cno;
end;
/



-- departments insertion
INSERT into CourseDescription Values('110', 1, null);
INSERT into CourseDescription Values('307', 3, null);
INSERT into CourseDescription Values('185', 3, null);
INSERT into CourseDescription Values('190', 3, '185');
INSERT into CourseDescription Values('191', 3, '190');
INSERT into CourseDescription Values('195', 3, '190');


-- values for CoursesSpring2020
INSERT into CoursesSpring2020 Values('11111', '190', 24, 7);
INSERT into CoursesSpring2020 Values('12222', '191', 24, 13);
INSERT into CoursesSpring2020 Values('13333', '110', 24, 10);
INSERT into CoursesSpring2020 Values('14444', '185', 24, 5);
INSERT into CoursesSpring2020 Values('15555', '190', 24, 2);

/*
--drop statemments for testing
drop table 	CourseDescription	cascade constraints;
drop table 	CoursesSpring2020	cascade constraints;
Select table_name from user_tables ;
*/

-- Question 2
select cno, credits 
from coursedescription 
WHERE prerequisite is not null;

-- Question 3
select count(*) as NumPreReqs
from coursedescription 
WHERE prerequisite is null;

--Question 4
select crn, cno, (seatcapacity-seattaken) as seatsAvail 
from CoursesSpring2020
where seattaken < seatcapacity;

--Question 5
select crn, cno, seatcapacity, seatTaken
from coursesspring2020
order by cno desc, seattaken asc
;
--Question 6
select cno, min(seatTaken) as LowestEnrolled
from coursesspring2020
group by cno
having cno='190'
;

