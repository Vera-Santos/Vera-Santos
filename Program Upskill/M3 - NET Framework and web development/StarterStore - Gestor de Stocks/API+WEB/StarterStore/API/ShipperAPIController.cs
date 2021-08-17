
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
    public class ShipperAPIController : ControllerBase
    {
        private ShipperViewModel shipperViewModel = new ShipperViewModel();

        // GET api/Shipper
        [HttpGet("/api/Shipper")]
        public ActionResult<IEnumerable<Shipper>> Get()
        {
            return shipperViewModel.ReadAll();
        }

        // GET api/Shipper/5
        [HttpGet("/api/Shipper/{id}", Name = "GetShipper")]
        public ActionResult<Shipper> Get(int id)
        {
            var item = shipperViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //POST api/Shipper
        [HttpPost("/api/Shipper/Create")]
        public ActionResult<Shipper> Create(Shipper shipper)
        {
            shipperViewModel.Save(shipper);           
            return new ObjectResult(shipper);
        }

        // PUT api/Shipper/5
        [HttpPut("/api/Shipper/Edit/{id}")]
        public ActionResult<Shipper> Put(int id)
        {
            var item = shipperViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            shipperViewModel.Update(item);
            return new ObjectResult(item);
        }
        

        // DELETE api/Shipper/5
        [HttpDelete("/api/Shipper/Delete/{id}")]
        public void Delete(int id)
        {
            shipperViewModel.DeleteById(id);
        }
    }
}