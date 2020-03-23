using System;
using System.Collections.Generic;
using CompanyManager.Api.Models.Enums;

namespace CompanyManager.Api.Infrastructure.Dtos.Company.Search
{
    public class SearchCompanyDto
    {
        public string Keyword { get; set; }
        public DateTime EmployeeDateOfBirthFrom { get; set; }
        public DateTime EmployeeDateOfBirthTo { get; set; }
        public List<Position> EmployeeJobTitles { get; set; }
    }
}
