--unit test

--service
--primary key
insert into services (code,label) values('MNGMT','Management2');
--unique
insert into services (code,label) values('MNGM2','Management');
--not null
insert into services (code,label) values('MNGM2',null);

--employees
--primary key
insert into employees values('E94582BF-FAAD-4580-807C-A71265B6D953', '','','1/1/1','2/2/2',null,1.0,null,'MNGMT',null);
--foreign key
insert into employees values(NEWID(), '','','1/1/1','2/2/2',null,1.0,null,'MNT',null);
--not null
insert into employees values(NEWID(), '','','1/1/1','2/2/2',null,-1.0,null,'MNGMT',null);
insert into employees values(NEWID(), null,'','1/1/1','2/2/2',null,1.0,null,'MNGMT',null);
insert into employees values(NEWID(), '','','1/1/1','2/2/2',null,-1.0,null,'MNGMT',null);
insert into employees values(NEWID(), '','','1/1/3','2/2/2',null,1.0,null,'MNGMT',null);
insert into employees values(NEWID(), '','','1/1/3','2/2/2',null,1.0,null,null,null);

--daysoff
--primary key
insert into daysoff values('63345159-809B-4C0A-BF73-B414825E8F59',2013,null);
--foreign key
insert into daysoff values('63345159-809B-4C0A-BF73-B414825E8F58',2013,null);
--not null
insert into daysoff values(null,2013,null);
insert into daysoff values('63345159-809B-4C0A-BF73-B414825E8F59',null,null);
--acquired can be negative;
--alter table daysoff add constraint ck_acquired_positive check (acquired >0);
insert into daysoff values('63345159-809B-4C0A-BF73-B414825E8F59',2015,0);

--monthly_daysoff
--primary key
insert into monthly_daysoff values ('63345159-809B-4C0A-BF73-B414825E8F59',2013,4,null);
--foreign key
insert into monthly_daysoff values ('63345159-809B-4C0A-BF73-B414825E8FXX',2013,4,null);
insert into monthly_daysoff values ('63345159-809B-4C0A-BF73-B414825E8F59',2021,4,null);
--check
--alter table monthly_daysoff add constraint ck_daystaken_positive check (daysTaken >0);
insert into monthly_daysoff values ('63345159-809B-4C0A-BF73-B414825E8F59',2013,13,null);
--daysTaken can be negative;
insert into monthly_daysoff values ('63345159-809B-4C0A-BF73-B414825E8F59',2013,12,0);

