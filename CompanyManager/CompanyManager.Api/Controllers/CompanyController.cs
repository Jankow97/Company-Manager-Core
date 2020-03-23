using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CompanyManager.Api.Infrastructure.Dtos.Company.Create;
using CompanyManager.Api.Infrastructure.Dtos.Company.Search;
using CompanyManager.Api.Infrastructure.Dtos.Company.Update;
using CompanyManager.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompanyController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyDto createCompanyDto)
        {
            try
            {
                return Ok();
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
                return Ok();
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
                return Ok();
            }
            catch (Exception ex)
            {
                // Log ex
                return StatusCode(500, "Internal server error");
            }
        }
    }
}