using System.ComponentModel.DataAnnotations;

namespace Sunglass_ecom.Models
{
    public class PlaceOrderRequest
    {
        public int CustomerId { get; set; }
        public List<OrderItems> Items { get; set; }
        public int UserId { get;  set; }
        public object TotalAmount { get;  set; }
        public string ProductName { get; internal set; }
    }
    public class OrderItemRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}
