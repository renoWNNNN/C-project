using Microsoft.AspNetCore.Mvc;
using SPAKLY.Modelos;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SPAKLY.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly string connectionString = "Server=localhost;Database=SpaklyDb;Trusted_Connection=True;Encrypt=False;";

        public IActionResult Editar(string nombre)
        {
            Productos? producto = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Productos WHERE Nombre LIKE @Nombre";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new Productos
                            {
                                ProductosId = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Precio = reader.GetDecimal(3),
                                Stock = reader.GetInt32(4),
                            };
                        }
                    }
                }
            }

            if (producto == null)
            {
                TempData["Mensaje"] = "No se encontró un producto con ese nombre.";
                return RedirectToAction("Productos", "Home");
            }

            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Productos producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock WHERE ProductosId = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@Id", producto.ProductosId);

                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Productos", "Home");
        }

        public IActionResult Eliminar(int ProductosId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Productos WHERE ProductosId = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", ProductosId);
                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Productos", "Home");
        }
    }
}
