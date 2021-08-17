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
    public class ProductAPIController : ControllerBase
    {
        private ProductViewModel productViewModel = new ProductViewModel();

        // GET api/Product
        [HttpGet("/api/Product")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return productViewModel.ReadAll();
        }

        // GET api/Product/5
        [HttpGet("/api/Product/{id}", Name = "GetProduct")]
        public ActionResult<Product> Get(int id)
        {
            var item = productViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //POST api/Product
        [HttpPost("/api/Product/Create")]
        public ActionResult<Product> Create(Product product)
        {
            productViewModel.Save(product);
            return new ObjectResult(product);
        }

        // PUT api/Product/5
        [HttpPut("/api/Product/Edit/{id}")]
        public ActionResult<Product> Put(int id)
        {
            var item = productViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            productViewModel.Update(item);
            return new ObjectResult(item);
        }


        // DELETE api/Product/5
        [HttpDelete("/api/Product/Delete/{id}")]
        public void Delete(int id)
        {
            productViewModel.DeleteById(id);
        }
    }
}