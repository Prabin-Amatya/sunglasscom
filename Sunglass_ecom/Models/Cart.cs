namespace Sunglass_ecom.Models
{
    
  
        public class Cart
        {
            public int Id { get; set; } // Primary key
            public decimal UnitPrice { get; set; }
            public decimal? Discount { get; set; }
            public int Quantity { get; set; }
            public decimal TotalPrice { get; set; }
            public bool IsActive { get; set; }
            public virtual User User { get; set; }
            public virtual ICollection<OrderItems> OrderItems { get; set; }
        // Add other properties as needed
    }

    
}
