import { AddressRead } from './address.interface';

export interface CustomerRead {
    id: number;
    name: string;
}
export interface CustomerReadFull {
    id: number;
    name: string;
    addresses: AddressRead[];
}
export interface CustomerCreate {
    name: string;
}
export interface CustomerUpdate {
    name: string;
}
