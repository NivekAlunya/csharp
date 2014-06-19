create or replace trigger tr_salary_updated_constraint
before update of sal on emp
for each row
when (new.sal>=old.sal)
  declare
  begin
    insert into "archive" values (:old.empno,:old.sal,sysdate);
  end;


alter table t_sequence add (after9 varchar2(1));

create or replace trigger tr_secure
before insert or update on t_sequence
for each row
when (to_number(to_char(sysdate,'HH24'))>=9)
  declare
  err exception;
  begin
    :new.after9:='Y';
  end;

insert into t_sequence (code,nom) values(skey.nextval,'KE');


select * from t_sequence;