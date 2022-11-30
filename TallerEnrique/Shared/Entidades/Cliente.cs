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
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Departamento { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; } = true;
    }
}
