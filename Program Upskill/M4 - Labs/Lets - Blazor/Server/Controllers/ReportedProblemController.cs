using System;
using System.Collections.Generic;
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
    public class ReportedProblemController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ReportedProblemController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET: api/ReportedProblem
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<ReportedProblem>>> GetAllReportedProblems()
        {
            try
            {
                return await _db.ReportedProblem.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados");
            }
        }

        // GET BY ID: api/ReportedProblem/1
        [HttpGet("GetReportedProblemByID/{id}")]
        public async Task<ActionResult<ReportedProblem>> GetReportedProblemById(int id)
        {
            try
            {
                var result = await _db.ReportedProblem.FindAsync(id);

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
        public async Task<ActionResult<ReportedProblem>> PostReportedProblem([FromBody] ReportedProblem reportedProblem)
        {
            try
            {
                if (reportedProblem == null)
                {
                    return BadRequest();
                }
                else
                {
                    _db.Add(reportedProblem);
                    await _db.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetAllReportedProblems), new { id = reportedProblem.ReportedProblemID }, reportedProblem); // retorna o contéudo inserido na DB
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao reportar novo problema");
            }
        }

        [HttpPut("Put/{id}")]
        public async Task<ActionResult<ReportedProblem>> UpdateReportedProblem(int id, [FromBody] ReportedProblem reportedProblem)
        {
            try
            {
                if (id != reportedProblem.ReportedProblemID)
                {
                    return BadRequest();
                }
                else if (reportedProblem == null)
                {
                    return NotFound($"Problema reportado com o ID {id} não encontrado");
                }
                else
                {
                    _db.Entry(reportedProblem).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }

                return CreatedAtAction(nameof(GetReportedProblemById), new { id = reportedProblem.ReportedProblemID }, reportedProblem); // retorna o contéudo (alterado e não alterado) na DB
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao atualizar o Problema reportado");
            }
        }

    }
}
