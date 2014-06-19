use skirental;

--customers
--primary key
insert into customers (id, name,firstname,adress,zip,city) values
(1,'Albert','Anatole','Rue des accacias','61000','Amiens');
--not null
insert into customers (id, name,firstname,adress,zip,city) values
(18,null,'Anatole','Rue des accacias','61000','Amiens');
insert into customers (id, name,firstname,adress,zip,city) values
(1,'Albert','Anatole','Rue des accacias',null,'Amiens');
insert into customers (id, name,firstname,adress,zip,city) values
(1,'Albert','Anatole','Rue des accacias','61000',null);
--check
insert into customers (id, name,firstname,adress,zip,city) values
(18,'Albert','Anatole','Rue des accacias','00999','Nantes');
insert into customers (id, name,firstname,adress,zip,city) values
(18,'Albert','Anatole','Rue des accacias','96000','Nantes');

--cards
insert into dbo.cards (id, customer, createdAt, payedAt, "state") values
(1001,14,DATEADD(DAY,-15,getdate()),DATEADD(DAY,-13,getdate()) ,'SO');
--foreign key
insert into dbo.cards (id, customer, createdAt, payedAt, "state") values
(100000,999,DATEADD(DAY,-15,getdate()),DATEADD(DAY,-13,getdate()) ,'SO');
--not null
insert into dbo.cards (id, customer, createdAt, payedAt, "state") values
(100000,14,null,DATEADD(DAY,-13,getdate()) ,'SO');
insert into dbo.cards (id, customer, createdAt, payedAt, "state") values
(100000,14,DATEADD(DAY,-15,getdate()),DATEADD(DAY,-13,getdate()) ,null);
--check
--alter table cards drop constraint ck_cards_payedAt;
--alter table cards add constraint ck_cards_payedAt check(createdAt<payedAt and payedAt is not null  and state='SO' or state<>'SO' and payedAt is null);
insert into dbo.cards (id, customer, createdAt, payedAt, "state") values
(100000,14,DATEADD(DAY,-15,getdate()),DATEADD(DAY,-18,getdate()) ,'SO');
insert into dbo.cards (id, customer, createdAt, payedAt, "state") values
(100000,14,DATEADD(DAY,-15,getdate()),null ,'SO');
insert into dbo.cards (id, customer, createdAt, payedAt, "state") values
(100000,14,DATEADD(DAY,-15,getdate()),DATEADD(DAY,-13,getdate()) ,'EC');

--categories
--primary key
insert into categories (id,label) values
('MONO','Monoski2');
--unique
insert into categories (id,label) values
('MONO2','Monoski');
--not null
insert into categories (id,label) values
('MONO2',null);

--qualities
insert into qualities (id,label) values
('PR','Matériel Professionnel2');
--unique 
insert into qualities (id,label) values
('PR2','Matériel Professionnel');
--not null
insert into qualities (id,label) values
('PR2',null);

--prices
--primary key
insert into prices(id,label,dayprice) values
('T1','Base2',10);
--unique
insert into prices(id,label,dayprice) values
('T12','Base',10);
--not null
insert into prices(id,label,dayprice) values
('T12','Base2',null);
--check
insert into prices(id,label,dayprice) values
('T12','Base2',-1);
--pricelist
--primary key
insert into pricelist( quality,category,price) values
('EG','MONO','T1');
--foreign key
insert into pricelist( quality,category,price) values
('EG2','MONO','T1');
insert into pricelist( quality,category,price) values
('EG','MONO2','T1');
insert into pricelist( quality,category,price) values
('HG','SA','XX');
--not null
insert into pricelist( quality,category,price) values
('HG','SA',null);

--articles
--primary key
insert into articles (refart, designation, quality, category) values
('F01','Fischer Cruiser','EG','FOA');
--foreign key
insert into articles (refart, designation, quality, category) values
('X50','Fischer Cruiser','XX','FOA');
insert into articles (refart, designation, quality, category) values
('X50','Fischer Cruiser','EG','XXX');
insert into articles (refart, designation, quality, category) values
('X50','Fischer Cruiser','XX','XXX');
--not null
insert into articles (refart, designation, quality, category) values
('X50',null,'EG','FOA');

--cardlines
--primary key
insert into cardlines ("card",line,refart,dtout,dtin) values
(1001,1,'F05' ,DATEADD(DAY,-15,getdate()) ,DATEADD(DAY,-13,getdate()));
--foreign key
insert into cardlines ("card",line,refart,dtout,dtin) values
(10000,1,'F05' ,DATEADD(DAY,-15,getdate()) ,DATEADD(DAY,-13,getdate()));
insert into cardlines ("card",line,refart,dtout,dtin) values
(1001,128,'X05' ,DATEADD(DAY,-15,getdate()) ,DATEADD(DAY,-13,getdate()));
--not null
insert into cardlines ("card",line,refart,dtout,dtin) values
(1001,128,null ,DATEADD(DAY,-15,getdate()) ,DATEADD(DAY,-13,getdate()));
insert into cardlines ("card",line,refart,dtout,dtin) values
(1001,128,'F05' ,null ,null);
--check 
insert into cardlines ("card",line,refart,dtout,dtin) values
(1001,128,'F05' ,DATEADD(DAY,-15,getdate()) ,DATEADD(DAY,-18,getdate()));













