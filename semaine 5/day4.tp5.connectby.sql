create index ix_ename on emp(ename);

alter system flush shared_pool;
alter system flush buffer_cache;

select * from emp where ename = 'KING';

select empno , ename, mgr ,level
from emp
where level between 2 and 3
connect by prior empno = mgr
start with ename='KING';

select empno , ename, mgr, level 
from emp
connect by prior mgr = empno
start with ename='SMITH';

