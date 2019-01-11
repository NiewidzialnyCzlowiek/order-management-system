import { Customer } from './customer.interface';

export interface Address {
    id: number;
    country: string;
    postCode: string;
    city: string;
    street: string;
    buildingNo: string;
    appartmentNo: string;
    customerId: number;
    customer: Customer;
}
