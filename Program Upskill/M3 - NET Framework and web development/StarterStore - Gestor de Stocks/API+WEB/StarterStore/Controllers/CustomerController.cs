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
    public class CustomerController : Controller
    {

        private CustomerViewModel customerViewModel = new CustomerViewModel();

        // GET: Customer´s List
        public ActionResult Index()
        {
            return View(customerViewModel.ReadAll());
        }

        // GET: Create Customer View
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Customer
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerViewModel.Save(customer);
                return RedirectToAction("Index");
            }
            else
            {
                return View(customer);
            }
        }

        // POST: Delete Customer
        //[HttpPost]
        public ActionResult Delete(string id)
        {
            customerViewModel.DeleteById(id);
            return RedirectToAction("Index");
        }


        // GET: Edit Customer View
        public ActionResult Edit(string id)
        {
            var customer = customerViewModel.GetById(id);
            return View(customer);
        }

        // POST: Edit Customer
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customerViewModel.Update(customer);
                return RedirectToAction("Index");
            }
            else
            {
                return View(customer);
            }
        }

        public ActionResult Details(string id)
        {
            var customer = customerViewModel.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
    }
}