using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dto
{
    public class CompanyForCreationDto
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address")]
        [MaxLength(70, ErrorMessage = "Maximum length for the Address is 70 characters.")]
        public string Address { get; set; }
        public string Country { get; set; }
        public IEnumerable<EmployeeForCreationDto> Employees { get; set; }
    }
}
