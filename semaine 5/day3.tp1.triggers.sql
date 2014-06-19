create or replace trigger tr_v_manager
instead of insert
on V_MANAGER
for each row
declare
begin
  insert into emp (empno,ename,sal,job) values(:new.empno,:new.ename,:new.sal,'MANAGER');
end;



create or replace view V_MANAGER as
select empno,ename,sal from emp where job = 'MANAGER';

insert into V_MANAGER values (8001,'LAUNAY',6000);

select * from emp;

create table clients
(
  "id" number constraint pk_clients primary key,
  "name" varchar2(20) constraint nn_clients_name not null 
);

create table orders
(
  "id"  number constraint pk_orders primary key,
  client number constraint nn_orders_clients not null,
  createdAt date,
  constraint fk_orders_clients foreign key(client) references clients("id")
);