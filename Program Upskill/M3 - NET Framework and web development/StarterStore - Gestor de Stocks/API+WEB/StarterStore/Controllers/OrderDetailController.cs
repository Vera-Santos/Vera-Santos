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
    public class OrderDetailController : Controller
    {
        private OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel();

        // GET: OrderDetail´s List
        public ActionResult Index()
        {
            return View(orderDetailViewModel.ReadAll());
        }

        // GET: Create OrderDetail View
        /*public ActionResult Create()
        {
            return View();
        }

        // POST: Create OrderDetail
        [HttpPost]
        public ActionResult Create(OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                orderDetailViewModel.Save(orderDetail);
                return RedirectToAction("Index");
            }
            else
            {
                return View(orderDetail);
            }
        }

        // POST: Delete OrderDetail
        //[HttpPost]
        public ActionResult Delete(int orderid, int productid)
        {
            orderDetailViewModel.Delete(orderid, productid);
            return RedirectToAction("Index");
        }


        // GET: Edit OrderDetail View
        public ActionResult Edit(int orderid, int productid)
        {
            var orderDetail = orderDetailViewModel.GetBy(orderid, productid);
            return View(orderDetail);
        }

        // POST: Edit OrderDetail
        [HttpPost]
        public ActionResult Edit(OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                orderDetailViewModel.Update(orderDetail);
                return RedirectToAction("Index");
            }
            else
            {
                return View(orderDetail);
            }
        }

        public ActionResult Details(int orderid, int productid)
        {
            var orderDetail = orderDetailViewModel.GetBy(orderid, productid);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }*/
    }
}