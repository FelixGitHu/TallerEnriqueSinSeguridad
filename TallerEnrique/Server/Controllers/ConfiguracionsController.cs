using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerEnrique.Shared.Entidades;

namespace TallerEnrique.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public class ConfiguracionsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ConfiguracionsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Configuracion>>> Get()
        {
            return await context.Configuracions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Configuracion>> Get(int id)
        {
            return await context.Configuracions.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Configuracion Configuracion)
        {
            context.Add(Configuracion);
            await context.SaveChangesAsync();
            return Configuracion.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Configuracion configuracion)
        {
            context.Attach(configuracion).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Configuracions.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Configuracion { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        //para buscar articulos
        //[HttpGet("buscar/{textoBusqueda}")]
        //public async Task<ActionResult<List<Configuracion>>> Get(string textoBusqueda)
        //{
        //    if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Configuracion>(); }
        //    textoBusqueda = textoBusqueda.ToLower();
        //    return await context.Configuracions
        //        .Where(x => x.NombreNegocio.ToLower().Contains(textoBusqueda)).ToListAsync();
        //}
    }
}
