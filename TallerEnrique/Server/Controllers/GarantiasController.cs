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
    public class GarantiasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public GarantiasController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Garantia garantia)
        {
            context.Add(garantia);
            await context.SaveChangesAsync();
            return garantia.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<Garantia>>> Get()
        {
            return await context.Garantias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Garantia>> Get(int id)
        {
            return await context.Garantias.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Garantia garantia)
        {
            context.Attach(garantia).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Garantias.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Garantia { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
        //para buscar articulos
        //[HttpGet("buscar/{textoBusqueda}")]
        //public async Task<ActionResult<List<Garantia>>> Get(string textoBusqueda)
        //{
        //    if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Garantia>(); }
        //    textoBusqueda = textoBusqueda.ToLower();
        //    return await context.Garantias
        //        .Where(x => x.Politicas.ToLower().Contains(textoBusqueda)).ToListAsync();
        //}
    }
}
