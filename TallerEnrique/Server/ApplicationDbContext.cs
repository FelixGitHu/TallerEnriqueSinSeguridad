﻿using TallerEnrique.Shared.Entidades;
//using TallerEnrique.Shared.MaestrosDelles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TallerEnrique.Server
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //    modelBuilder.Entity<GeneroPelicula>().HasKey(x => new { x.GeneroId, x.PeliculaId });
            //    modelBuilder.Entity<PeliculaActor>().HasKey(x => new { x.PeliculaId, x.PersonaId });
            var roleAdmin = new IdentityRole()
            { Id = "9a821084-bb87-4287-9b4d-5f7101b75063", Name = "admin", NormalizedName = "admin" };

            modelBuilder.Entity<IdentityRole>().HasData(roleAdmin);
            base.OnModelCreating(modelBuilder);

        }

        

        public DbSet<Mecanico> Mecanicos { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Garantia> Garantias { get; set; }
        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<DCompra> DCompras { get; set; }
        public DbSet<DVenta> DVentas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        //public DbSet<DVentaArticulo> DVentaArticulos { get; set; }
        //public DbSet<DVentaServicio> DVentaServicios { get; set; }
        public DbSet<Cierre> Cierre { get; set; }
        public DbSet<Configuracion> Configuracions { get; set; }
        //public DbSet<MDetalle> MDetalles { get; set; }
    }
}
