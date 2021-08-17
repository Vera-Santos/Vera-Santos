using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarterStore.Models;
using Microsoft.AspNetCore.Http;

namespace StarterStore.Controllers
{
    public class ShipperController : Controller
    {    
        private ShipperViewModel shipperViewModel = new ShipperViewModel();
    
        // GET: Shipper´s List
        public ActionResult Index()
        {
            return View(shipperViewModel.ReadAll());
        }
        
        // GET: Create Shipper View
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shipper shipper)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    shipperViewModel.Save(shipper);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(shipper);
        }
            

        // POST: Delete Shipper
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            shipperViewModel.DeleteById(id);
            return RedirectToAction("Index");      
        }
        
        // GET: Edit Shipper View
        public ActionResult Edit(int id)
        {
            var shipper = shipperViewModel.GetById(id);
            return View(shipper);
        }

        // POST: Edit Shipper
        [HttpPost]
        public ActionResult Edit(Shipper shipper)
        {
            if (ModelState.IsValid)
            {
                shipperViewModel.Update(shipper);
                return RedirectToAction("Index");
            }
            else
            {
                return View(shipper);
            }
        }
  
        public ActionResult Details(int id)
        {
            var shipper = shipperViewModel.GetById(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return View(shipper);
        }
    }
}
