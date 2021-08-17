using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLets.Server.Data;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorLets.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EnrollmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET: api/Enrollment
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetAllEnrollment()
        {
            try
            {
                return await _db.Enrollment.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        // GET BY ID: api/Enrollment/1
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Enrollment>> GetTestById(int id)
        {
            try
            {
                var result = await _db.Enrollment
                .Include(t => t.Test)
                .Include(t => t.Test.Questions).ThenInclude(t => t.Answers)
                .Include(t => t.Test.Subject)
                .Include(t => t.Test.Subject.CycleGradeCourse)
                .FirstOrDefaultAsync(e => e.EnrollmentID == id);

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

        [HttpGet("GetEnrollmentbyTestID/{id}")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollmentbyTestID(int id)
        {
            try
            {
                return await _db.Enrollment
                .Include(t => t.Test)
                .Include(t => t.Test.Questions).ThenInclude(t => t.Answers)
                .Include(t => t.Test.Subject)
                .Include(t => t.Test.Subject.CycleGradeCourse)
                .Where(s => s.TestID == id)
                .ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        [HttpGet("GetEnrollmentbyApplicationUserID/{id}")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollmentbyApplicationUserID(string id)
        {
            try
            {
                return await _db.Enrollment
                .Include(t => t.Test)
                .Include(t => t.Test.Questions)
                .Include(t => t.Test.Subject)
                .Include(t => t.Test.Subject.CycleGradeCourse)
                .Where(s => s.ApplicationUserID == id)
                .ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        [HttpPost("Post")]
        public async Task<ActionResult<Enrollment>> CreateEnrollment([FromBody] Enrollment enrollment)
        {
            try
            {
                if (enrollment == null)
                {
                    return BadRequest();
                }
                else
                {
                    _db.Add(enrollment);
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
        public async Task<ActionResult<Enrollment>> UpdateTest(int id, [FromBody] Enrollment enrollment)
        {
            try
            {
                var update = await _db.Enrollment.FindAsync(id);

                if (id != enrollment.EnrollmentID)
                {
                    return BadRequest("ID da Matéria incorreto");
                }

                else if (update == null)
                {
                    return NotFound($"Matéria com o ID {id} não encontrada");
                }
                else
                {
                    update.Score = enrollment.Score;
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
        public async Task<ActionResult<Enrollment>> DeleteEnrollment(int id)
        {
            try
            {
                var delete = await _db.Enrollment.FindAsync(id);

                if (delete == null)
                {
                    return NotFound($"Matéria com o ID {id} não econtrada");
                }
                else
                {
                    _db.Enrollment.Remove(delete);
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


