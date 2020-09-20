export interface AddressRead {
    id: number;
    country: string;
    postCode: string;
    city: string;
    street: string;
    buildingNo: string;
}
export interface AddressReadFull {
    id: number;
    country: string;
    postCode: string;
    city: string;
    street: string;
    buildingNo: string;
    appartmentNo: string;
    customerId: number;
}
export interface AddressCreate {
    country: string;
    postCode: string;
    city: string;
    street: string;
    buildingNo: string;
    appartmentNo: string;
    customerId: number;
}
export interface AddressUpdate {
    country: string;
    postCode: string;
    city: string;
    street: string;
    buildingNo: string;
    appartmentNo: string;
    customerId: number;
}
