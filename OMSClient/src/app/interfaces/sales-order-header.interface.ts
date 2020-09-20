import { CustomerRead, CustomerReadFull } from './customer.interface';
import { AddressRead, AddressReadFull } from './address.interface';
import { SalesOrderLineRead } from './sales-order-line.interface';

export interface SalesOrderHeaderRead {
    id: number;
    orderDate: Date;
    customerId: number;
    customer: CustomerRead;
    addressId: number;
    address: AddressRead;
}
export interface SalesOrderHeaderReadFull {
    id: number;
    orderDate: Date;
    shipmentDate: Date;
    profit: number;
    customerId: number;
    customer: CustomerReadFull;
    addressId: number;
    address: AddressReadFull;
    lines: SalesOrderLineRead[];
}
export interface SalesOrderHeaderCreate {
    orderDate: Date;
    shipmentDate: Date;
    profit: number;
    customerId: number;
    addressId: number;
}
export interface SalesOrderHeaderUpdate {
    orderDate: Date;
    shipmentDate: Date;
    profit: number;
    customerId: number;
    addressId: number;
}
