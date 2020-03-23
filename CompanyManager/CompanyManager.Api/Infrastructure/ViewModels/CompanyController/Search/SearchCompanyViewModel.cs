using System;
using System.Collections.Generic;
using System.Text;
using CompanyManager.Api.Infrastructure.ViewModels.General;

namespace CompanyManager.Api.Infrastructure.ViewModels.CompanyController.Search
{
    public class SearchCompanyViewModel
    {
        public List<CompanyViewModel> Results { get; set; }
    }
}
