export interface DatabaseOperationStatus {
    statusOk: boolean;
    tableName: string;
    fieldName: string;
    message: string;
    newRecordId: number;
}
