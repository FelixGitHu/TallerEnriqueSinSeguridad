using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Cierre
    {
        public int Id { get; set; }

        //Relacion con las tablas
        public int? VentaId { get; set; }
        public int CategoriaId { get; set; }
        public int InventarioId { get; set; }

        public Venta Venta { get; set; }
        public Categoria Categoria { get; set; }
        public Inventario Inventario { get; set; }
    }
}
