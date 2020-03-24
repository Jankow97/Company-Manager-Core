using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CompanyManager.Api.Models.Enums;

namespace CompanyManager.Api.Infrastructure.Dtos.General
{
    public class EmployeeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public Position JobTitle { get; set; }
    }
}
