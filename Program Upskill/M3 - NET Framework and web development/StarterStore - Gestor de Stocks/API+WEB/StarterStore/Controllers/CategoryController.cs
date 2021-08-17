using System;
using System.Web;
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
    public class CategoryController : Controller
    {
        private CategoryViewModel categoryViewModel = new CategoryViewModel();

        // GET: Category´s List
        public ActionResult Index()
        {
            return View(categoryViewModel.ReadAll());
        }

        // GET: Create Category View
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Category
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryViewModel.Save(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }


        // POST: Delete Category
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            categoryViewModel.DeleteById(id);
            return RedirectToAction("Index");
        }


        // GET: Edit Category View
        public ActionResult Edit(int id)
        {
            var category = categoryViewModel.GetById(id);
            return View(category);
        }

        // POST: Edit Category
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryViewModel.Update(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        public ActionResult Details(int id)
        {
            var category = categoryViewModel.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }


    }
}