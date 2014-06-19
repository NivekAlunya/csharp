--create database videorent;
--use videorent;

create table customers (
	id char(6) constraint pk_customers primary key
,	title char(4) not null
,	firstname varchar(80) not null
,	name  varchar(80) not null
,	adress varchar(120) not null
,	zip char(5) not null
,	city varchar(80) not null
,	phone varchar(16) not null
,	dob datetime not null
,	childs numeric(1) not null
);

create table moviestyles (
	id char(2) constraint pk_moviestyles primary key
,	label varchar(30)
);

create table directors (
	id char(6) constraint pk_directors primary key
,	firstname varchar(80) not null
,	name  varchar(80) not null
,	yearofbirth numeric(4)
,	country varchar(80)
);

create table dvds(
	id numeric(12) identity constraint pk_dvds primary key 
,	title varchar(80)
,	price numeric(4,2)
,	director char(6) constraint fk_dvds_directors foreign key references directors(id)
,	moviestyle char(2) constraint fk_dvds_moviestyles foreign key references moviestyles(id)
,	"year" numeric(4)
,	casting varchar(8000)
,	duration numeric(3)
);

create table renttypes(
	id char(2) constraint pk_renttypes primary key
,	label varchar(30)
,	coef numeric(2,1)
,	nday numeric(1)
);

create table bills(
	id numeric(12) identity constraint pk_factures primary key
,	customer char(6) constraint fk_bills_customers foreign key references customers(id)
,	rentedAt char(10) --date
);

create table rents(
	bill numeric(12) constraint fk_rents_bills foreign key references bills(id)
,	dvd numeric(12) null constraint fk_rents_dvds foreign key references dvds(id)
,	renttypre char(2) constraint fk_rents_renttypes foreign key references renttypes(id)
,	dtin datetime2 
);



--RETRIEVING QUERIES
--1. Liste des clients (Nom, Prenom, Ville)
select name,firstname,city
from customers
;

--2. Liste des clients avec tous les champs (*) et triée par Ville (croissant) puis par Nom (décroissant)
select * 
from customers
order by city asc,name desc
;

--3. Liste des dvds (Titre, Annee) avec un tri sur le Titre
select d.title,d.year 
from dvds d
order by title asc
;

--4. Liste des réalisateurs classés du plus âgé au plus jeune (*)
select * from directors
order by yearofbirth desc
;

--5. Liste des Clients de Loire-Atlantique (*)
select *
from customers
where zip between 44000 and 44999
;
--6. Liste des Clientes dont le prénom commence par « a » (*)
select *
from customers 
where firstname like('a%')
;
--7. Liste des Clients nés pendant les années 70 (*)

select *
from customers
where DATEPART(year,dob) between 1970 and 1979
;
--8. Liste des Réalisateurs anglais et américains (*)
select *
from directors
where country in('ANGLETERRE','USA')

--9. Liste des Réalisateurs américains nés au 19ème siècle dont le Nom contient un « a » (*)
select *
from directors
where yearofbirth<1900 and (name like('a%') or firstname like('a%'))
;
--10. Liste des dvds de moins de deux heures
select *
from dvds 
where duration<120
;

--Requêtes avec Calculs Statistiques
--1. Nombre de Clients par Titre
select e.id,COUNT(e.customer)
from 
(select d.id,b.customer
from dvds d
left outer join rents r on r.dvd = d.id
left outer join bills b on r.bill = b.id
group by d.id,b.customer) e
group by e.id
order by 2,1
;

select d.id,COUNT(distinct b.customer)
from dvds d
left outer join rents r on r.dvd = d.id
left outer join bills b on r.bill = b.id
group by d.id
order by 2,1
;

--2. Nombre de dvds par Genre de Film
select ms.id,ms.label,COUNT(d.id)
from moviestyles ms
left outer join dvds d on d.moviestyle = ms.id
group by ms.id,ms.label

--3. Nombre de Réalisateurs par Pays du plus grand nombre au plus petit
select country,count(id)
from directors
group by country
order by 2 desc
;

