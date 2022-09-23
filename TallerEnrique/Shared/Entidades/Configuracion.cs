using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Configuracion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Encabezado { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NombreNegocio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string DescripcionServicios { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Telefono { get; set; }
    }
}
