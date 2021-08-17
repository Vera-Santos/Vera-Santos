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
    public class CategoryAPIController : ControllerBase
    {
        private CategoryViewModel categoryViewModel = new CategoryViewModel();

        // GET api/Category
        [HttpGet("/api/Category")]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return categoryViewModel.ReadAll();
        }

        // GET api/Category/5
        [HttpGet("/api/Category/{id}", Name = "GetCategory")]
        public ActionResult<Category> Get(int id)
        {
            var item = categoryViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //POST api/Category
        [HttpPost("/api/Category/Create")]
        public ActionResult<Category> Create(Category category)
        {
            categoryViewModel.Save(category);           
            return new ObjectResult(category);
        }

        // PUT api/Category/5
        [HttpPut("/api/Category/Edit/{id}")]
        public ActionResult<Category> Put(int id)
        {
            var item = categoryViewModel.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            categoryViewModel.Update(item);
            return new ObjectResult(item);
        }


        // DELETE api/Category/5
        [HttpDelete("/api/Category/Delete/{id}")]
        public void Delete(int id)
        {
            categoryViewModel.DeleteById(id);
        }
    }
}