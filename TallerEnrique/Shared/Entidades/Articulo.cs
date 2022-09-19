using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre del Articulo  es obligatorio ")]
        [StringLength(50, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Nombre de la Marca  es obligatorio ")]
        [StringLength(50, ErrorMessage = "{0} la marca debe tener entre {2} y {1} caracteres", MinimumLength = 4)]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El Precio  es obligatorio ")]
        public float PrecioUnitario { get; set; }
        public bool Estado { get; set; }

    }
}
