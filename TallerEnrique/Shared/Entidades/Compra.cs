using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        public long NFactura { get; set; }

        [Required(ErrorMessage = "La Fecha es obligatorio")]
        public DateTime Fecha { get; set; }
        public float CostoTotal { get; set; }
        public bool Estado { get; set; }

        //Relacionando las tablas 
        public int InventarioId { get; set; }
        public int ProveedorId { get; set; }
        //public int UsuarioId { get; set; }

        public Inventario Inventario { get; set; }
        public Proveedor Proveedor { get; set; }
       // public Mecanico Mecanico { get; set; }
       // public List<DCompra> MDetalles { get; set; }//probando el maestro detalle
    }
}