--4. Nombre de dvds concernant des films des années 70 par genre
select ms.id,ms.label,COUNT(d.id)
from moviestyles ms 
left outer join dvds d on d.moviestyle = ms.id
where d.year between 1970 and 1979 or d.id is null
group by ms.id,ms.label
;
--5. Durée moyenne des films par genre
select ms.id,ms.label,avg(d.duration)
from moviestyles ms 
inner join dvds d on d.moviestyle = ms.id
group by ms.id,ms.label
;

--6. Durée maximum des films des années 80 par genre
select ms.id,ms.label,max(d.duration)
from moviestyles ms 
left outer join dvds d on d.moviestyle = ms.id
where d.year between 1980 and 1989 or d.id is null
group by ms.id,ms.label
;

--7. Nombre de Clients par mois de naissance
select DATEPART(mm,dob),COUNT(*)
from customers
group by DATEPART(mm,dob)
;

--Requêtes Multitables
--1. Liste des dvds avec leur Titre et la Signification de leur genre
select d.title,ms.label
from dvds d
inner join moviestyles ms on ms.id = d.moviestyle;

--2. Liste des dvds avec leur Titre, le Nom, Prenom et nationalité du Réalisateur et Signification du genre
select d.title,dr.name,dr.firstname,dr.country
from dvds d
inner join moviestyles ms on ms.id = d.moviestyle
inner join directors dr on dr.id = d.director ;

--3. Liste des Clients avec leur Nom, Prenom ayant loué des dvds en Juin 2006
select c.id,c.name,c.firstname
from customers c
inner join bills b on b.customer = c.id
inner join rents r on r.bill = b.id
where b.rentedAt like('2006-06-%')
group by c.id,c.name,c.firstname
;

--4. Liste des dvds loués avec leur Titre et leur Durée, l’Identité du Client (Concaténation des champs Titre, Nom, Prenom) et du Réalisateur (idem)
select d.title,d.duration,c.title + ' ' + c.name + ' ' + c.firstname fullname, dr.name + ' ' + dr.firstname directorfullname
from  dvds d 
inner join directors dr on dr.id = d.director
inner join rents r on r.dvd = d.id
inner join bills b on b.id = r.bill
inner join customers c on c.id=b.customer
group by d.title,d.duration,c.title + ' ' + c.name + ' ' + c.firstname,dr.name + ' ' + dr.firstname
;
--5. Liste des Clients ayant loué des dvds de Réalisateurs Allemands pendant le mois de Juin 2006
select c.id
from  dvds d 
inner join directors dr on dr.id = d.director
inner join rents r on r.dvd = d.id
inner join bills b on b.id = r.bill
inner join customers c on c.id=b.customer
where dr.country = 'ALLEMAGNE' and b.rentedAt like('2006-06-%')
group by c.id
;

--6. Titres des dvds d’aventure loués par des Clients de sexe masculin nés dans les années 60
select d.title
from dvds d
inner join rents r on r.dvd = d.id
inner join bills b on b.id = r.bill
inner join customers c on c.id=b.customer
where c.title = 'M.' and DATEPART(YEAR,dob) between 1960 and 1969 and d.moviestyle = 'AV'
group by d.title
order by d.title
;
--7. Nombre de dvds loués par Client pour connaître le nom du meilleur
select top 1 c.id,COUNT(*)
from customers c 
inner join bills b on b.customer = c.id
inner join rents r on r.bill = b.id
inner join dvds d on d.id = r.dvd
group by c.id
order by 2 desc
;
--8. Après vous êtes ajouté à la table Clients, retrouver votre Code en recherchant le ou les Clients n’ayant effectué aucune location
--insert into customers values ('XXX001','M.','kevin','LAUNAY','5, place de la Cathédrale','44000','NANTES','0240223311','janv  1 1956 12:00AM',0 );
select c.id
from customers c
left outer join bills b on b.customer = c.id
where b.id is null;

--Requêtes Analyse Croisée
--1. Nombre de dvds par Pays et par Genre (= Signification)
--2. Nombre de Clients par Titre et par Département (Extraction sur le Code_postal)
--3. Durée moyenne des films par Pays et par Genre

--Requêtes Action
--1. Créer une table des Clients de Loire-Atlantique avec leur Titre, Nom,
