/*
declare
-- NULL valeur par defaut
x NUMBER(6,2) := 1; --
y VARCHAR2(20); -- CHAR , CLOB, BLOB, BFILE
z BOOLEAN;
v_date_jour date := sysdate;



begin
DBMS_OUTPUT.PUT_LINE('-------------------------------');
DBMS_OUTPUT.PUT_LINE('x='||x);
x := 10;
DBMS_OUTPUT.PUT_LINE('x='||x);

end;
*/
declare
v_salaire EMP.SAL%type;
v_job emp.job%type;
v_emp EMP%rowtype;

begin 

select sal,job into v_salaire,v_job from emp where ename = 'KING';
SYS.DBMS_OUTPUT.PUT_LINE(v_salaire||' '||v_job);

select * into v_emp from emp where ename = 'KING';
SYS.DBMS_OUTPUT.PUT_LINE(v_emp.sal||' '||v_emp.job);

end;