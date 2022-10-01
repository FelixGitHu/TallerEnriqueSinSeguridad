using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Garantia
    {
        [Key]
        public int Id { get; set; }
        public string TiempoGarantia { get; set; }

        [Required(ErrorMessage = "Las politicas de Garantia es obligatorio ")]
        [StringLength(1000, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Politicas { get; set; }
        public bool Estado { get; set; }
        
        public int? ServicioId { get; set; }
        public Servicio Servicio { get; set; }
    }
}
