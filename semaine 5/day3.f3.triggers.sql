create table "archive"
(
  code number,
  salary number,
  updateAt date
);

create trigger tr_salary
after update of sal on emp for each row
declare
begin
  insert into "archive" values (:old.empno,:old.sal,sysdate);
end;


update emp set sal = sal*1.05;

select * from "archive";

alter table dept add cnt integer;

update dept d set d.cnt = (select count(*) from emp where emp.deptno = d.deptno);

commit;

create or replace trigger tr_updatecount_emp_in_dept
after insert or delete or update of deptno
on emp
for each row
begin
  if(inserting or updating) then
      update dept set cnt = cnt + 1 where deptno=:new.deptno;
  end if;
  if(deleting or updating) then
      update dept set cnt = cnt - 1 where deptno=:old.deptno;
  end if;
end;
show errors;


insert into emp values(8000,'LAUNAY','JOB',7902,sysdate,8000,0,40);
update emp set deptno=40 where empno = 7839;
delete from emp where ename='LAUNAY';

select * from dept;

rollback;