using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La Existencia es Obligatorio ")]
        [StringLength(50, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public int Existencia { get; set; }
        public bool Estado { get; set; }

        //Estableciendo la relacion entre las tablas Inventario y Articulo
        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
    }
}
