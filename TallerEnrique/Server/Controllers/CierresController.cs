using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerEnrique.Shared.Entidades;

namespace TallerEnrique.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CierresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private DateTime hoy = DateTime.Now;

        public CierresController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //GET: api/compras
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Cierre>>> Get()
        {
            return await  context.Cierre.OrderByDescending(x=> x.Fecha).ToListAsync();
        }
        //GET: api/caja/filtro/cliente&empleado&fecha
        [HttpGet("filtro")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Cierre>>> Get([FromQuery] DateTime fecha) // para que funcione en rider
        {
            DateTime f = Convert.ToDateTime(fecha);

            var queryable = context.Cierre.AsQueryable();

            if (f != DateTime.Today)
            {
                queryable = queryable.Where(x => x.Fecha.Day == f.Day &&
                                            x.Fecha.Month == f.Month &&
                                            x.Fecha.Year == f.Year);
            }
            return await queryable.OrderByDescending(x => x.Fecha).ToListAsync();
        }

        // GET: api/ventas/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Cierre>> Get(int id)
        {
            return await context.Cierre.Include(x => x.Id).FirstAsync(x => x.Id == id);
        }
        // POST: api/ventas 
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<int>> Post(Cierre caja)
        {
            context.Cierre.Add(caja);

            try
            {
                caja.Egresos = context.Compras.Sum(x => x.CostoTotal); //  obtiene la suma del total de compras
                caja.Ingresos = context.Ventas.Sum(x => x.Total); // obtiene la suma del total de ventas

                caja.Saldo = context.Ventas.Sum(x => x.Total) - context.Compras
                    .Sum(x => x.CostoTotal); // resta de ambos totales
                // TODO: Validar cuando sea negativo

                caja.Fecha = DateTime.Now;
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Exists(caja.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return caja.Id;
        }

        private bool Exists(int id)
        {
            return context.Cierre.Any(e => e.Id == id);

        }
    }
}
