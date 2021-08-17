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
    public class QuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public QuestionController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET: api/Question
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestions()
        {
            try
            {
                return await _db.Question
                     .Include(t => t.Answers)
                     .ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        // GET BY ID: api/Question/1
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Question>> GetQuestionById(int id)
        {
            try
            {
                var result = await _db.Question
                    .Include(s => s.Answers)
                    .FirstOrDefaultAsync(e => e.QuestionID == id);
                    

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
        public async Task<ActionResult<Question>> CreateQuestion([FromBody] Question question)
        {
            try
            {
                if (question == null)
                {
                    return BadRequest();
                }
                else
                {
                    _db.Add(question);
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

        // PUT api/Example/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Question>> PutExample(int id, [FromBody] Question question)
        {
            try
            {
                if (id != question.QuestionID)
                {
                    return BadRequest();
                }
                else if (question == null)
                {
                    return NotFound($"Exemplo com o ID {id} não encontrado");
                }
                else
                {
                    _db.Entry(question).State = EntityState.Modified;
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


        //[HttpPut("Put")]
        //public async Task<ActionResult<Question>> UpdateQuestion(int id, [FromBody] Question question)
        //{
        //    try
        //    {
        //        var update = await _db.Question.FindAsync(id);

        //        if (id != question.QuestionID)
        //        {
        //            return BadRequest("ID da Matéria incorreto");
        //        }

        //        else if (update == null)
        //        {
        //            return NotFound($"Matéria com o ID {id} não encontrada");
        //        }
        //        else
        //        {
        //            update.QuestionText = question.QuestionText;
        //            await _db.SaveChangesAsync();
        //        }

        //        return update;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //        "Erro ao atualizar a Matéria");
        //    }
        //}

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Question>> DeleteQuestion(int id)
        {
            try
            {
                var delete = await _db.Question.FindAsync(id);

                if (delete == null)
                {
                    return NotFound($"Matéria com o ID {id} não econtrada");
                }
                else
                {
                    _db.Question.Remove(delete);
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

        [HttpGet("GetQuestionByTestID/{id}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionByTestID(int id)
        {
            try
            {
                return await _db.Question
                .Include(s => s.Answers)
                .Where(s => s.TestID == id)
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