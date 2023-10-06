using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf_Lab5
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            McDataGrid.ItemsSource = ListarProductos();
        }

        private static List<Producto> ListarProductos()
        {
            string connectionString = "Data Source=LAB1504-17\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=userTecsup;Password=123456";

            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                string query = "ListarProductos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

     
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila
                                productos.Add(new Producto
                                {
                                    idproducto = (int)reader["idproducto"],
                                    nombreProducto = reader["nombreProducto"].ToString(),
                                    idProveedor = (int)reader["idProveedor"],
                                    idCategoria = (int)reader["idCategoria"],
                                    cantidadPorUnidad = reader["cantidadPorUnidad"].ToString(),
                                    precioUnidad = (decimal)reader["precioUnidad"],
                                    unidadesEnExistencia = (Int16)reader["unidadesEnExistencia"],
                                    unidadesEnPedido = (Int16)reader["unidadesEnPedido"],
                                    nivelNuevoPedido = (Int16)reader["nivelNuevoPedido"],
                                    suspendido = (Int16)reader["suspendido"],
                                    categoriaProducto = reader["categoriaProducto"].ToString(),
                                    activo = (int)reader["activo"]
                                });

                            }
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();
            }
            return productos;

        }
    }
}
