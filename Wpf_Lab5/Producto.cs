using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Lab5
{
    public class Producto
    {
        public int idproducto { get; set; }

        public string? nombreProducto { get; set; }
        
        public int idProveedor { get; set; }
        public int idCategoria { get; set; }
        public string? cantidadPorUnidad { get; set; }
        public decimal precioUnidad { get; set; }
        public Int16 unidadesEnExistencia { get; set; }
        public Int16 unidadesEnPedido { get; set; }
        public Int16 nivelNuevoPedido { get; set; }

        public Int16 suspendido { get; set; }
        public string? categoriaProducto { get; set; }

        public int activo { get; set; }

        
    }
}
