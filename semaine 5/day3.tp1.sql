create or replace procedure p_calling is
begin
  insert into dept values (99,'dept 99', 'NY');
  p_callable();
  rollback;
end;

create or replace procedure p_callable is
pragma AUTONOMOUS_TRANSACTION;
begin
  insert into dept values (100,'dept 100', 'CHICAGO');
  commit;
end;