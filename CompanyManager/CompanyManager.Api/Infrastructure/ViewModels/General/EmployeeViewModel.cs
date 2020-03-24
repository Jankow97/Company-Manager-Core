using System;
using System.Collections.Generic;
using System.Text;
using CompanyManager.Api.Models.Enums;

namespace CompanyManager.Api.Infrastructure.ViewModels.General
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DateOfBirth { get; set; }
        public Position JobTitle { get; set; }
    }
}
