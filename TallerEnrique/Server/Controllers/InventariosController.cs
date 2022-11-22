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
    }
}
