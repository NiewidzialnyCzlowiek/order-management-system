import { Address } from './address.interface';

export interface Customer {
    id: number;
    name: string;
    addresses: Address[];
}
