using BlazorLets.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorLets.Shared.Models;
using System.Linq;

namespace BlazorLets.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public LearnController(ApplicationDbContext db)
        {
            _db = db;
        }

        //[HttpGet("Get")]
        //public async Task<ActionResult<IEnumerable<Learn>>> GetLearn()
        //{
        //    return await _db.Learn.ToListAsync();
        //}

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Learn>> GetLearnByID(int id)
        {
            //return await _db.Learn.Where(s => s.SubjectID == id).ToListAsync();
            return await _db.Learn.FirstOrDefaultAsync(x => x.LearnID == id);
        }


        [HttpGet("GetLearnBySubjectID/{id}")]
        public async Task<ActionResult<Learn>> GetLearnBySubjectID(int id)
        {
            //return await _db.Learn.Where(s => s.SubjectID == id).ToListAsync();
            return await _db.Learn.FirstOrDefaultAsync(x => x.SubjectID == id);
        }



        //Acho que nao vamos necessitar disto!
        [HttpPost("Post")]
        public async Task<ActionResult<Learn>> PostLearn([FromBody] Learn obj)
        {
            _db.Add(obj);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("Put")]
        public async Task<ActionResult<Learn>> PutLearn([FromBody] Learn obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Learn>> DeleteLearn(int id)
        {
            Learn obj = await _db.Learn.FindAsync(id);
            _db.Remove(obj);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        
    }
}
