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
        public bool Estado { get; set; }
        
        public int? ServicioId { get; set; }
        public Servicio Servicio { get; set; }
    }
}
