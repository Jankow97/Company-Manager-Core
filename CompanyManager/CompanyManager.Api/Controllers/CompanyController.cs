using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManager.Api.Infrastructure.Dtos.Company.Create;
using CompanyManager.Api.Infrastructure.Dtos.Company.Search;
using CompanyManager.Api.Infrastructure.Dtos.Company.Update;
using CompanyManager.Api.Infrastructure.ViewModels.CompanyController.Create;
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
                Company companyToCreate = new Company()
                {
                    Name = createCompanyDto.Name,
                    EstablishmentYear = createCompanyDto.EstablishmentYear,
                    Employees = new List<Employee>()
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
                dbContext.Companies.Where(x =>
                    x.Name.Contains(searchCompanyDto.Keyword));
                dbContext.Companies.Where(x =>
                    x.Employees.Any(e => e.Name.Contains(searchCompanyDto.Keyword)));
                dbContext.Companies.Where(x =>
                    x.Employees.Any(e => e.LastName.Contains(searchCompanyDto.Keyword)));
                //dbContext.Companies.Where(x =>
                //    x.Employees.Any(e => e.BirthDate < searchCompanyDto.EmployeeDateOfBirthTo.Year));

                return Ok();
            }
            catch (Exception ex)
            {
                // Log ex
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyDto createCompanyDto)
        {
            try
            {
                Company companyToUpdate = dbContext.Companies.SingleOrDefault(x => x.Id == id);
                if (companyToUpdate == null)
                {
                    return BadRequest("Specified company not found.");
                }
                dbContext.Companies.Update(companyToUpdate);
                await dbContext.SaveChangesAsync();
                return Ok("Specified company has been updated.");
            }
            catch (Exception ex)
            {
                // Log ex
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
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
    }
}