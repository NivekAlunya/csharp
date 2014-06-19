use skirental;
delete from cardlines;
delete from cards;
delete from customers;
delete from articles;
delete from pricelist;
delete from categories;
delete from qualities;
delete from prices;

go

insert into customers (id, name,firstname,adress,zip,city) values
(1,'Albert','Anatole','Rue des accacias','61000','Amiens'),
(2,'Bernard' ,'Barnabé' ,'Rue du bar' ,'1000','Bourg en Bresse'),
(3,'Dupond' ,'Camille' ,'Rue Crébillon' ,'44000','Nantes'),
(4,'Desmoulin' ,'Daniel' ,'Rue descendante' ,'21000','Dijon'),
(5,'Ernest' ,'Etienne' ,'Rue de l’échaffaud' ,'42000','Saint Étienne'),
(6,'Ferdinand' ,'François' ,'Rue de la convention' ,'44100','Nantes'),
(9,'Dupond' ,'Jean' ,'Rue des mimosas' ,'75018','Paris'),
(14,'Boutaud' ,'Sabine' ,'Rue des platanes' ,'75002','Paris');

insert into dbo.cards (id, customer, createdAt, payedAt, "state") values
(1001,14,DATEADD(DAY,-15,getdate()),DATEADD(DAY,-13,getdate()) ,'SO'),
(1002,4,DATEADD(DAY,-13,getdate()),default,'EC'),
(1003,1,DATEADD(DAY,-12,getdate()),DATEADD(DAY,-10,getdate()) ,'SO'),
(1004,6,DATEADD(DAY,-11,getdate()),default,'EC' ),
(1005,3,DATEADD(DAY,-10,getdate()) ,default,'EC' ),
(1006,9,DATEADD(DAY,-10,getdate()) ,default,'RE' ),
(1007,1,DATEADD(DAY,-3,getdate()) ,default,'EC' ),
(1008,2,getDate() ,default,'EC');

insert into categories (id,label) values
('MONO','Monoski'),
('SURF','Surf'),
('PA','Patinette'),
('FOA','Ski de fond alternatif'),
('FOP','Ski de fond patineur'),
('SA','Ski alpin');

insert into qualities (id,label) values
('PR','Matériel Professionnel'),
('HG','Haut de gamme'),
('MG','Moyenne gamme'),
('EG','Entrée de gamme');


insert into prices (id,label,dayprice) values
('T1','Base',10),
('T2','Chocolat',15),
('T3','Bronze',20),
('T4','Argent',30),
('T5','Or',50),
('T6','Platine',90);

insert into pricelist( quality,category,price) values
('EG','MONO','T1'),
('MG','MONO','T2'),
('EG','SURF','T1'),
('MG','SURF','T2'),
('HG','SURF','T3'),
('PR','SURF','T5'),
('EG','PA','T1'),
('MG','PA','T2'),
('EG','FOA','T1'),
('MG','FOA','T2'),
('HG','FOA','T4'),
('PR','FOA','T6'),
('EG','FOP','T2'),
('MG','FOP','T3'),
('HG','FOP','T4'),
('PR','FOP','T6'),
('EG','SA','T1'),
('MG','SA','T2'),
('HG','SA','T4'),
('PR','SA','T6');

insert into articles (refart, designation, quality, category) values
('F01','Fischer Cruiser','EG','FOA'),
('F02','Fischer Cruiser','EG','FOA'),
('F03','Fischer Cruiser','EG','FOA'),
('F04','Fischer Cruiser','EG','FOA'),
('F05','Fischer Cruiser','EG','FOA'),
('F10','Fischer Sporty Crown','MG','FOA'),
('F20','Fischer RCS Classic GOLD','PR','FOA'),
('F21','Fischer RCS Classic GOLD','PR','FOA'),
('F22','Fischer RCS Classic GOLD','PR','FOA'),
('F23','Fischer RCS Classic GOLD','PR','FOA'),
('F50','Fischer SOSSkating VASA','HG','FOP'),
('F60','Fischer RCS CARBOLITE Skating','PR','FOP'),
('F61','Fischer RCS CARBOLITE Skating','PR','FOP'),
('F62','Fischer RCS CARBOLITE Skating','PR','FOP'),
('F63','Fischer RCS CARBOLITE Skating','PR','FOP'),
('F64','Fischer RCS CARBOLITE Skating','PR','FOP'),
('P01','Décathlon Allegre junior 150','EG','PA'),
('P10','Fischer mini ski patinette','MG','PA'),
('P11','Fischer mini ski patinette','MG','PA'),
('S01','Décathlon Apparition','EG','SURF'),
('S02','Décathlon Apparition','EG','SURF'),
('S03','Décathlon Apparition','EG','SURF'),
('A01','Salomon 24X+Z12','EG','SA'),
('A02','Salomon 24X+Z12','EG','SA'),
('A03','Salomon 24X+Z12','EG','SA'),
('A04','Salomon 24X+Z12','EG','SA'),
('A05','Salomon 24X+Z12','EG','SA'),
('A10','Salomon Pro Link Equipe 4S','PR','SA'),
('A11','Salomon Pro Link Equipe 4S','PR','SA'),
('A21','Salomon 3V RACE JR+L10','PR','SA');

insert into cardlines ("card",line,refart,dtout,dtin) values
(1001,1,'F05' ,DATEADD(DAY,-15,getdate()) ,DATEADD(DAY,-13,getdate())), 
(1001,2,'F50' ,DATEADD(DAY,-15,getdate()) ,DATEADD(DAY,-14,getdate())), 
(1001,3,'F60' ,DATEADD(DAY,-13,getdate()) ,DATEADD(HOUR,6,DATEADD(DAY,-13,getdate()))),
(1002,1,'A03' ,DATEADD(DAY,-13,getdate()) ,DATEADD(DAY,-9,getdate())),
(1002,2,'A04' ,DATEADD(DAY,-12,getdate()) ,DATEADD(DAY,-7,getdate())), 
(1002,3,'S03' ,DATEADD(DAY,-8,getdate()) ,null),
(1003,1,'F50' ,DATEADD(DAY,-15,getdate()) ,DATEADD(DAY,-10,getdate())), 
(1003,2,'F05' ,DATEADD(DAY,-12,getdate()) ,DATEADD(DAY,-10,getdate())), 
(1004,1,'P01' ,DATEADD(DAY,-6,getdate()) ,null),
(1005,1,'F05' ,DATEADD(DAY,-9,getdate()) ,DATEADD(DAY,-5,getdate())), 
(1005,2,'F10' ,DATEADD(DAY,-4,getdate()),null),
(1006,1,'S01' ,DATEADD(DAY,-10,getdate()) ,DATEADD(DAY,-9,getdate())), 
(1006,2,'S02' ,DATEADD(DAY,-10,getdate()) ,DATEADD(DAY,-9,getdate())), 
(1006,3,'S03' ,DATEADD(DAY,-10,getdate()) ,DATEADD(DAY,-9,getdate())),
(1007,1,'F50' ,DATEADD(DAY,-3,getdate()),DATEADD(DAY,-2,getdate())),
(1007,3,'F60' ,DATEADD(DAY,-1,getdate()) ,null),
(1007,2,'F05' ,DATEADD(DAY,-3,getdate()) ,null),
(1007,4,'S02' ,getdate() ,null),
(1008,1,'S01' ,getdate(),null);

go

select * from cardlines;
select * from cards;
select * from customers;
select * from articles;
select * from pricelist;
select * from categories;
select * from qualities;
select * from prices;