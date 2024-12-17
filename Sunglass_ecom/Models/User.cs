using System.ComponentModel.DataAnnotations;
using System;

namespace Sunglass_ecom.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Username Field Is Empty")]
        public  string Username { get; set; }
        [Required(ErrorMessage = "Password Field Is Empty")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must be 8 characters long.", MinimumLength = 8)]
        public  string Password { get; set; }
        [Required(ErrorMessage = "Email Field Is Empty")]
        [EmailAddress]
        public  string Email { get; set; }
        [Required(ErrorMessage = "FirstName Field Is Empty")]
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Address { get; set; }
        public  string City { get; set; }
        public  string Zones { get; set; }
        public  string Streets { get; set; }
        [Phone]
        public  string PhoneNumber { get; set; }
        [Required]
        public string Role {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public int cartId{get; set; }
        public bool IsActive { get; set; }
        public virtual Cart Cart{get; set;} 
    }

}
