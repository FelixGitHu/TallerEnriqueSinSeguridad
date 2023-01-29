using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Mecanico
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Apellido { get; set; }
        [RegularExpression("[0-9]{13}[A-Z]{1}",
        ErrorMessage = "El término introducido no corresponde la formato de cédula nicaragüense")]
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Direccion { get; set; }
        public bool Estado { get; set; } = true;
    }
}
