using System.Collections.Generic;
using CompanyManager.Api.Infrastructure.Dtos.General;

namespace CompanyManager.Api.Infrastructure.Dtos.Company.Create
{
    public class CreateCompanyDto
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}
