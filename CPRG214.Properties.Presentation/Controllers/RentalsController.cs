using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.Properties.Business;
using CPRG214.Properties.Domain;
using CPRG214.Properties.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG214.Properties.Presentation.Controllers
{
    public class RentalsController : Controller
    {

        public IActionResult GetPropertiesByType(int id)
        {
            return ViewComponent("RentalsByType", id);
        }
        public IActionResult Properties(int id)
        {
            // go to the rental manager, get all the rentals of this properties types
            var filteredRentals = RentalsManager.GetAllbyPropertyType(id);
            var result = $"Property Count: {filteredRentals.Count}";
            return Content(result);
        }
        public IActionResult Search()
        {
            ViewBag.PropertyTypes = GetPropertyTypes();
            return View();
        }
        public IActionResult Index()
        {
            var rentals = RentalsManager.GetAll();
            var viewModels = rentals.Select(r => new RenterViewModel
            {
                Id  = r.Id,
                Address = r.Address,
                City = r.City,
                Province = r.Province,
                Rent = r.Rent.ToString(),
                Owner = r.Owner.Name,
                PropertyType=r.PropertyType.Style

            }).ToList();
            // call a local service to get the collection of rentals as the viewmodels
            return View(viewModels);
        }

        public IActionResult Create()
        {
            // call the owner manager and get the collection of key value objects
            var owner = OwnerManager.GetAsKEyValuePairs();
            // create a collection of SelectListItems
            var list = new SelectList(owner, "Value", "Text");
            ViewBag.OwnerId = list;

            //// create the collection of property types select list items
            //var types = PropertyTypeManager.GetAsKEyValuePairs();
            //var styles = new SelectList(types, "Value", "Text");
            ViewBag.PropertyTypeId = GetPropertyTypes();


            // return views
            return View();
        }

        [HttpPost]
        public IActionResult Create(RentalProperty rental)
        {
            try
            {
                RentalsManager.Add(rental);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        protected IEnumerable GetPropertyTypes()
        {
            // create the collection of property types select list items
            var types = PropertyTypeManager.GetAsKEyValuePairs();
            var styles = new SelectList(types, "Value", "Text");
            return styles;
        }
    }
}
