using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Moneda
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre del tipo de moneda es obligatorio ")]
        [StringLength(50, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string TipoMoneda { get; set; }
        public bool Estado { get; set; }
    }
}
