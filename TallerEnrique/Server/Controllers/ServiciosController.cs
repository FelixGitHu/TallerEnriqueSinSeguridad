using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerEnrique.Server.Helpers;
using TallerEnrique.Shared.Complement;
using TallerEnrique.Shared.Entidades;

namespace TallerEnrique.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiciosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ServiciosController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Servicio servicio)
        {
            context.Add(servicio);
            await context.SaveChangesAsync();
            return servicio.Id;
        }

        [HttpGet("cargartodos")]
        public async Task<ActionResult<List<Servicio>>> Get()
        {
            return await context.Servicios.Where(x => x.Estado == true).Include("Categoria").ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> Get(int id)
        {
            return await context.Servicios.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Servicio servicio)
        {
            context.Attach(servicio).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Servicios.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Servicio { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        
    }
}
