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
    public class OrderController : Controller
    {
        private OrderViewModel orderViewModel = new OrderViewModel();

        // GET: Order´s List
        public ActionResult Index()
        {
            return View(orderViewModel.ReadAll());
        }

        // GET: Create Order View
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Order
        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                orderViewModel.Save(order);
                return RedirectToAction("Index");
            }
            else
            {
                return View(order);
            }
        }

        // POST: Delete Order
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            orderViewModel.DeleteById(id);
            return RedirectToAction("Index");
        }


        // GET: Edit Order View
        public ActionResult Edit(int id)
        {
            var order = orderViewModel.GetById(id);
            return View(order);
        }

        // POST: Edit Order
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                orderViewModel.Update(order);
                return RedirectToAction("Index");
            }
            else
            {
                return View(order);
            }
        }

        public ActionResult Details(int id)
        {
            var order = orderViewModel.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
