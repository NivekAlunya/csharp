drop table stocke_erreur;
create table stocke_erreur (
  login varchar2(1024),
  createdAt date,
  code varchar(1024)
);


drop trigger tr_erreur;
create or replace trigger tr_erreur after servererror on database
begin
insert into stocke_erreur values
  (ora_login_user,sysdate,ora_server_error(1));
end;

insert into dept values('29','peche','brest');
drop table info_user;
create table info_user
(
  "user" varchar2(30),
  createdAt date,
  action varchar2(30)
);

create or replace trigger tr_info_user
after logon on database
begin
  insert into info_user values(user,to_char(sysdate,'DD/MM/YYYY'),'connect');
end;

alter trigger tr_info_user compile;
select * from info_user;

rollback;