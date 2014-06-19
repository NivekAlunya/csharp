use AdministrationOfEmployees;


--alter table employees alter column "service" char(5) null ;
--insert into employees values(NEWID(),'SCOTT','','1/1/1990','1/1/2010',null,80000,null,null,null);


select s.code,s.label,e.*
from employees e
full outer join services s on s.code = e.service

select s.code,s.label,e.*
from employees e
left outer join services s on s.code = e.service

select s.code,s.label,e.*
from employees e
right outer join services s on s.code = e.service