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
            foreach (DCompra dCompra in compra.DCompras)
            {
                //extrae el registro del inventario que contiene el articulo a comprar, sino es igual a null
                Inventario inventario = context.Inventarios.FirstOrDefault(inv => inv.ArticuloId == dCompra.ArticuloId);
               
                if (inventario != null)
                {
                    
                    context.Inventarios.Find(inventario.Id).Existencia = context.Inventarios.Find(inventario.Id).Existencia + dCompra.Cantidad;
                    var lista_articulo = await context.Articulos.ToListAsync();
                    var articulo = lista_articulo.First(x => x.Id == dCompra.ArticuloId);
                    articulo.PrecioCompra = dCompra.PrecioUnitario;
                    
                }
                else
                {
                    var lista_articulo = await context.Articulos.ToListAsync();
                    var articulo = lista_articulo.First(x => x.Id == dCompra.ArticuloId);
                    articulo.PrecioCompra = dCompra.PrecioUnitario;
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
            if (context.Compras.IsNullOrEmpty())
            {
                compra.NFactura = 1;
            }
            else
            {
                compra.NFactura = context.Compras.Max(x => x.NFactura + 1); //  funcion para obtener el numero de factura, que debe de ser un numero consecutivo y que no se repita jamas                    
            }
            await context.SaveChangesAsync();
            await GuardarEnCaja(compra);
            return compra.Id;
        }

        

        [HttpGet("cargartodo")] 
        public async Task<ActionResult<List<Compra>>> Get()
        {
          
            return await context.Compras.Where(x=> x.Estado == true).Include("Proveedor").Include("DCompras").OrderByDescending(x => x.Fecha).ToListAsync();
        }
        [HttpGet("comprasinactivas")]
        public async Task<ActionResult<List<Compra>>> GetInactivos()
        {

            return await context.Compras.Where(x => x.Estado == false).Include("Proveedor").Include("DCompras").OrderByDescending(x => x.Fecha).ToListAsync();
        }


        //[HttpGet("{id}")]
        //public async Task<ActionResult<Compra>> GetPol(int id)
        //{
        //    var compra = await context.Compras
        //        .Include(x => x.DCompras)
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //        if (compra == null)
        //    {
        //        return NotFound();
        //    }
        //    return compra;
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> Get(int id)
        {

            return await context.Compras
                .Include(x => x.Proveedor)
                .Include(x => x.DCompras)
                .ThenInclude(x => x.Articulo)
                .FirstOrDefaultAsync(x => x.Id == id);
            //.FirstAsync(x => x.Id == id);

        }


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

        
        //Cierre
        private async Task GuardarEnCaja(Compra Compra)
        {
            CierresController cc = new CierresController(context);
            Cierre cajas = new Cierre()
            {
                IdCompra = Compra.Id,
                Fecha = Compra.Fecha,
                Egresos = Convert.ToDecimal(Compra.CostoTotal)
            };
            await cc.Post(cajas);
        }

    }
}
