using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.Properties.Business;
using CPRG214.Properties.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.Properties.Presentation.Controllers
{
    public class OwnerController : Controller
    {
        // GET: OwnerController
        public ActionResult Index()
        {
            var owners = OwnerManager.GetAll();
            return View(owners);
        }


        // GET: OwnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            try
            {
                //call the OwnerManager to ADD
                OwnerManager.Add(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var owner = OwnerManager.Find(id);
            return View(owner);
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Owner owner)
        {
            try
            {
                //call the OwnerManager to EDIT
                OwnerManager.Update(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
