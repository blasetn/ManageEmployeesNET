using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Employee
{
    public class EmployeeDeleteModel : EmployeeCreateModel
    {
        [Required]
        public int Id { get; set; }
    }
}