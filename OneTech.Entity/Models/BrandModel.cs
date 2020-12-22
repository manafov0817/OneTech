namespace OneTech.Entity.Models
{
    public class BrandModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}