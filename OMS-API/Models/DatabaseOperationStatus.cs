namespace OMSAPI.Models
{   
    public class DatabaseOperationStatus
    {
        public bool StatusOk { get; set; }
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string Message { get; set; }
        public int NewRecordId { get; set; }
    }
}