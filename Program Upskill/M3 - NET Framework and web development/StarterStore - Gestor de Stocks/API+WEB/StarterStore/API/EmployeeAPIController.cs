using System;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarterStore.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private EmployeeViewModel employeeViewModel = new EmployeeViewModel();

        // GET api/Employee
        [HttpGet("/api/Employee")]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return employeeViewModel.ReadAll();
        }

        // GET api/Employee/5
        [HttpGet("/api/Employee/{id}", Name = "GetEmployee")]
        public ActionResult<Employee> Get(int id)
        {
            var item = employeeViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //POST api/Employee
        [HttpPost("/api/Employee/Create")]
        public ActionResult<Category> Create(Employee employee)
        {
            employeeViewModel.Save(employee);
            return new ObjectResult(employee);
        }

        // PUT api/Employee/5
        [HttpPut("/api/Employee/Edit/{id}")]
        public ActionResult<Employee> Put(int id)
        {
            var item = employeeViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            employeeViewModel.Update(item);
            return new ObjectResult(item);
        }


        // DELETE api/Employee/5
        [HttpDelete("/api/Employee/Delete/{id}")]
        public void Delete(int id)
        {
            employeeViewModel.DeleteById(id);
        }
    }
}