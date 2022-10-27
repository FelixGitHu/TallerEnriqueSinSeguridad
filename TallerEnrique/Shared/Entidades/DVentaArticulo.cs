using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class DVentaArticulo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La Cantidad es Obligatorio ")]
        public int Cantidad { get; set; }
        public bool Estado { get; set; } = true;

        //Estableciendo la relacion de las tablas
        public int? VentaId { get; set; }
        public int ArticuloId { get; set; }

        public Articulo Articulo { get; set; }
        public Venta Venta { get; set; }
    }
}
