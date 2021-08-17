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
    public class OrderDetailAPIController : ControllerBase
    {
        private OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel();

        // GET api/OrderDetail
        [HttpGet("/api/OrderDetail")]
        public ActionResult<IEnumerable<OrderDetail>> Get()
        {
            return orderDetailViewModel.ReadAll();
        }
    }
}