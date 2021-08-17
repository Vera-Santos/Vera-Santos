using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLets.Server.Data;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorLets.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SubjectController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET: api/Subject
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
        {
            try
            {
                return await _db.Subject.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados da base de dados");
            }
        }

        // GET BY ID: api/Subject/1
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            try
            {
                var result = await _db.Subject.FindAsync(id);

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

        [HttpPost("Post")]
        public async Task<ActionResult<Subject>> CreateSubject([FromBody] Subject subject)
        {
            try
            {
                if (subject == null)
                {
                    return BadRequest();
                }
                else
                {
                    _db.Add(subject);
                    await _db.SaveChangesAsync();
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao criar novo Conteúdo");
            }
        }

        [HttpPut("Put/{id}")]
        public async Task<ActionResult<Subject>> UpdateSubject(int id, [FromBody] Subject subject)
        {
            try
            {
                if (id != subject.SubjectID)
                {
                    return BadRequest();
                }
                else if (subject == null)
                {
                    return NotFound($"Conteúdo com o ID {id} não encontrado");
                }
                else
                {
                    _db.Entry(subject).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }

                return CreatedAtAction(nameof(GetSubjectById), new { id = subject.SubjectID }, subject); // retorna o contéudo (alterado e não alterado)
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao atualizar o Conteúdo");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Subject>> DeleteSubject(int id)
        {
            try
            {
                var delete = await _db.Subject.FindAsync(id);

                if (delete == null)
                {
                    return NotFound($"Conteúdo com o ID {id} não econtrado");
                }
                else
                {
                    _db.Subject.Remove(delete);
                    await _db.SaveChangesAsync();
                }

                return delete;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao eliminar o Conteúdo");
            }
        }

        [HttpGet("GetSubjectID/{id}")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjectID(int id)
        {
            try
            {
                return await _db.Subject
                .Include(s => s.CycleGradeCourse)
                .Where(s => s.CycleGradeCourseID == id)
                .ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados da base de dados");
            }
        }

        [HttpGet("GetCycleGradeCourse/{id}")]
        public async Task<ActionResult<CycleGradeCourse>> GetCycleGradeCourse(int id)
        {
            try
            {
                return await _db.CycleGradeCourse.FindAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados da base de dados");
            }
        }

        [HttpGet("GetCycleGradeCourseBySubjectID/{id}")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetCycleGradeCourseBySubjectID(int id)
        {
            try
            {
                return await _db.Subject
                    .Include(s => s.CycleGradeCourse)
                    .Where(s => s.SubjectID == id)
                    .ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados da base de dados");
            }
        }

    }
}