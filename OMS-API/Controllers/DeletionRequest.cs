namespace OMSAPI.Controllers
{
    public class DeletionRequest
    {
        public int IntPk { get; set; }
        public string Pk { get; set; }
        public bool Cascade { get; set; }
    }
}