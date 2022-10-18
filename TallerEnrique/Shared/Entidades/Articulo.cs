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
        public float PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Estado { get; set; }

        public List<DCompra> DCompras { get; set; } = new List<DCompra>();//Maestro detalle

        //public override bool Equals(object obj)///esto es de la prueba para typeHead, pero no me funciono
        //{
        //    if (obj is Articulo a2) 
        //    {
        //        return Id == a2.Id;
        //    }
        //    return false;
        //}
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    }
}
