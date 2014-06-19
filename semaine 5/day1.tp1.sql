/*
declare
v_emp emp%rowtype;
v_empupdated emp%rowtype;
begin

select * into v_emp from emp where ename='JONES';
update emp set sal = sal *2 where ename= 'JONES' returning sal into v_empupdated.sal;
--select * into v_empupdated from emp where ename='JONES';
commit;
SYS.DBMS_OUTPUT.PUT_LINE(v_emp.sal||'=>'||v_empupdated.sal);

end;

*/

declare 
x integer;
begin
  x:=10;
  declare
    x integer;
    y integer;
  begin
    x:=20;
    y:=x;
    SYS.DBMS_OUTPUT.PUT_LINE(x);
    
    --IF conditions THEN
    --ELSIF conditions
    --ELSE
    --END IF;
    
--    CASE
--    WHEN condition THEN
--    ELSE
--    END CASE;
  
    --LOOP
    --EXIT WHEN condition
    --END LOOP
    
    --WHILE condition LOOP
    --END LOOP
    
    --FOR indice IN [REVERSE] valstart ..  valend LOOP
    
    --END LOOP;
    for i in 1..10 loop
      DBMS_OUTPUT.PUT_LINE (i);
    end loop;
  end;
  SYS.DBMS_OUTPUT.PUT_LINE(x);
  SYS.DBMS_OUTPUT.PUT_LINE(y);
end;