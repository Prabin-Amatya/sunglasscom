namespace Sunglass_ecom.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CategoryDescription {get; set; }
        public bool IsActive { get; set; }

        public required ICollection<Product> Product { get; set; }
    }
}
