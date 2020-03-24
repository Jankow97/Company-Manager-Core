using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CompanyManager.Api.Models.Enums;

namespace CompanyManager.Api.Models
{
    public class Employee
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public Position JobTitle { get; set; }
    }
}
