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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="admin")]
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
        //General
        [HttpGet("cargartodos")]
        [AllowAnonymous] //para que cualquier usario logueado o no puede acceder  a este end-ponit
        public async Task<ActionResult<List<Articulo>>> Get()
        {
            return await context.Articulos.Where(x => x.Estado == true).ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
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
            context.Remove(new Articulo { Id = id});
            await context.SaveChangesAsync();
            return NoContent();
        }
        //para buscar articulos
        //[HttpGet("buscar/{textoBusqueda}")]
        //public async Task<ActionResult<List<Articulo>>> Get(string textoBusqueda)
        //{
        //    if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Articulo>(); }
        //    textoBusqueda = textoBusqueda.ToLower();
        //    return await context.Articulos
        //        .Where(x => x.Nombre.ToLower().Contains(textoBusqueda)).ToListAsync();
        //}

        //paginacion

       [HttpGet]
        public async Task<ActionResult<List<Articulo>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.Articulos.Where(x => x.Estado == true).AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }
    }
}
