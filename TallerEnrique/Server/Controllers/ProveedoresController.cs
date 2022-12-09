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

namespace TallerEnrique.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            context.Add(proveedor);
            await context.SaveChangesAsync();
            return proveedor.Id;
        }
        //generico Este metodo esta de mas al igual que los demas get que estan en el resto de contraladores
        [HttpGet("cargartodos")]
        public async Task<ActionResult<List<Proveedor>>> Get()
        {
            return await context.Proveedors.ToListAsync();
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
    }
}
