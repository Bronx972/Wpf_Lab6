using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = new Producto
            {
                idproducto= int.Parse(txtIdProducto.Text),
                nombreProducto = txtNombreProducto.Text,
                idProveedor = int.Parse(txtIdProveedor.Text),
                idCategoria = int.Parse(txtIdCategoria.Text),
                cantidadPorUnidad = txtCantidadUnidad.Text,
                precioUnidad = int.Parse(txtPrecioUnidad.Text),
                unidadesEnExistencia = Int16.Parse(txtUnidadExistencia.Text),
                unidadesEnPedido = Int16.Parse(txtUnidadPedido.Text),
                nivelNuevoPedido = Int16.Parse(txtNivelNuevoPedido.Text),
                suspendido = Int16.Parse(txtSuspendido.Text),
                categoriaProducto = txtCategoriaProducto.Text,

            };
            InsertarCategoria(producto);
        }
        private void InsertarCategoria(Producto producto)
        {
            try
            {
                string connectionString = "Data Source=LAB1504-17\\SQLEXPRESS;Initial Catalog=Neptuno;User ID=userTecsup;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("InsertarProductos", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", producto.idproducto);
                    cmd.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
                    cmd.Parameters.AddWithValue("@idProveedor", producto.idProveedor);
                    cmd.Parameters.AddWithValue("@idCategoria",producto.idCategoria);
                    cmd.Parameters.AddWithValue("@cantidadPorUnidad", producto.cantidadPorUnidad);
                    cmd.Parameters.AddWithValue("@precioUnidad", producto.precioUnidad);
                    cmd.Parameters.AddWithValue("@unidadesEnExistencia", producto.unidadesEnExistencia);
                    cmd.Parameters.AddWithValue("@unidadesEnPedido", producto.unidadesEnPedido);
                    cmd.Parameters.AddWithValue("@nivelNuevoPedido", producto.nivelNuevoPedido);
                    cmd.Parameters.AddWithValue("@suspendido", producto.suspendido);
                    cmd.Parameters.AddWithValue("@categoriaProducto", producto.categoriaProducto);



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto ingresada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el producto: " + ex.Message);
            }
        }

        private void Button_Click_Listar(object sender, RoutedEventArgs e)
        {
            Window window = new Window1();
            window.Show();
        }
        //private void EliminarProducto() { }
        //private void ActualizarProducto() { }
        //private void ListarProducto() { }

    }
}
