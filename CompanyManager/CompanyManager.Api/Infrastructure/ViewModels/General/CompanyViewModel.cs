using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyManager.Api.Infrastructure.ViewModels.General
{
    public class CompanyViewModel
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public virtual ICollection<EmployeeViewModel> Employees { get; set; }
    }
}
