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
        public DateTime Fecha { get; set; } = DateTime.Today;
        public decimal CostoTotal { get; set; }
        
        public decimal SubTotal
        { get 
            { return DCompras.Sum
                    (x => (x.Cantidad * x.PrecioUnitario) - ((x.Cantidad * x.PrecioUnitario) * x.Descuento/100)); 
            } set { } }
       
        public decimal IVA
        { get 
            { return DCompras.Sum
                     (x=> (x.Cantidad * x.PrecioUnitario) * (15M / 100M)); 
            } set { } }
        
        public bool Estado { get; set; } = true;

        //Relacionando las tablas 
        
        public int ProveedorId { get; set; }

        public Proveedor Proveedor { get; set; }
       
        public List<DCompra> DCompras { get; set; } = new List<DCompra>(); //probando el maestro detalle
    }
}
