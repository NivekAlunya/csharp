
--a. restrictions / filters / conditions
select * from customers where CHARINDEX('D',name)=1;
select * from customers where name like('D%');
--b. fields
select name,firstname from customers;
--c. joint
select ca.id,ca.state, c.name, c.firstname 
from cards ca
inner join customers c on ca.customer = c.id
where (c.zip between 44000 and 44999)

select ca.id,ca.state, c.name, c.firstname  from cards ca
inner join customers c on ca.customer = c.id and (c.zip between 44000 and 44999)

select ca.id,ca.state, c.name, c.firstname  from cards ca,customers c 
where ca.customer = c.id and (c.zip between 44000 and 44999)

--d. multi join
select ca.id, c.name, c.firstname,a.refart, a.designation, cl.dtout, cl.dtin, p.dayprice, p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1)
from cards ca
inner join cardlines cl on cl.card = ca.id
inner join articles a on a.refart = cl.refart
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join prices p on p.id = pl.price
inner join customers c on ca.customer = c.id
where ca.id = 1006;

select ca.id, c.name, c.firstname,a.refart, a.designation, cl.dtout, cl.dtin, p.dayprice, p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1)
from cards ca
,cardlines cl 
,articles a
,pricelist pl
,prices p
,customers c
where cl.card = ca.id and a.refart = cl.refart and pl.category = a.category and pl.quality = a.quality and p.id = pl.price and ca.customer = c.id and ca.id = 1006;


--e agregate
select q.label , avg(p.dayprice)
from pricelist pl 
inner join  prices p on p.id = pl.price
inner join qualities q on q.id = pl.quality
group by q.label;

--f
select a.refart,a.designation,COUNT(a.refart)
from articles a
inner join cardlines cl on cl.refart = a.refart
group by a.refart,a.designation
having COUNT(*)>2;

select a.refart, a.designation
from articles a
where exists(
		select cl.refart
		from cardlines cl
		where cl.refart = a.refart
		group by cl.refart
		having COUNT(*)>2);
--
--g
select * 
from 
	(select ca.id, c.name, c.firstname,a.refart, a.designation, cl.dtout, cl.dtin, p.dayprice, p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1) montant
	from cards ca
	inner join cardlines cl on cl.card = ca.id
	inner join articles a on a.refart = cl.refart
	inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
	inner join prices p on p.id = pl.price
	inner join customers c on ca.customer = c.id
	where ca.id = 1006) req1
cross join
	(select sum(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1)) montant
	from cards ca
	inner join cardlines cl on cl.card = ca.id
	inner join articles a on a.refart = cl.refart
	inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
	inner join prices p on p.id = pl.price
	inner join customers c on ca.customer = c.id
	where ca.id = 1006) req2
;
