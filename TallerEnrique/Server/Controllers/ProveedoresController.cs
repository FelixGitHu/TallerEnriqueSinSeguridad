using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerEnrique.Client.Shared;
using TallerEnrique.Server.Helpers;
using TallerEnrique.Shared.Entidades;
using TallerEnrique.Shared.Complement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TallerEnrique.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,vendedor")]
    public class ProveedoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ProveedoresController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Proveedor proveedor)
        {
            if (!Exists(proveedor.Email))
            {
                context.Add(proveedor);
                await context.SaveChangesAsync();
                return proveedor.Id;
            }
            else
            {
                return BadRequest("El proveedor ya existe.");
            }
            
        }
        //generico Este metodo esta de mas al igual que los demas get que estan en el resto de contraladores
        [HttpGet("cargartodos")]
        public async Task<ActionResult<List<Proveedor>>> Get()
        {
            return await context.Proveedors.Where(x=> x.Estado == true).ToListAsync();
        }
        [HttpGet("proveedorinactivo")]
        public async Task<ActionResult<List<Proveedor>>> GetInactivo()
        {
            return await context.Proveedors.Where(x => x.Estado == false).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> Get(int id)
        {
            return await context.Proveedors.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Proveedor proveedor)
        {
            context.Attach(proveedor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Proveedors.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Proveedor { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool Exists(string correo)
        {
            return (context.Proveedors.Any(e => e.Email == correo));
        }
    }
}
