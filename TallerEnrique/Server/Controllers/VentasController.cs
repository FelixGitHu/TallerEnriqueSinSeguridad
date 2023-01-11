using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin, vendedor")]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public VentasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Venta venta)
        {
            foreach (DVenta dVenta in venta.DVentas)
            {
                //extrae el registro del inventario que contiene el articulo a comprar, sino es igual a null
                var listaInventario = await context.Inventarios.ToListAsync();
                var inventa = listaInventario.First(x => x.Id == dVenta.InventarioId);
                inventa.ArticuloId = dVenta.InventarioId;
                

                Inventario inventario = context.Inventarios.FirstOrDefault(inv => inv.ArticuloId == dVenta.InventarioId);
               
                if (inventario != null)
                {
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
                        ArticuloId = dVenta.InventarioId,
                        Existencia = dVenta.Cantidad,
                        Estado = true
                    });
                }
                dVenta.Inventario = null;
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
            if (context.Ventas.IsNullOrEmpty())
            {
                venta.NFactura = 1;
            }
            else
            {
                venta.NFactura = context.Ventas.Max(x => x.NFactura + 1); //  funcion para obtener el numero de factura, que debe de ser un numero consecutivo y que no se repita jamas                    
            }
            await context.SaveChangesAsync();
            await GuardarEnCaja(venta);
            return venta.Id;
        }



        [HttpGet("cargartodo")] 
        public async Task<ActionResult<List<Venta>>> Get()
        {
           
           return await context.Ventas.Include("Vehiculo").Include("Moneda").Include("Servicio").Include("Mecanico").Include("Categoria").Include("DVentas").Include("Cliente").OrderByDescending(x => x.Fecha).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> Get(int id)
        {

            return await context.Ventas
               .Include(x => x.DVentas)
               .Include(x => x.Cliente)
               .Include(x => x.Moneda)
               .Include(x => x.Vehiculo)
               .Include(x => x.Mecanico)
               .Include(x => x.Servicio)
               .Include(x => x.Categoria)
               .FirstOrDefaultAsync(x => x.Id == id);
            //.FirstAsync(x => x.Id == id);

        }
        


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

       // Cierre
        private async Task GuardarEnCaja(Venta venta)
        {
            CierresController cc = new CierresController(context);
            Cierre cajas = new Cierre()
            {
                IdVenta = venta.Id,
                Fecha = venta.Fecha,
                Ingresos = Convert.ToDecimal(venta.Total),
            };
            await cc.Post(cajas);
        }

    }
}

