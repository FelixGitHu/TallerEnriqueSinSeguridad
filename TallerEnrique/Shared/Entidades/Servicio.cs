using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo oblogatorio")]
        [StringLength(2000, ErrorMessage = "{0} el nombre debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio ")]
        public bool Estado { get; set; } = true;

        //Relacion entre la tabla categoria y servicio
        [Required(ErrorMessage = "Campo obligatorio ")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
