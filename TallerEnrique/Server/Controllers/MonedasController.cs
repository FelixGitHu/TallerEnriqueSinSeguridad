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
    public class MonedasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public MonedasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("cargartodos")]
        public async Task<ActionResult<List<Moneda>>> Get()
        {
            return await context.Monedas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Moneda>> Get(int id)
        {
            return await context.Monedas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Moneda monedas)
        {
            context.Add(monedas);
            await context.SaveChangesAsync();
            return monedas.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Moneda monedas)
        {
            context.Attach(monedas).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Configuracions.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Moneda { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}

