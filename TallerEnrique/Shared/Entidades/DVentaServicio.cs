using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class DVentaServicio
    {
        [Key]
        public int Id { get; set; }

        public bool Estado { get; set; } = true; 

        //Relacion con las tablas
        public int ServicioId { get; set; }
        public int VentaId { get; set; }

        public Servicio Servicio { get; set; }
        public Venta Venta { get; set; }
    }
}
