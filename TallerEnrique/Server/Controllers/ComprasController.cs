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
    public class ComprasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ComprasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Compra compra)
        {
            context.Add(compra);
            await context.SaveChangesAsync();
            return compra.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<Compra>>> Get()
        {
            return await context.Compras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> Get(int id)
        {
            return await context.Compras.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Compra compra)
        {
            context.Attach(compra).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Compras.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Compra { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpPost]//probando hacer funcionar el maestro detalle de compras 
        //public IActionResult FormularioDCompra([FromBody] MDetalle mDetalle)
        //{
        //    Compra oCompra = mDetalle.oCompra;
        //    oCompra.MDetalles = mDetalle.oDCompra;
        //    context.Compras.Add(oCompra);
        //    context.SaveChanges();
        //    return JsonResult(new { respuesta = true });
        //}

        //private IActionResult JsonResult(object p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
