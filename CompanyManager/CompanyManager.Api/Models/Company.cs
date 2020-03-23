using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyManager.Api.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string FirstAndMiddleName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
