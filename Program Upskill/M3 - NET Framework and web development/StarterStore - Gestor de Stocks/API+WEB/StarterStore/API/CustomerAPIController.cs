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
    public class CustomerAPIController : ControllerBase
    {
        private CustomerViewModel customerViewModel = new CustomerViewModel();

        // GET api/Customer
        [HttpGet("/api/Customer")]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return customerViewModel.ReadAll();
        }

        // GET api/Customer/5
        [HttpGet("/api/Customer/{id}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var item = customerViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //POST api/Customer
        [HttpPost("/api/Customer/Create")]
        public ActionResult<Shipper> Create(Customer customer)
        {
            customerViewModel.Save(customer);
            return new ObjectResult(customer);
        }

        // PUT api/Customer/5
        [HttpPut("/api/Customer/Edit/{id}")]
        public ActionResult<Category> Put(string id)
        {
            var item = customerViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            customerViewModel.Update(item);
            return new ObjectResult(item);
        }


        // DELETE api/Customer/5
        [HttpDelete("/api/Customer/Delete/{id}")]
        public void Delete(string id)
        {
            customerViewModel.DeleteById(id);
        }
    }
}