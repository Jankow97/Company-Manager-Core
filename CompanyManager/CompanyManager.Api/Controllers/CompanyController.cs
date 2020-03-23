using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CompanyManager.Api.Infrastructure.Dtos.CompanyController.Create;
using CompanyManager.Api.Infrastructure.Dtos.CompanyController.Search;
using CompanyManager.Api.Infrastructure.Dtos.CompanyController.Update;
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
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchCompanyDto searchCompanyDto)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyDto createCompanyDto)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}