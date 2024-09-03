using System.ComponentModel.DataAnnotations;

namespace WitGeorgiaMVC.ViewsModel
{
    public class Player
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        [Required(ErrorMessage = "Personal number is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Personal number must be exactly 11 characters")]
        public string PersonalNumber { get; set; }
        public int? Salary { get; set; }
        
        [Required(ErrorMessage = "Personal number is required")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Personal number must be exactly 9 characters")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Birth Day is required!")]
        public DateTime Birthday { get; set; }
        public DateTime DeletedDate { get; set; } = DateTime.UtcNow;
    }
}
