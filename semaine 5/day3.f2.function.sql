create or replace function get_salary(p_name varchar2) return emp.sal%type is
v_sal emp.sal%type;
begin
  select emp.sal into v_sal from emp where ename = p_name;
  return v_sal;
  exception
    when others then 
    raise_application_error(-20001,'no salary cause no employee...');
      return 0;
end;

select GET_SALARY('K') from dual;