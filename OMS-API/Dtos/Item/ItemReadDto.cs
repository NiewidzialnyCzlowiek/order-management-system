using OMSAPI.Models;

namespace OMSAPI.Dtos.ItemDtos
{
    public class ItemReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasureCode { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set;}
    }
}