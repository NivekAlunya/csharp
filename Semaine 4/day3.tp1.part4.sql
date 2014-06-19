use skirental;
--iv sql queries
--1.
select *
from customers c
inner join cards ca on ca.customer = c.id
where ca.state='EC';

select *
from customers c
where exists(select * from cards ca where ca.customer = c.id and ca.state='EC');

--2.
select c.*, ca.*,a.designation,cl.dtout,cl.dtin
from customers c 
inner join cards ca on ca.customer = c.id
inner join cardlines cl on cl.card = ca.id
inner join articles a on a.refart = cl.refart
where c.name = 'dupond' 
	and c.firstname = 'Jean' 
	and (/*lower(city) = ('paris') 
	or*/ (
		CAST(zip as numeric(5))>=75000 
		and CAST(zip as numeric(5))<76000)
	)
;
--3.
select a.refart, a.designation, ct.label
from articles a
inner join categories ct on ct.id = a.category
where ct.label like('%ski%');

select a.refart, a.designation, ct.label
from articles a
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join categories ct on ct.id = a.category
where ct.label like('%ski%');


--4.
select *
from 
(select ca.id,sum(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1)) montant
from cards ca
inner join cardlines cl on cl.card = ca.id
inner join articles a on a.refart = cl.refart
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join prices p on p.id = pl.price
where ca.state = 'SO'
group by ca.id) e1
cross join
(select sum(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1)) montant
from cards ca
inner join cardlines cl on cl.card = ca.id
inner join articles a on a.refart = cl.refart
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join prices p on p.id = pl.price
) e2
;

select ca.id,sum(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1)) montant
from cards ca
inner join cardlines cl on cl.card = ca.id
inner join articles a on a.refart = cl.refart
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join prices p on p.id = pl.price
where ca.state = 'SO'
group by ca.id
union
select -1,sum(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1)) montant
from cards ca
inner join cardlines cl on cl.card = ca.id
inner join articles a on a.refart = cl.refart
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join prices p on p.id = pl.price
where ca.state = 'SO'
;
--5.
select COUNT(distinct(a.refart))
from articles a
inner join cardlines cl on cl.refart = a.refart
where cl.dtin is null
;

select COUNT(*)
from articles a
where exists(select * from cardlines cl where cl.refart = a.refart and cl.dtin is null)
;

--6.
select ca.customer,COUNT(distinct cl.refart)
from cardlines cl
inner join cards ca on ca.id = cl.card
group by ca.customer;
--or
select ca.customer,COUNT(cl.refart)
from cardlines cl
inner join cards ca on ca.id = cl.card
group by ca.customer;
--or
select AVG(e.nbart)
from (select ca.customer,COUNT(cl.refart) as nbart
from cardlines cl
inner join cards ca on ca.id = cl.card
group by ca.customer) e ;

--7.
select c.id
from customers c
where exists(
	select * 
	from cards ca 
	inner join cardlines cl on cl.card = ca.id
	inner join articles a on a.refart = cl.refart
	inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
	inner join prices p on p.id = pl.price
	where ca.customer = c.id
	group by ca.id
	having sum(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, case when cl.dtin IS null then GETDATE() else cl.dtin end),0)+1)) > 200)
;
--or
select c.id
from customers c
inner join cards ca on ca.customer = c.id
inner join cardlines cl on cl.card = ca.id
inner join articles a on a.refart = cl.refart
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join prices p on p.id = pl.price
group by c.id
having sum(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, case when cl.dtin IS null then GETDATE() else cl.dtin end),0)+1)) > 200
;

--8.
select a.refart,COUNT(*) located
from articles a
inner join cardlines cl on cl.refart = a.refart
group by a.refart
having COUNT(*)>0
order by located desc;

select a.refart,COUNT(*) located
from articles a
inner join cardlines cl on cl.refart = a.refart
group by a.refart
order by located desc;


--9.
select ca.id,c.name,c.firstname
from customers c
inner join cards ca on ca.customer = c.id
where exists(
	select * 
	from cardlines cl
	inner join articles a on a.refart = cl.refart
	inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
	inner join prices p on p.id = pl.price
	where cl.card = ca.id
	group by cl.card
	having sum(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1)) < 150)
;
--or
select ca.id,c.name,c.firstname
from customers c
inner join cards ca on ca.customer = c.id
inner join cardlines cl on cl.card = ca.id
inner join articles a on a.refart = cl.refart
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join prices p on p.id = pl.price
group by ca.id,c.name,c.firstname,cl.card
having sum(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1)) < 150
;

--10.
select avg(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1))
from categories ct
inner join pricelist pl on pl.category = ct.id
inner join prices p on p.id=pl.price
inner join articles a on a.category = pl.category and a.quality = pl.quality
inner join cardlines cl on cl.refart=a.refart
where ct.id = 'SURF'
;

select sum(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1))/COUNT(*)
from categories ct
inner join pricelist pl on pl.category = ct.id
inner join prices p on p.id=pl.price
inner join articles a on a.category = pl.category and a.quality = pl.quality
inner join cardlines cl on cl.refart=a.refart
where ct.id = 'SURF' and cl.dtin is not null
;
--11.
select avg(datediff(DAY, cl.dtout, cl.dtin)+1)
from categories ct
inner join pricelist pl on pl.category = ct.id
inner join articles a on a.category = pl.category and a.quality = pl.quality
inner join cardlines cl on cl.refart=a.refart
where ct.id in('SA','FOA','FOP') and cl.dtin is not null;
--or
select AVG(round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1)
from categories ct
inner join articles a on a.category = ct.id
inner join cardlines cl on cl.refart=a.refart
where ct.id in('SA','FOA','FOP') and cl.dtin is not null;
