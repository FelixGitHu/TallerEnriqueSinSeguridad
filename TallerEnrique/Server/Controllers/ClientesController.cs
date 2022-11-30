﻿using Microsoft.AspNetCore.Authorization;
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
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ClientesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Cliente clientes)
        {
            context.Add(clientes);
            await context.SaveChangesAsync();
            return clientes.Id;
        }
        //General
        [HttpGet("cargartodos")]
        [AllowAnonymous] //para que cualquier usario logueado o no puede acceder  a este end-ponit
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await context.Clientes.Where(x => x.Estado == true).ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            return await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Cliente clientes)
        {
            context.Attach(clientes).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Clientes.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Cliente { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }

        //paginacion

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.Clientes.Where(x => x.Estado == true).AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }
    }
}