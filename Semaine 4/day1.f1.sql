--create database AdministrationOfEmployees; 
--GO;
--use AdministrationOfEmployees;
/*
create table services(
  codeService char(5),
  label varchar(30)
);
*/
--alter table services add telephone char(3);

--alter table services  alter column telephone char(10);

--alter table services drop column telephone;

--drop table services;


create table services (
  code	char(5) constraint pk_services primary key,
  label varchar(30) not null
);
create table employees (
  id			uniqueidentifier
					constraint pk_employees primary key,
  name			varchar(20) not null,
  firstname		varchar(30) null,
  dob			datetime not null,
  dateRecruit	datetime not null default getdate(),
  editedAt		datetime null,
  salary		numeric(8,2) default 15000
					constraint ck_employees_salary check(0<=salary),--8 numbers 2 decimals after the comma
  picture		image,
  "service"		char(5) not null 
					constraint fk_employess_services references services(code)
					on update cascade,
  chief			uniqueidentifier
					constraint fk_employees_employees references employees(id),
  constraint ck_employees_dates check(dateRecruit > dob)
);

alter table services add constraint unique_label unique(label);

create table daysoff(
	employee	uniqueidentifier not null
				constraint fk_daysoff_employees references employees(id)
				on delete cascade,
	"year"		numeric(4) not null,
	acquired	numeric(2) default 25,
					constraint pk_daysoff primary key(employee,"year")
);

create table monthly_daysoff(
  employee		uniqueidentifier not null,
  "year"		numeric(4) not null,
  "month"		numeric(2) not null
				constraint ck_monthly_daysoff_month check("month" between 1 and 12),
  daysTaken		numeric(2),
  constraint pk_monthly_daysoff primary key(employee,"year","month"),
  constraint fk_monthly_daysoff_days_off foreign key(employee,"year")
	references daysoff(employee,"year")
	on delete cascade
);


