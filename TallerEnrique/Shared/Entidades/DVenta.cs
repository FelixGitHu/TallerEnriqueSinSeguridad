using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class DVenta
    {
        [Key]
        public int Id { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Descuento { get; set; }
        [Required(ErrorMessage = "La Cantidad es Obligatorio ")]
        public int Cantidad { get; set; }
        //public decimal Total { get; set; }


        public int ArticuloId { get; set; }
        public int VentaId { get; set; }
        public int? InventarioId { get; set; }
        //public int ServicioId { get; set; }
        //public int MonedaId { get; set; }
        //public int MecanicoId { get; set; }
       

        public Articulo Articulo { get; set; }
        public Venta Venta { get; set; }
        public Inventario Inventario { get; set; }
        //public Servicio Servicio { get; set; }
        //public Moneda Moneda { get; set; }
        //public Mecanico Mecanico { get; set; }

    }
}
