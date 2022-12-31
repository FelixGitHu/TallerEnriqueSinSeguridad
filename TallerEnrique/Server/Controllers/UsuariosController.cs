using TallerEnrique.Server.Helpers;
using TallerEnrique.Shared.Complement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerEnrique.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsuariosController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]//Listado de Usuarios 
        public async Task<ActionResult<List<UsuarioDTO>>> GetUsuario()
        {
            var queryable = context.Users.AsQueryable();
            
            return await context.Users
                .Select(x => new UsuarioDTO { Email = x.Email, UserId = x.Id, UserName = x.UserName, UserLastName = x.NormalizedUserName }).ToListAsync();
        }

        [HttpGet("roles")]//Listado de Roles
        public async Task<ActionResult<List<RolDTO>>> Get()
        {
            return await context.Roles
                .Select(x => new RolDTO { Nombre = x.Name, RoleId = x.Id }).ToListAsync();
        }

        [HttpPost("asignarRol")]
        public async Task<ActionResult> AsignarRolUsuario(EditarRolDTO editarRolDTO)
        {
            var usuario = await userManager.FindByIdAsync(editarRolDTO.UserId);
            await userManager.AddToRoleAsync(usuario, editarRolDTO.RoleId);
            return NoContent();
        }

        [HttpPost("removerRol")]
        public async Task<ActionResult> RemoverUsuarioRol(EditarRolDTO editarRolDTO)
        {
            var usuario = await userManager.FindByIdAsync(editarRolDTO.UserId);
            await userManager.RemoveFromRoleAsync(usuario, editarRolDTO.RoleId);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var existe = await context.Users.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new IdentityUser { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
