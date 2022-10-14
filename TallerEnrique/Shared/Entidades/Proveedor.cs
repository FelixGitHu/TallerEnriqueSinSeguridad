using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre de la empresa es obligatorio ")]
        [StringLength(100, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string NombreEmpresa { get; set; }

        [Required(ErrorMessage = "El Nombre del proveedor  es obligatorio ")]
        [StringLength(100, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string NombreContacto { get; set; }

        [Required(ErrorMessage = "La Direccion es obligatorio ")]
        [StringLength(50, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Departemanto es obligatorio ")]
        [StringLength(50, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "La Ciudad es obligatorio ")]
        [StringLength(50, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El Email del proveedor  es obligatorio ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Teléfono es obligatorio ")]
        [StringLength(50, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Telefono { get; set; }

        public bool Estado { get; set; }

        //para que no se pueda seleccionar un proveedor mas de una vez
        //public override bool Equals(object obj)
        //{
        //    if( obj is Proveedor prov)
        //    {
        //        return Id == prov.Id;
        //    }
        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    }
}
