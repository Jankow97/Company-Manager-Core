using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManager.Api.Infrastructure.Dtos.Company.Create;
using CompanyManager.Api.Infrastructure.Dtos.Company.Search;
using CompanyManager.Api.Infrastructure.Dtos.Company.Update;
using CompanyManager.Api.Infrastructure.Dtos.General;
using CompanyManager.Api.Infrastructure.ViewModels.CompanyController.Create;
using CompanyManager.Api.Migrations;
using CompanyManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompanyController : Controller
    {
        private CompanyDbContext dbContext;
        public CompanyController(CompanyDbContext companyDbContext)
        {
            dbContext = companyDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyDto createCompanyDto)
        {
            try
            {
                List<Employee> employees;
                ConvertListEmpDtoToListEmp(createCompanyDto.Employees, out employees);

                Company companyToCreate = new Company()
                {
                    Name = createCompanyDto.Name,
                    EstablishmentYear = createCompanyDto.EstablishmentYear,
                    Employees = employees
                };
                dbContext.Companies.Add(companyToCreate);
                await dbContext.SaveChangesAsync();
                var result = new CreateCompanyViewModel() {Id = companyToCreate.Id};
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log ex
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchCompanyDto searchCompanyDto)
        {
            try
            {
                IQueryable<Company> result = Enumerable.Empty<Company>().AsQueryable();
                if (searchCompanyDto.Keyword != null)
                {
                    result = result.Union(dbContext.Companies.Where(x =>
                        x.Name.Contains(searchCompanyDto.Keyword)));
                    result = result.Union(dbContext.Companies.Where(x =>
                        x.Employees.Any(e => e.Name.Contains(searchCompanyDto.Keyword))));
                    result = result.Union(dbContext.Companies.Where(x =>
                        x.Employees.Any(e => e.LastName.Contains(searchCompanyDto.Keyword))));
                }

                if (searchCompanyDto.EmployeeDateOfBirthFrom != null || searchCompanyDto.EmployeeDateOfBirthTo != null)
                {
                    result = result.Union(dbContext.Companies.Where(x =>
                        x.Employees.Any(e =>
                            (searchCompanyDto.EmployeeDateOfBirthTo == null ? true : (e.BirthDate < searchCompanyDto.EmployeeDateOfBirthTo)) &&
                            (searchCompanyDto.EmployeeDateOfBirthFrom == null ? true :e.BirthDate > searchCompanyDto.EmployeeDateOfBirthFrom))));
                }

                if (searchCompanyDto.EmployeeJobTitles != null)
                {
                    result = result.Union(dbContext.Companies.Where(x =>
                        x.Employees.Any(e =>
                            searchCompanyDto.EmployeeJobTitles.Contains(e.JobTitle))));
                }

                var returnObject = result.ToList();

                return Ok(returnObject);
            }
            catch (Exception ex)
            {
                // Log ex
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyDto UpdateCompanyDto)
        {
            try
            {
                List<Employee> employees;
                ConvertListEmpDtoToListEmp(UpdateCompanyDto.Employees, out employees);
                Company companyToUpdate = dbContext.Companies.SingleOrDefault(x => x.Id == id);

                if (companyToUpdate == null)
                {
                    return BadRequest("Specified company not found.");
                }
                companyToUpdate.Name = UpdateCompanyDto.Name;
                companyToUpdate.EstablishmentYear = UpdateCompanyDto.EstablishmentYear;
                companyToUpdate.Employees = employees;

                await dbContext.SaveChangesAsync();

                return Ok("Specified company has been updated.");
            }
            catch (Exception ex)
            {
                // Log ex
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Company companyToRemove = dbContext.Companies.SingleOrDefault(x => x.Id == id);
                if (companyToRemove == null)
                {
                    return BadRequest("Specified company not found.");
                }
                dbContext.Companies.Remove(companyToRemove);
                await dbContext.SaveChangesAsync();
                return Ok("Specified company has been removed.");
            }
            catch (Exception ex)
            {
                // Log ex
                return StatusCode(500, "Internal server error");
            }
        }

        private bool ConvertListEmpDtoToListEmp(List<EmployeeDto> employeeDtos, out List<Employee> employees)
        {
            try
            {
                employees = new List<Employee>();
                foreach (var emp in employeeDtos)
                {
                    employees.Add(new Employee()
                    {
                        BirthDate = DateTime.ParseExact(emp.BirthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        JobTitle = emp.JobTitle,
                        LastName = emp.LastName,
                        Name = emp.Name
                    });
                }

                return true;
            }
            catch (Exception e)
            {
                employees = null;
                // log e
                return false;
            }
        }
    }
}