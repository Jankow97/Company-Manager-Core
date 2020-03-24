using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompanyManager.Api.Models
{
    public class Company
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int EstablishmentYear { get; set; }
        [Required]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
