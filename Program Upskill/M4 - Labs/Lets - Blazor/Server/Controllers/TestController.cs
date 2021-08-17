using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLets.Server.Data;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlazorLets.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
         private readonly ApplicationDbContext _db;

        public TestController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET: api/Test
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Test>>> GetAllTests()
        {
            try
            {
                return await _db.Test
                     .Include(t => t.Questions).ThenInclude(t => t.Answers)
                     .Include(t => t.Subject)
                     .Include(t => t.Subject.CycleGradeCourse)
                     .ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        // GET BY ID: api/Test/1
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Test>> GetTestById(int id)
        {
            try
            {
                var result = await _db.Test
                    .Include(t => t.Subject)
                    .Include(t => t.Questions).ThenInclude(t => t.Answers)
                    .FirstOrDefaultAsync(t => t.TestID == id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }
        
        [HttpGet("GetTestBySubjectID/{id}")]
        public async Task<ActionResult<IEnumerable<Test>>> GetTestByTestID(int id)
        {
            try
            {
                return await _db.Test
                .Include(t => t.Subject)
                .Include(t => t.Questions).ThenInclude(t => t.Answers)
                .Where(s => s.SubjectID == id)
                .ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }



        [HttpPost("Post")]
        public async Task<ActionResult<Test>> CreateTest([FromBody] Test test)
        {
            try
            {
                if (test == null)
                {
                    return BadRequest();
                }
                else
                {
                    _db.Add(test);
                    await _db.SaveChangesAsync();
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao criar nova Matéria");
            }
        }

        [HttpPut("Put")]
        public async Task<ActionResult<Test>> UpdateTest(int id, [FromBody] Test test)
        {
            try
            {
                var update = await _db.Test.FindAsync(id);

                if (id != test.TestID)
                {
                    return BadRequest("ID da Matéria incorreto");
                }

                else if (update == null)
                {
                    return NotFound($"Matéria com o ID {id} não encontrada");
                }
                else
                {
                    update.MinimalScore = test.MinimalScore;
                    await _db.SaveChangesAsync();
                }

                return update;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao atualizar a Matéria");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Test>> DeleteTest(int id)
        {
            try
            {
                var delete = await _db.Test.FindAsync(id);

                if (delete == null)
                {
                    return NotFound($"Matéria com o ID {id} não econtrada");
                }
                else
                {
                    _db.Test.Remove(delete);
                    await _db.SaveChangesAsync();
                }

                return delete;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao eliminar a Matéria");
            }
        }
    }
}
