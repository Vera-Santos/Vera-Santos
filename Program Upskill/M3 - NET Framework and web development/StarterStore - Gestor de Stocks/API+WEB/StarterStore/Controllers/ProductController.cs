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
    public class ProductController : Controller
    {

        private ProductViewModel productViewModel = new ProductViewModel();

        // GET: Product´s List
        public ActionResult Index()
        {
            return View(productViewModel.ReadAll());
        }

        // GET: Create Product View
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Product
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productViewModel.Save(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        // POST: Delete Product
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            productViewModel.DeleteById(id);
            return RedirectToAction("Index");
        }


        // GET: Edit Product View
        public ActionResult Edit(int id)
        {
            var product = productViewModel.GetById(id);
            return View(product);
        }

        // POST: Edit Product
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productViewModel.Update(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult Details(int id)
        {
            var product = productViewModel.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}