create or replace procedure countEmployees(nodpt number) is
  v_cnt integer:=0;
  v_nodpt number(10);
begin
  select dept.deptno into v_nodpt from dept where dept.deptno = nodpt;
  select count(*) into v_cnt from emp where emp.deptno = nodpt;
  dbms_output.put_line('number of employees for department '||nodpt||' is '||v_cnt);
  exception
    when no_data_found then dbms_output.put_line('deptno not found');
    when others then dbms_output.put_line(sqlcode||'><'||sqlerrm);
end;

--select * from dept;
execute COUNTEMPLOYEES(10);