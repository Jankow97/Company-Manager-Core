using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyManager.Api.Infrastructure.Dtos.General;

namespace CompanyManager.Api.Infrastructure.Dtos.Company.Create
{
    public class CreateCompanyDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int EstablishmentYear { get; set; }
        [Required]
        public List<EmployeeDto> Employees { get; set; }
    }
}
