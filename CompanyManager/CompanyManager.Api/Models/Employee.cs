using System;
using System.Collections.Generic;
using System.Text;
using CompanyManager.Api.Models.Enums;

namespace CompanyManager.Api.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int BirthDate { get; set; }
        public Position JobTitle { get; set; }
    }
}
