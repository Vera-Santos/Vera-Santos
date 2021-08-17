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
    public class SupplierAPIController : ControllerBase
    {
        private SupplierViewModel supplierViewModel = new SupplierViewModel();

        // GET api/Supplier
        [HttpGet("/api/Supplier")]
        public ActionResult<IEnumerable<Supplier>> Get()
        {
            return supplierViewModel.ReadAll();
        }

        // GET api/Supplier/5
        [HttpGet("/api/Supplier/{id}", Name = "GetSupplier")]
        public ActionResult<Category> Get(int id)
        {
            var item = supplierViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //POST api/Supplier
        [HttpPost("/api/Supplier/Create")]
        public ActionResult<Supplier> Create(Supplier supplier)
        {
            supplierViewModel.Save(supplier);
            return new ObjectResult(supplier);
        }

        // PUT api/Supplier/5
        [HttpPut("/api/Supplier/Edit/{id}")]
        public ActionResult<Supplier> Put(int id)
        {
            var item = supplierViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            supplierViewModel.Update(item);
            return new ObjectResult(item);
        }


        // DELETE api/Supplier/5
        [HttpDelete("/api/Supplier/Delete/{id}")]
        public void Delete(int id)
        {
            supplierViewModel.DeleteById(id);
        }
    }
}