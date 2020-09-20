using OMSAPI.Dtos.ItemDtos;
using OMSAPI.Dtos.SalesOrderHeaderDtos;

namespace OMSAPI.Dtos.SalesOrderLineDtos
{
    public class SalesOrderLineReadFullDto
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public int ItemId { get; set; }
        public ItemReadFullDto Item { get; set; }
        public int SalesOrderHeaderId { get; set; }
    }
}