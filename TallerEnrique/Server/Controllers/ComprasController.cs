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
    public class ComprasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ComprasController(ApplicationDbContext context)
        {
            this.context = context;
        }


        //public async Task<ActionResult<int>> Post(Compra compra)
        //{
        //    context.Add(compra);
        //    await context.SaveChangesAsync();
        //    return compra.Id;
        //}
        [HttpPost]
        public async Task<ActionResult<int>> Post(Compra compra)
        {
            foreach (DCompra dCompra in compra.DCompras)
            {
                //extrae el registro del inventario que contiene el articulo a comprar, sino es igual a null
                Inventario inventario = context.Inventarios.FirstOrDefault(inv => inv.ArticuloId == dCompra.ArticuloId);
                //si el existe un registro con el inventario :
                if (inventario != null)
                {
                    //busca nuevamente el registro en la base de datos (ya sabemos q existe)
                    //y extrae la variable Existencia para asignar el valor de existencia mas la cantidad nueva
                    //del articulo que se compra
                    context.Inventarios.Find(inventario.Id).Existencia = context.Inventarios.Find(inventario.Id).Existencia + dCompra.Cantidad;

                }
                else
                {
                    //sino existe ninmgun registro, es mas facil porque solo creamos uno nuevo
                    context.Inventarios.Add(new Inventario()
                    {
                        ArticuloId = dCompra.ArticuloId,
                        Existencia = dCompra.Cantidad,
                        Estado = true
                    });
                }
                dCompra.Articulo = null;
            }
            compra.Proveedor = null;
            //una vez se agregan o modifican los registros de invenmtario, se guarda la compra
            //context.Compras.Add(compra);
            compra = context.Add(compra).Entity;
            await context.SaveChangesAsync();
            return compra.Id;
        }

        //[HttpGet]//probando traer los campos calculados 
        //public async Task<List<Compra>> Get()
        //{
        //    return await context.Compras.Include("Proveedor").Include("DCompras").ToListAsync();


        //}

        [HttpGet("cargartodo")] //Original(este no lo tiene D
        public async Task<ActionResult<List<Compra>>> Get()
        {
            //return await context.Compras.ToListAsync();
            return await context.Compras.Include("Proveedor").Include("DCompras").ToListAsync();
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

        // paginacion

        [HttpGet]
        public async Task<ActionResult<List<Compra>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.Compras.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

       
    }
}
