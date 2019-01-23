-- This function calculates the difference between Item's Unit Price and Unit Cost multiplied by Quantity 
-- summed for all the lines related to Sales Order Header
CREATE OR REPLACE procedure public."CalcSalesOrderProfit" ( "headerId" Integer)
	LANGUAGE plpgsql
	AS $$
declare
	profit decimal := 0;
begin
	select sum(line."Quantity" * (i."UnitPrice" - i."UnitCost")) into profit
	from "SalesOrderLines" line join "Items" i on line."ItemId" = i."Id"
	where line."SalesOrderHeaderId" = "headerId"
	group by line."SalesOrderHeaderId";
	update "SalesOrderHeaders" set "Profit" = profit
	where "SalesOrderHeaders"."Id" = "headerId";
end;
$$;

CREATE OR REPLACE procedure public."CalcSalesOrderLineAmount" ( "lineId" integer)
	LANGUAGE plpgsql
	AS $$
declare
	amount decimal := 0;
begin
	select line."Quantity" * i."UnitPrice" into amount
	from "SalesOrderLines" line join "Items" i on line."ItemId" = i."Id"
	where line."Id" = "lineId"
    limit 1;
	update "SalesOrderLines" set "Amount" = amount
	where "SalesOrderLines"."Id" = "lineId";
end;
$$;