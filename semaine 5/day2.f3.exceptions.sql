/*
declare
  nom varchar2(6);
  prenom varchar2(6);
begin
  DBMS_OUTPUT.PUT_LINE('------------START----------');
  begin
    nom:='MARTIN';
    exception 
    when value_error then
      DBMS_OUTPUT.PUT_LINE('Surname too long...');
  end;
  begin
    prenom := 'kevindsf';
  exception 
    when value_error then
      DBMS_OUTPUT.PUT_LINE('firstname too long...');
  end;  

  DBMS_OUTPUT.PUT_LINE('------------END-----------');
  
end;
*/

declare
  nom varchar2(4);
  v_sal emp.sal%type;
begin
  DBMS_OUTPUT.PUT_LINE('------------START----------');
  select sal into v_sal from emp where ename='J-ONES';
  DBMS_OUTPUT.PUT_LINE(v_sal);
  nom:='littlekevin';
  exception
    when no_data_found then
      DBMS_OUTPUT.PUT_LINE('Employee not found');
    when value_error then
      DBMS_OUTPUT.PUT_LINE('Name too long...');
    when others then
      DBMS_OUTPUT.PUT_LINE(sqlcode||':'||sqlerrm);
  DBMS_OUTPUT.PUT_LINE('------------END-----------');
 
end;
