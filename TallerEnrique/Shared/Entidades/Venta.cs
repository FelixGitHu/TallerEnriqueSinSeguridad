using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        //public long  NFactura { get; set; }

        [Required(ErrorMessage = "Los Nombres del Cliente son Obligatorio ")]
        public string NombresCliente { get; set; }

        [Required(ErrorMessage = "Los Apellidos del Cliente son Obligatorio ")]
        public string ApellidosCliente { get; set; }

        [Required(ErrorMessage = "La Descripcion es Obligatorio ")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La Fecha es Obligatorio ")]
        public DateTime Fecha { get; set; } = DateTime.Today;
        public decimal Descuento { get; set; }
        public decimal ManoObra { get; set; }
        public bool Estado { get; set; } = true;
        public decimal SubTotal { get { return DVentas.Sum(x => (x.Cantidad * x.PrecioVenta) ); } set { } }
        public decimal IVA { get { return SubTotal + (SubTotal * (15M / 100M)); } set { } }
        public decimal Total { get { return DVentas.Sum(x => IVA - (IVA * (x.Descuento / 100M)) + ManoObra); } set { } }

        //Estableciendo la relacion entre tablas
        public int VehiculoId { get; set; }
        public int MonedaId { get; set; }
        //public int InventarioId { get; set; }
        public int MecanicoId { get; set; }
        public int ServicioId { get; set; }
        public int? CategoriaId { get; set; }

        public Vehiculo Vehiculo { get; set; }
        public Moneda Moneda { get; set; }
        //public Inventario Inventario { get; set; }
        public Mecanico Mecanico { get; set; }
        public Servicio Servicio  { get; set; }
        public Categoria Categoria { get; set; }

        //Maestro detallle 28 de octubre 2022 2:25 PM
        //public List<DVentaArticulo> DVentaArticulos { get; set; } = new List<DVentaArticulo>();
        //public List<DVentaServicio> dVentaServicios { get; set; } = new List<DVentaServicio>();
        public List<DVenta> DVentas { get; set; } = new List<DVenta>();
    }
}
