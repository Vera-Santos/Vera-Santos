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
    public class OrderAPIController : ControllerBase
    {
        private OrderViewModel orderViewModel = new OrderViewModel();

        // GET api/Order
        [HttpGet("/api/Order")]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return orderViewModel.ReadAll();
        }

        // GET api/Order/5
        [HttpGet("/api/Order/{id}", Name = "GetOrder")]
        public ActionResult<Order> Get(int id)
        {
            var item = orderViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //POST api/Order
        [HttpPost("/api/Order/Create")]
        public ActionResult<Category> Create(Order order)
        {
            orderViewModel.Save(order);
            return new ObjectResult(order);
        }

        // PUT api/Order/5
        [HttpPut("/api/Order/Edit/{id}")]
        public ActionResult<Order> Put(int id)
        {
            var item = orderViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            orderViewModel.Update(item);
            return new ObjectResult(item);
        }


        // DELETE api/Order/5
        [HttpDelete("/api/Order/Delete/{id}")]
        public void Delete(int id)
        {
            orderViewModel.DeleteById(id);
        }
    }
}