using CPRG214.Properties.Business;
using CPRG214.Properties.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Properties.Presentation.ViewComponents
{
    public class RentalsByTypeViewComponent :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<RentalProperty> properties = null;

            properties = RentalsManager.GetAll();


            return View();
        }
    }
}
