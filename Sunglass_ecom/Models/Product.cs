using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sunglass_ecom.Models;

public partial class Product
{
    public int Id { get; set; }

    public required string ProductName { get; set; }

    public string? Manufacturer { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? Discount { get; set; }

    public int Quantity { get; set; }

    public required string Imageurl { get; set; }
    [NotMapped]
    public IFormFile? ProductImage {  get; set; }

    public int Status { get; set; }
    public bool IsActive {  get; set; }

    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<OrderItems> OrderItems{get; set;}


}
