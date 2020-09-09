namespace OMSAPI.Dtos.AddressDtos
{
    public class AddressReadFullDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNo { get; set; }
        public string AppartmentNo { get; set; }
        public int CustomerId { get; set; }
    }
}