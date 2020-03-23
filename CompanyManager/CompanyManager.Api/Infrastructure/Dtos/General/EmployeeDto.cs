using System;
using System.Collections.Generic;
using System.Text;
using CompanyManager.Api.Models.Enums;

namespace CompanyManager.Api.Infrastructure.Dtos.General
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int BirthDate { get; set; }
        public Position Position { get; set; }
    }
}
