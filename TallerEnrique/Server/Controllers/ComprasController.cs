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

        [HttpGet] //Original
        public async Task<ActionResult<List<Compra>>> Get()
        {
            return await context.Compras.ToListAsync();
        }
        //[HttpGet]//probando traer los campos calculados 
        //public async Task<ActionResult<List<Compra>>> Get()
        //{
        //    var compras = await context.Compras.ToListAsync();
        //    foreach (var item in compras)
        //    {
        //        item.CostoTotal = (List<Compra>)await context.Compras.GetByCompra(item.Id);
        //    }
        //    return compras;
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Compra>> Get(int id)
        //{
        //    return await context.Compras.FirstOrDefaultAsync(x => x.Id == id);
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetPol(int id)
        {
            var compra = await context.Compras
                .Include(x => x.DCompras)
                .FirstOrDefaultAsync(x => x.Id == id);
                if (compra == null)
            {
                return NotFound();
            }
            return compra;
        }

        //[HttpPut]
        //public async Task<ActionResult> Put(Compra compra)
        //{
        //    context.Attach(compra).State = EntityState.Modified;
        //    await context.SaveChangesAsync();
        //    return NoContent();
        //}

        [HttpPut]
        public async Task<ActionResult> Put(Compra compra)
        {
            context.Attach(compra).State = EntityState.Modified;
            foreach ( var detalle in compra.DCompras)
            {
                if ( detalle.Id != 0)
                {
                    context.Entry(detalle).State = EntityState.Modified;
                }
                else
                {
                    context.Entry(detalle).State = EntityState.Added;
                }
            } 
            var ListDetalle = compra.DCompras.Select(x => x.Id).ToList();
            var DetalleBorrar = await context
                .DCompras
                .Where(x => !ListDetalle.Contains(x.Id) && x.CompraId == compra.Id)
                .ToListAsync();

            context.RemoveRange(DetalleBorrar);
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
