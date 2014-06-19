use AdministrationOfEmployees;
select e.name,e.firstname,e.chief,e2.name + ' ' + coalesce(e2.firstname,'') 'CHIEF'
from employees e
--inner join employees e2 on e.chief = e2.id ;
full outer join employees e2 on e.chief = e2.id ;

select COUNT(*)
from employees
where firstname <>'' or firstname is not null;

select e.id,e.name,e.firstname,count(e2.id)
from employees e
--inner join employees e2 on e.chief = e2.id ;
left outer join employees e2 on e.id = e2.chief
group by e.id,e.name,e.firstname,e2.chief;


select e.id,e.name,e.firstname,e.chief
from employees e
;
--CREATE VIEW
GO
drop view v_employees_IT;
GO
create view v_employees_IT as
(select top 100 e.id, e.name, e.firstname, e.dob, e.dateRecruit, e.service
from employees e where e.service = 'IT')
WITH CHECK OPTION
;
GO

select * from v_employees_IT;

select * from employees  where "service" = 'IT';


--TRANSACTION

--rollback

select e.*,'before'
from employees e
;

begin transaction deletion;

delete from employees;

select e.*,'wip'
from employees e
;

rollback transaction deletion;

select e.*,'after'
from employees e
;

select e.*,'before'
from employees e
;
--commit
begin transaction updating;

update employees set name = LOWER(name);

select e.*,'wip'
from employees e
;

commit transaction updating;

select e.*,'after'
from employees e
;
--saving

begin transaction insertion;
insert into employees values (NEWID(),'fadell3','tony3','22/03/1969' , '01/02/2001', null, 81000,null,null,null);
save transaction insertion;
select e.*,'saved'
from employees e
;
insert into employees values (NEWID(),'fadell2','tony2','22/03/1969' , '01/02/2001', null, 81000,null,null,null);
select e.*,'wip'
from employees e
;
rollback transaction insertion;
select e.*,'rolled back'
from employees e
;

commit transaction insertion;

delete from employees where name= 'fadell3'


--TEMPORARY TABLE
select * into #GreedyEmployee from employees where salary >25000;

select * from #GreedyEmployee;
--TABLE CTE


with CTE_chief(idchief,namechief,firstnamechief) as (select id,name,firstname from employees)
select name,firstname,namechief,firstnamechief from CTE_chief inner join employees on chief = idchief
;

--IDENTITY

create table tests(
	id numeric(9) identity(100,1) constraint pk_tests primary key
,	label varchar(80)
);
set identity_insert tests on;
insert into tests values('test 1');
select * from tests;

select @@IDENTITY;






