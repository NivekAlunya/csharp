create table test(
  nom varchar2(5)
);

declare
  too_long exception;
  pragma exception_init(too_long,-12899);
begin
  insert into test values('MARTIN');
  exception 
    when too_long then
      dbms_output.put_line('value is too long....');
    when others then
      dbms_output.put_line(sqlcode);
end;

declare
  v_nb integer;
  too_much exception;
--pragma exception_init(too_much,-12899);
begin

  select count(*) into v_nb from EMP;
  if(v_nb >10) then
    raise too_much;
  end if;
  dbms_output.put_line(v_nb||' employees');
  exception 
    when too_much then
      dbms_output.put_line('too much employees....');
    when others then
      dbms_output.put_line(sqlcode);
end;


declare 
v_diff emp.sal%type;
v_salupgrade integer :=20;
salary_overflow exception ;
begin
  
  select e1.sal - (e2.sal + v_salupgrade) into v_diff 
  from emp e1 , emp e2
  where e1.ename='KING' and e2.ename = 'JONES';
  
  dbms_output.put_line(v_diff);
  
  if v_diff < 0 then
    raise salary_overflow;
  end if;

  update emp set sal = sal + v_salupgrade where ename = 'JONES' returning sal into v_salupgrade;
  commit;
  
  dbms_output.put_line('new salary : '||v_salupgrade);
  
  exception
    when salary_overflow then
      dbms_output.put_line('salary overflow...');
    when others then
      dbms_output.put_line(sqlcode||'>>'||sqlerrm);
  
end;
