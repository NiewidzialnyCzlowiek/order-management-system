export interface ItemRead {
    id: number;
    name: string;
    unitOfMeasureCode: string;
}
export interface ItemReadFull {
    id: number;
    name: string;
    description: string;
    unitPrice: number;
    unitCost: number;
    unitOfMeasureCode: string;
}
export interface ItemCreate {
    name: string;
    description: string;
    unitPrice: number;
    unitCost: number;
    unitOfMeasureCode: string;
}
export interface ItemUpdate {
    name: string;
    description: string;
    unitPrice: number;
    unitCost: number;
    unitOfMeasureCode: string;
}
