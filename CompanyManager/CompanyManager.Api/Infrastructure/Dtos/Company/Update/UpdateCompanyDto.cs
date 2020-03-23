using System.Collections.Generic;
using CompanyManager.Api.Infrastructure.Dtos.General;

namespace CompanyManager.Api.Infrastructure.Dtos.Company.Update
{
    public class UpdateCompanyDto
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}
