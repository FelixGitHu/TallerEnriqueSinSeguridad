using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public class InventariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public InventariosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("Cargar")]
        public async Task<ActionResult<List<Inventario>>> Get()
        {
            return await context.Inventarios.Include("Articulo").ToListAsync();
        }
        //para buscar articulos
        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<Inventario>>> Get(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Inventario>(); }
            textoBusqueda = textoBusqueda.ToLower();
            return await context.Inventarios
                .Where(x => x.Articulo.Nombre.ToLower().Contains(textoBusqueda)).ToListAsync();
        }

    }
}
