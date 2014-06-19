
--drop table t_sequence;
create table t_sequence (
code number primary key,
nom varchar2(30) not null
);
create sequence skey minvalue 1 increment by 1;
insert into t_sequence values(skey.nextval,'KEVIN');
insert into t_sequence values(skey.nextval,'KEVIN');
commit;
select skey.currval from dual;

drop trigger tr_increment;
create or replace trigger tr_increment
before insert on T_SEQUENCE
for each row
declare
  nb integer;
  test exception;
begin
  select count(*) into nb from T_SEQUENCE;
  if(nb = 0) then
    raise test;
  end if;
  select max(code)+1 into :new.code from T_SEQUENCE; 
  exception
    when test then
      :NEW.code:=1;
end;

truncate table t_sequence;
