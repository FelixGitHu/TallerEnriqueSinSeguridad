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
    public class DComprasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DComprasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(DCompra dCompra)
        {
            context.Add(dCompra);
            await context.SaveChangesAsync();
            return dCompra.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<DCompra>>> Get()
        {
            return await context.DCompras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DCompra>> Get(int id)
        {
            return await context.DCompras.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(DCompra dCompra)
        {
            context.Attach(dCompra).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.DCompras.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new DCompra { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        //[HttpPost]//probando hacer funcionar el maestro detalle de compras con funciones de Java Scripts, no funciono😪😪
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
