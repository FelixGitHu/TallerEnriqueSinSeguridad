using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime FechaEntrada { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime FechaSalida { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio")]
        public int YearCar { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Kilometraje { get; set; }
        public bool Estado { get; set; } = true;

        //Relacion con la tabla Clienta
        [Required(ErrorMessage = "Campo obligatorio")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}
