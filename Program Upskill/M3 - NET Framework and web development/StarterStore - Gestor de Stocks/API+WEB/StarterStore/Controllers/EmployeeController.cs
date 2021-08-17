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
    public class EmployeeController : Controller
    {

        private EmployeeViewModel employeeViewModel = new EmployeeViewModel();

        // GET: Employee´s List
        public ActionResult Index()
        {
            return View(employeeViewModel.ReadAll());
        }

        // GET: Create Employee View
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Employee
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeViewModel.Save(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }

        // POST: Delete Employee
        //[HttpPost]
        public ActionResult Delete(int id)
        {
            employeeViewModel.DeleteById(id);
            return RedirectToAction("Index");
        }


        // GET: Edit Employee View
        public ActionResult Edit(int id)
        {
            var employee = employeeViewModel.GetById(id);
            return View(employee);
        }

        // POST: Edit Employee
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeViewModel.Update(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }

        public ActionResult Details(int id)
        {
            var employee = employeeViewModel.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
    }
}
