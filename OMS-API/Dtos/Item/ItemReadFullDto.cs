using OMSAPI.Models;

namespace OMSAPI.Dtos.ItemDtos
{
    public class ItemReadFullDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set;}
    }
}