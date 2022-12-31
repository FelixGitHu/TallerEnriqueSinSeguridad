using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre del Articulo  es obligatorio ")]
        [StringLength(100, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Nombre de la Marca  es obligatorio ")]
        [StringLength(100, ErrorMessage = "{0} la marca debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El Precio  es obligatorio ")]
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get { return PrecioCompra + (PrecioCompra * (12M / 100M)); } set { } }

        [StringLength(300)]
        [MaxLength(300, ErrorMessage = "Máximo 300 dígitos"), MinLength(2, ErrorMessage = "Minimo 2 dígitos")]
        public string? Descripcion { get; set; }

        [StringLength(30)]
        [MaxLength(30, ErrorMessage = "Máximo {0} caracteres")]
        public string? Codigo { get; set; }

        public bool Estado { get; set; } = true;

        public List<DCompra> DCompras { get; set; } = new List<DCompra>();//Maestro detalle
        public List<DVenta> DVentas { get; set; } = new List<DVenta>();

        
    }
}
