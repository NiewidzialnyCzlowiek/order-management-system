import { ItemRead, ItemReadFull } from './item.interface';
import { SalesOrderHeaderRead, SalesOrderHeaderReadFull } from './sales-order-header.interface';

export interface SalesOrderLineRead {
    id: number;
    quantity: number;
    amount: number;
    itemId: number;
    item: ItemRead;
    salesOrderHeaderId: number;
}
export interface SalesOrderLineReadFull {
    id: number;
    quantity: number;
    amount: number;
    itemId: number;
    item: ItemReadFull;
    salesOrderHeaderId: number;
}
export interface SalesOrderLineCreate {
    quantity: number;
    amount: number;
    itemId: number;
    salesOrderHeaderId: number;
}
export interface SalesOrderLineUpdate {
    quantity: number;
    amount: number;
    itemId: number;
    salesOrderHeaderId: number;
}
