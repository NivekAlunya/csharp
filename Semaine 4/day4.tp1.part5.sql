use skirental;
set statistics profile on;
CHECKPOINT;
GO
DBCC DROPCLEANBUFFERS;
GO
--12.
select a.refart,count(cl.refart)
from articles a 
left outer join cardlines cl on cl.refart = a.refart
group by a.refart
order by 2 desc,1 asc;

--13.
select c.id
from customers c
where not exists(select * from cards ca where ca.customer = c.id)
;

select c.id
from customers c
where c.id not in(select distinct(customer) from cards)
;

select c.id
from customers c
left outer join cards ca on ca.customer = c.id
where ca.customer is null
;

--14.
select ca.*
from cards ca
inner join cardlines cl on cl.card = ca.id
where dtin is null and DATEDIFF(day,dtout,GETDATE())>5;
;

--15.

select AVG(DATEDIFF(day,dtout,dtin)*p.dayprice) 
from categories ct
inner join articles a on a.category = ct.id
inner join cardlines cl on cl.refart = a.refart
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join prices p on p.id = pl.price
where ct.id in('SA','FOA','FOP') and dtin is not null;

--or

select AVG(DATEDIFF(day,dtout,case when dtin is null then GETDATE() else dtin end)*p.dayprice) 
from categories ct
inner join articles a on a.category = ct.id
inner join cardlines cl on cl.refart = a.refart
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join prices p on p.id = pl.price
where ct.id in('SA','FOA','FOP');


--16.
select a.refart, a.Designation,ca.id,count(ca.id)
from articles a	
left outer join cardlines cl on cl.refart = a.refart
left outer join cards ca on ca.id = cl.card
group by a.refart ,a.Designation,ca.id
having count(a.refart) = 1
order by refart;
;

select a.refart,a.designation, COUNT(*) from 
	(select cl.refart,ca.customer
		from cardlines cl
		left outer join cards ca on ca.id = cl.card
--		where cl.refart = 'F05'
		group by cl.refart,ca.customer) e
inner join articles a on a.refart = e.refart
group by a.refart, a.designation
having COUNT(*) = 1
;

--17.

select c.id,SUM(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1))
from customers c
inner join cards ca on ca.customer = c.id
inner join cardlines cl on cl.card = ca.id
inner join articles a on a.refart = cl.refart
inner join pricelist pl on pl.category = a.category and pl.quality = a.quality
inner join prices p on p.id = pl.price
where DATEDIFF(YEAR,dtout,dtin)<=1
group by c.id
having SUM(p.dayprice * (round(DATEDIFF(DAY, cl.dtout, cl.dtin),0)+1))>450
;

--18.
