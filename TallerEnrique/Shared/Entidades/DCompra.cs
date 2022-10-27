using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class DCompra
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La Cantidad es Obligatorio ")]
        public int Cantidad { get; set; } = 0;

        [Required(ErrorMessage = "El Precio es Obligatorio ")]
        public decimal PrecioUnitario { get; set; } = 0;

        public decimal Descuento { get; set; } = 0;

        public bool Estado { get; set; } = true;

        //Relacion de las Tablas 
        public int ArticuloId { get; set; }
        public int? CompraId { get; set; }

        public Articulo Articulo { get; set; }
        public Compra Compra { get; set; }
    }
}
