using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Los Nombres del Cliente son Obligatorio ")]
        public string NombresCliente { get; set; }

        [Required(ErrorMessage = "Los Apellidos del Cliente son Obligatorio ")]
        public string ApellidosCliente { get; set; }

        [Required(ErrorMessage = "La Descripcion es Obligatorio ")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La Fecha es Obligatorio ")]
        public DateTime Fecha { get; set; }
        public float Descuento { get; set; }
        public float ManoObra { get; set; }
        public bool Estado { get; set; } = true;

        //Estableciendo la relacion entre tablas
        public int VehiculoId { get; set; }
        public int MonedaId { get; set; }
        public int InventarioId { get; set; }
        public int MecanicoId { get; set; }

        public Vehiculo Vehiculo { get; set; }
        public Moneda Moneda { get; set; }
        public Inventario Inventario { get; set; }
        public Mecanico Mecanico { get; set; }
    }
}
