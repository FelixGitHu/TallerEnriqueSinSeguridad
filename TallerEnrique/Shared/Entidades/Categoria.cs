using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre de la Categoria  es obligatorio ")]
        [StringLength(50, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcio es obligatorio ")]
        [StringLength(500, ErrorMessage = "{0} la descripcion debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;
    }
}
