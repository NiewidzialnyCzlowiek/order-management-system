import { Item } from './item.interface';
import { SalesOrderHeader } from './sales-order-header.interface';

export interface SalesOrderLine {
    id: number;
    quantity: number;
    amount: number;
    itemId: number;
    item: Item;
    salesOrderHeaderId: number;
    salesOrderHeader: SalesOrderHeader;
}
