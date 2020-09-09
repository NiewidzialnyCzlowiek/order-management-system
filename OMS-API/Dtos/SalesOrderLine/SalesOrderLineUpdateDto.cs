namespace OMSAPI.Dtos.SalesOrderLineDtos
{
    public class SalesOrderLineUpdateDto
    {
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public int ItemId { get; set; }
        public int SalesOrderHeaderId { get; set; }
    }
}