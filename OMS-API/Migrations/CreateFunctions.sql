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