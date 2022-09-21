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
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El Precio es Obligatorio ")]
        public float PrecioUnitario { get; set; }
        public bool Estado { get; set; }

        //Relacion de las Tablas 
        public int ArticuloId { get; set; }
        public int? CompraId { get; set; }

        public Articulo Articulo { get; set; }
        public Compra Compra { get; set; }
    }
}
