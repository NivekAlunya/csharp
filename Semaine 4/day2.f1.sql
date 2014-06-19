
/*
declare @id uniqueidentifier;
set @id = (select top 1 id from employees);
select @id;
*/
--insert into daysoff values((select top 1 employees.id from employees),2012,DEFAULT);
--insert into daysoff values(@id,2013,DEFAULT);
--insert into daysoff values(@id,2014,DEFAULT);

--insert into monthly_daysoff values(@id,2014,3,5);
--insert into monthly_daysoff values(@id,2014,5,3);
--insert into monthly_daysoff values(@id,2014,6,2);


use AdministrationOfEmployees;
delete from monthly_daysoff;
delete from daysoff;
delete from employees;
delete from services;

insert into services values('MANPW','manpower resources');
insert into services (code,label) values('IT','Info - Technology');
--alter table services alter column label varchar(80);
insert into services (code,label) values('MNGMT','Management');

insert into services 
values 
('ACNTC','accountancy'),
('PURDP','purchasing department'),
('TECHN','technical');

--update services set label = 'purchasing department' where code = 'PURDPT';

declare @id uniqueidentifier;
set @id = NEWID();

insert into employees values(NEWID(), 'JOBS','Steve','24/02/1955','01/01/1974',null,1.0,null,'MNGMT',null);

insert into employees values(@id,'IVES','JOHNNY','27/02/1967','01/01/1994',null,90000.0,null,'IT',null);
select @id;
insert into daysoff values
	(@id,2013,20),
	(@id,2014,DEFAULT);
insert into monthly_daysoff values
	(@id,2013,4,1),
	(@id,2013,8,10),
	(@id,2014,1,10);

delete from employees where name = 'COOK';
set @id = 'A0A23DD6-1628-4C7F-BABC-E7F949D7469A';
insert into employees values(@id,'COOK','TIM','27/02/1967','01/01/1997',null,999000.0,null,'PURDP',null);
select @id;
insert into daysoff values
	(@id,2011,20),
	(@id,2012,30),
	(@id,2013,30),
	(@id,2014,30);
insert into monthly_daysoff values
	(@id,2011,12,5),
	(@id,2012,1,5),
	(@id,2012,8,20),
	(@id,2012,12,5),
	(@id,2013,6,15),
	(@id,2013,7,15);
delete from employees where name = 'WOZNIAK';
set @id = 'A0A23DD6-1628-4C7F-BABC-E7F949D7469B';
insert into employees values(@id,'WOZNIAK',null,'27/12/1963','01/01/1989',null,250000.0,null,'MNGMT',null);
select @id;
insert into daysoff values
	(@id,2013,5),
	(@id,2014,25);
insert into monthly_daysoff values
	(@id,2013,12,5),
	(@id,2014,1,5);
delete from employees where name = 'MARKKULA';
set @id = 'A0A23DD6-1628-4C7F-BABC-E7F949D7469C';
insert into employees values(@id,'MARKKULA','MIKE','27/02/1967','01/01/1990',null,25000.0,null,'PURDP',null);
select @id;
insert into daysoff values
	(@id,2013,3),
	(@id,2014,default);
insert into monthly_daysoff values
	(@id,2013,12,2),
	(@id,2014,2,10);

update employees set firstname = LOWER(firstname);
update employees set editedAt = GETDATE();

update employees set chief= 'A0A23DD6-1628-4C7F-BABC-E7F949D7469C' where name in ('MARKKULA','IVES');

update employees set salary=salary*1.02 where salary*1.02<=1000000;

update employees set chief = (select id from employees where name = 'JOBS') where name in ('WOZNIAK','MARKKULA');
update employees set chief = (select id from employees where name = 'MARKKULA') where name ='COOK';
update employees set chief = (select id from employees where name = 'WOZNIAK') where name ='IVES';

update employees set chief = case name 
	when 'WOZNIAK' then (select id from employees where name = 'JOBS') 
	when 'MARKKULA' then (select id from employees where name = 'JOBS') 
	when 'COOK' then (select id from employees where name = 'MARKKULA') 
	when 'IVES' then (select id from employees where name = 'WOZNIAK') 
	end
;

select * from services;
select chief,* from employees;
select * from daysoff;
select * from monthly_daysoff;

