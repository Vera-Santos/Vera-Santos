using System;
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
    public class SupplierController : Controller
    {
        private SupplierViewModel supplierViewModel = new SupplierViewModel();

        // GET: Supplier´s List
        public ActionResult Index()
        {
            return View(supplierViewModel.ReadAll());
        }

        // GET: Create Supplier View
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Supplier
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplierViewModel.Save(supplier);
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplier);
            }
        }

        // POST: Delete Supplier
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            supplierViewModel.DeleteById(id);
            return RedirectToAction("Index");
        }


        // GET: Edit Supplier View
        public ActionResult Edit(int id)
        {
            var supplier = supplierViewModel.GetById(id);
            return View(supplier);
        }

        // POST: Edit Supplier
        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplierViewModel.Update(supplier);
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplier);
            }
        }

        public ActionResult Details(int id)
        {
            var supplier = supplierViewModel.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
    }
}