using CPRG214.Properties.Business;
using CPRG214.Properties.Domain;
using CPRG214.Properties.Presentation.Models;
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

            if (id == 0)
            {
                properties = RentalsManager.GetAll();
            }

            else
            {
                properties = RentalsManager.GetAllbyPropertyType(id);
            }
            // transformation to View Model 
            var rentals = properties.Select(p=> new RenterViewModel
            { 
                Address = p.Address,
                City = p.City,
                Id = p.Id,
                Owner = p.Owner.Name,
                PropertyType = p.PropertyType.Style,
                Province = p.Province,
                Rent = p.Rent.ToString()
            }).ToList();

            return View(rentals);
        }
    }
}
