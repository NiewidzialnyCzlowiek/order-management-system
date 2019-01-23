import { SalesOrderLine } from './sales-order-line.interface';
import { Customer } from './customer.interface';
import { Address } from './address.interface';

export interface SalesOrderHeader {
    id: number;
    orderDate: Date;
    shipmentDate: Date;
    profit: number;
    customerId: number;
    customer: Customer;
    addressId: number;
    address: Address;
    lines: SalesOrderLine[];
}
