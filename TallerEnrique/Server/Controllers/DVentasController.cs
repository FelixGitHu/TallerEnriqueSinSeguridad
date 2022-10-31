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
    public class DVentasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DVentasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(DVenta dVenta)
        {
            context.Add(dVenta);
            await context.SaveChangesAsync();
            return dVenta.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<DVenta>>> Get()
        {
            return await context.DVentas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DVenta>> Get(int id)
        {
            return await context.DVentas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(DVenta dVenta)
        {
            context.Attach(dVenta).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.DVentas.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new DVenta { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}
