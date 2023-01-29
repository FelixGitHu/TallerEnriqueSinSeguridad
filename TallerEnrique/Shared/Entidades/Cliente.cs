using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Ciudad { get; set; }

        [RegularExpression("[0-9]{13}[A-Z]{1}",
        ErrorMessage = "El término introducido no corresponde la formato de cédula nicaragüense")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Departamento { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; } = true;
    }
}
