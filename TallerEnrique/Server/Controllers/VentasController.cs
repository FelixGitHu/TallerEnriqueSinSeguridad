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
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public VentasController(ApplicationDbContext context)
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
        public async Task<ActionResult<int>> Post(Venta venta)
        {
            foreach (DVenta dVenta in venta.DVentas)
            {
                //extrae el registro del inventario que contiene el articulo a comprar, sino es igual a null
                Inventario inventario = context.Inventarios.FirstOrDefault(inv => inv.ArticuloId == dVenta.ArticuloId);
                //si el existe un registro con el inventario :
                if (inventario != null)
                {
                    //busca nuevamente el registro en la base de datos (ya sabemos q existe)
                    //y extrae la variable Existencia para asignar el valor de existencia mas la cantidad nueva
                    //del articulo que se compra
                    context.Inventarios.Find(inventario.Id).Existencia = context.Inventarios.Find(inventario.Id).Existencia - dVenta.Cantidad;
                    //var lista_articulo = await context.Articulos.ToListAsync();
                    //var articulo = lista_articulo.First(x => x.Id == dVenta.ArticuloId);
                    //articulo.PrecioVenta = dVenta.PrecioVenta;
                }
                else
                {
                    //sino existe ninmgun registro, es mas facil porque solo creamos uno nuevo
                    context.Inventarios.Add(new Inventario()
                    {
                        ArticuloId = dVenta.ArticuloId,
                        Existencia = dVenta.Cantidad,
                        Estado = true
                    });
                }
                dVenta.Articulo = null;
            }
            venta.Vehiculo = null;
            venta.Moneda = null;
            venta.Mecanico = null;
            venta.Servicio = null;
            venta.Categoria = null;
            venta.Cliente = null;
            //una vez se agregan o modifican los registros de invenmtario, se guarda la compra
            //context.Compras.Add(compra);
            venta = context.Add(venta).Entity;
            await context.SaveChangesAsync();
            return venta.Id;
        }



        [HttpGet("cargartodo")] //Original(este no lo tiene D
        public async Task<ActionResult<List<Venta>>> Get()
        {
            //return await context.Compras.ToListAsync();
           return await context.Ventas.Include("Vehiculo").Include("Moneda").Include("Servicio").Include("Mecanico").Include("Categoria").Include("DVentas").Include("Cliente").ToListAsync();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Compra>> Get(int id)
        //{
        //    return await context.Compras.FirstOrDefaultAsync(x => x.Id == id);
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetPol(int id)
        {
            //var compra = await context.Compras
            var venta = await context.Ventas
               // .Include(x => x.DCompras)
               .Include(x => x.DVentas)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (venta == null)
            {
                return NotFound();
            }
            return venta;
        }

        //[HttpPut]
        //public async Task<ActionResult> Put(Compra compra)
        //{
        //    context.Attach(compra).State = EntityState.Modified;
        //    await context.SaveChangesAsync();
        //    return NoContent();
        //}

        [HttpPut]
        public async Task<ActionResult> Put(Venta venta)
        {
            context.Attach(venta).State = EntityState.Modified;
            foreach (var detalle in venta.DVentas)
            {
                if (detalle.Id != 0)
                {
                    context.Entry(detalle).State = EntityState.Modified;
                }
                else
                {
                    context.Entry(detalle).State = EntityState.Added;
                }
            }
            var ListDetalle = venta.DVentas.Select(x => x.Id).ToList();
            var DetalleBorrar = await context
                .DVentas
                .Where(x => !ListDetalle.Contains(x.Id) && x.VentaId == venta.Id)
                .ToListAsync();

            context.RemoveRange(DetalleBorrar);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Ventas.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Venta { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        // paginacion

        [HttpGet]
        public async Task<ActionResult<List<Venta>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.Ventas.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }


    }
}

