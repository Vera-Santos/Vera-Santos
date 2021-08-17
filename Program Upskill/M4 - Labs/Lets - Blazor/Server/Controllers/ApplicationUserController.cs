using BlazorLets.Server.Data;
using BlazorLets.Server.Services;
using BlazorLets.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLets.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public ApplicationUserController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //GET: api/ApplicationUser
        [HttpGet]
        public async Task<ActionResult<List<ApplicationUser>>> GetAllApplicationUsers([FromQuery] PaginationDTO pagination, [FromQuery] string name)
        {
            var queryable = _db.ApplicationUser.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                queryable = queryable.Where(x => x.Name.Contains(name));
            }
            await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.QuantityPerPage); // método recebe o objeto resultado da consulta e o nº registro/pág. e retorna a quantidade de páginas necessárias para exibir o resultado da consulta
            return await queryable.Paginate(pagination).ToListAsync(); // o resultado da consulta é materializado na memória
        }

        // GET api/ApplicationUser/5
        [HttpGet("GetApplicationUser/{id}")]
        public async Task<ActionResult<ApplicationUser>> GetApplicationUser(string id)
        {
            try
            {
                var user = await _db.ApplicationUser.FirstOrDefaultAsync(e => e.Id == id);

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados da base de dados");
            }
        }
        //public class ApplicationUserRoles
        //{
        //    public string Nome { get; set; }
        //    public string Email { get; set; }
        //    public string Telemovel { get; set; }
        //    public DateTime DataNascimento { get; set; }
        //    public string Role { get; set; }
        //}

        //[HttpGet("GetApplicationUserWithRole")]
        //public async Task<ActionResult<IEnumerable<ApplicationIdentity>>> GetApplicationUserWithRole()
        //{
        //    try
        //    {
        //        var user = (from x in _db.ApplicationUser
        //                    join y in _db.UserRoles on x.Id equals y.UserId
        //                    join z in _db.Roles on y.RoleId equals z.Id
        //                    select new { x, y, z });/*ApplicationUserRoles { Nome = x.Name, Email = x.Email, Telemovel = x.PhoneNumber, DataNascimento = x.BirthDate, Role = z.Name }).ToListAsync();*/

        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        return user;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //        "Erro ao recuperar dados da base de dados");
        //    }
        //}


        //public class ApplicationUserRoles
        //{
        //    public string Nome { get; set; }
        //    public string Email { get; set; }
        //    public string Telemovel { get; set; }
        //    public DateTime DataNascimento { get; set; }
        //    public string Role { get; set; }
        //}

        [HttpGet("GetApplicationUserWithRole")]
        public async Task<ActionResult<IEnumerable<UserWithRoles>>> GetApplicationUserWithRole()
        {
            try
            {
                var user = await (from x in _db.ApplicationUser
                            join y in _db.UserRoles on x.Id equals y.UserId
                            join z in _db.Roles on y.RoleId equals z.Id
                            select new UserWithRoles{Id=x.Id, Nome = x.Name, Email = x.Email, Telemovel = x.PhoneNumber, DataNascimento = x.BirthDate, Role = z.Name }).ToListAsync();

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }




        [HttpGet("GetApplicationUsers")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetApplicationUsers()
        {
            try
            {
                return await _db.ApplicationUser.ToListAsync();

                //if (user == null)
                //{
                //    return NotFound();
                //}

                //return user;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        [HttpGet("GetUserRoles")]
        public async Task<ActionResult<IEnumerable<IdentityUserRole<string>>>> GetUserRoles()
        {
            try
            {
                return await _db.UserRoles.ToListAsync();

                //if (user == null)
                //{
                //    return NotFound();
                //}

                //return user;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        [HttpGet("GetRoles")]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetRoles()
        {
            try
            {
                var user = await _db.Roles.ToListAsync();

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao recuperar dados da base de dados");
            }
        }

        [HttpPost("EditUserRole/{role}")]
        public async Task<IActionResult> EditUserRole(UserWithRoles user, [FromRoute] string role)
        {
            if (ModelState.IsValid)
            {
                // THIS LINE IS IMPORTANT
                var User = await _userManager.FindByIdAsync(user.Id);
                var oldRoleName = _userManager.GetRolesAsync(User).Result.FirstOrDefault();
       

                var roleExists = await _roleManager.RoleExistsAsync("Admin");
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                if (oldRoleName != role)
                {
                    await _userManager.RemoveFromRoleAsync(User, oldRoleName);
                    await _userManager.AddToRoleAsync(User, role);
                }
                _db.Entry(User).State = EntityState.Modified;

                await _db.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpPost("PostUser")]
        public async Task<ActionResult<ApplicationUser>> PostUser(ApplicationUser user)
        {
           
                //var roleExists = await _roleManager.RoleExistsAsync("Admin");
                //if (!roleExists)
                //{
                //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                //}

            _db.ApplicationUser.Add(user);
            await _db.SaveChangesAsync();

            return NoContent();
        }





        //[HttpPost("EditUserRole/{role}")]
        //public async Task<ActionResult<ApplicationUser>> EditUserRole(UserWithRoles user, [FromRoute] string role)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        var oldUser = await _userManager.FindByIdAsync(user.Id);
        //        var oldRoleId = await _userManager.GetRolesAsync(oldUser);
        //        var oldRoleName = await _db.Roles.SingleOrDefaultAsync(r => r.Id == oldRoleId.FirstOrDefault());



        //        var roleExists = await _roleManager.RoleExistsAsync("Admin");
        //        if (!roleExists)
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //        }

        //        if (oldRoleName.Name != role)
        //        {
        //            await _userManager.RemoveFromRoleAsync(oldUser, oldRoleName.Name);
        //            await _userManager.AddToRoleAsync(oldUser, role);
        //        }
        //        _db.Entry(oldUser).State = EntityState.Modified;

        //        await _db.SaveChangesAsync();
        //    }
        //    return NoContent();
        //}

        // DELETE api/ApplicationUser/5
        [HttpDelete("DeleteApplicationUser/{id}")]
        public async Task<ActionResult<ApplicationUser>> DeleteApplicationUser(string id)
        {
            try
            {
                var user = await _db.ApplicationUser.FindAsync(id);

                if (user == null)
                {
                    return NotFound($"Utilizador com o ID {id} não econtrado");
                }
                else
                {
                    _db.ApplicationUser.Remove(user);
                    await _db.SaveChangesAsync();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao eliminar o Utilizador");
            }
        }

        [HttpGet("GetRole/{id}")]
        public async Task<ActionResult<IdentityRole<string>>> GetRole(string id)
        {
            try
            {
                var roles = await _db.UserRoles.Where(x => x.UserId == id).FirstOrDefaultAsync();
                var userRole = await _db.Roles.Where(x => x.Id == roles.RoleId).FirstOrDefaultAsync();
                return userRole;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter dados da base de dados");
            }
        }
    }
}
