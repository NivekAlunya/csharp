declare
  CURSOR c_emp is select * from emp;
begin

  for i in c_emp loop
    DBMS_OUTPUT.PUT_LINE(i.ename||' '||i.job);
  end loop;

end;

declare
  CURSOR c_emp is select ename from emp where job = 'MANAGER';
  CURSOR c_emp2(metier emp.job%type) is select ename from emp where job = metier;
  v_emp emp.ename%type;
begin
  open c_emp;
  loop
    fetch c_emp into v_emp;
    exit when c_emp%NOTFOUND;
    SYS.DBMS_OUTPUT.PUT_LINE(v_emp);
  end loop;
  DBMS_OUTPUT.put_line(c_emp%rowcount);
  close c_emp;

  open c_emp2('MANAGER');
  loop
    fetch c_emp2 into v_emp;
    exit when c_emp2%NOTFOUND;
    SYS.DBMS_OUTPUT.PUT_LINE(v_emp);
  end loop;
  DBMS_OUTPUT.put_line(c_emp2%rowcount);
  close c_emp2;

end;
