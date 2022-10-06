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
    public class ArticulosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ArticulosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Articulo articulo)
        {
            context.Add(articulo);
            await context.SaveChangesAsync();
            return articulo.Id;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Articulo>>> Get()
        //{
        //    return await context.Articulos.ToListAsync();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> Get(int id)
        {
            return await context.Articulos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Articulo articulo)
        {
            context.Attach(articulo).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Articulos.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Articulo { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        // paginacion

        [HttpGet]
        public async Task<ActionResult<List<Articulo>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.Articulos.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }
    }
}
