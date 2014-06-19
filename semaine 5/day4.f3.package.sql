
create or replace package mine is
  mine_value number:=8;
  too_big exception;
  function f1(params number) return number;
  procedure p1;
end mine;

create or replace package body mine is
  function f1(params number) return number is
  begin
    if(params + mine_value > 100) then
      raise too_big;
    end if;
    return params + mine_value;
    exception
      when too_big then 
        dbms_output.put_line('Too BIGGGGGGGGGGG!!!!!!');
        return 0;
      when others then 
        dbms_output.put_line(sqlcode);
        return 0;
  end;
  procedure p1 is
  begin
    mine_value:=mine_value + 1;
  end;
end mine;

execute MINE.P1;
select MINE.F1(500) from dual;

select :mine_value from dual;


