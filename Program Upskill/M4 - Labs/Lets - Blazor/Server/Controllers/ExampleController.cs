using BlazorLets.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorLets.Shared.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace BlazorLets.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {

        private readonly ApplicationDbContext _db;

        public ExampleController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/Example
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Example>>> GetAllExamples()
        {
            try
            {
                return await _db.Example.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        // GET api/Example/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Example>> GetExample(int id)
        {
            try
            {
                var example = await _db.Example.FirstOrDefaultAsync(e => e.ExampleID == id);

                if (example == null)
                {
                    return NotFound();
                }

                return example;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        // GET api/Example/GetExampleBySubjectID/5
        [HttpGet("GetExampleBySubjectID/{id}")]
        public async Task<ActionResult<Example>> GetExampleBySubjectID(int id)
        {
            try
            {
                var example = await _db.Example.FirstOrDefaultAsync(e => e.SubjectID == id);

                if (example == null)
                {
                    return NotFound();
                }

                return example;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        // POST api/Example
        [HttpPost]
        public async Task<ActionResult<Example>> PostExample([FromBody] Example example)
        {
            try
            {
                if (example == null)
                {
                    return BadRequest();
                }
                else
                {
                    _db.Example.Add(example);
                    await _db.SaveChangesAsync();

                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao criar novo Exemplo");
            }
        }

        // PUT api/Example/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Example>> PutExample(int id, [FromBody] Example example)
        {
            try
            {
                if (id != example.ExampleID)
                {
                    return BadRequest();
                }
                else if (example == null)
                {
                    return NotFound($"Exemplo com o ID {id} não encontrado");
                }
                else
                {
                    _db.Entry(example).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao atualizar o Exemplo");
            }
        }

        // DELETE api/Example/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Example>> DeleteExample(int id)
        {
            try
            {
                var example = await _db.Example.FindAsync(id);

                if (example == null)
                {
                    return NotFound($"Exemplo com o ID {id} não econtrado");
                }
                else
                {
                    _db.Example.Remove(example);
                    await _db.SaveChangesAsync();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao eliminar o Exemplo");
            }
        }
    }
}











//update.Image = null;
//update.Image = new byte[0];
//update.Image = Array.Empty<byte>();