using System.ComponentModel.DataAnnotations;

namespace Sunglass_ecom.Models
{
    public class OrderItems
    {
        public int Id { get; set; } // Primary key
        public int CartId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal SubTotal {  get; set; }
        public string status {  get; set; }
        public bool isActive {  get; set; }

        public virtual Cart Cart{get; set;}
        public virtual Product Product{get; set;}

    }
}
