using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Employee
{
    public class EmployeeCreateModel
    {
        [Required(ErrorMessage = "Minimum 1 and maximum 50 characters")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minimum 5 and maximum 50 characters")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Minimum 5 and maximum 50 characters")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minimum 5 and maximum 50 characters")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone Number is 10 characters")]
        [RegularExpression(@"^\d{10}$",
         ErrorMessage = "Phone Number is 10 characters")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}