using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerEnrique.Shared.Entidades
{
    public class Cierre
    {
        [Key]
        public int Id { get; set; }
        public decimal Ingresos { get; set; } = 0;
        public decimal Egresos { get; set; } = 0;
        public decimal Saldo { get; set; } = 0;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int IdVenta { get; set; }
        public int IdCompra { get; set; }

        //Relacion con las tablas
        //public int VentaId { get; set; }
        //public int CategoriaId { get; set; }
        //public int InventarioId { get; set; }

        //public Venta Venta { get; set; }
        //public Categoria Categoria { get; set; }
        //public Inventario Inventario { get; set; }
    }
}
