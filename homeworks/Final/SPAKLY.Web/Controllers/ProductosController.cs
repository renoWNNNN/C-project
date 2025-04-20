using Microsoft.AspNetCore.Mvc;
using SPAKLY.Modelos;
using Microsoft.Data.SqlClient;

namespace SPAKLY.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly string connectionString = "Server=localhost;Database=SpaklyDb;Trusted_Connection=True;Encrypt=False;";

        public IActionResult Editar(int id)
        {
            Productos? producto = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Productos WHERE ProductosId = @Id";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                using var reader = command.ExecuteReader();
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

            if (producto == null)
            {
                TempData["Mensaje"] = "Producto no encontrado.";
                return RedirectToAction("Productos", "Home");
            }

            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Productos producto)
        {
            if (producto.Stock < 0 || producto.Precio < 0)
            {
                ModelState.AddModelError("", "Precio y Stock no pueden ser negativos.");
                return View(producto);
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Stock = @Stock WHERE ProductosId = @Id";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@Id", producto.ProductosId);

                command.ExecuteNonQuery();
            }

            return RedirectToAction("Productos", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Productos? producto = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Productos WHERE ProductosId = @Id";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                using var reader = command.ExecuteReader();
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

            if (producto == null)
            {
                TempData["Mensaje"] = "Producto no encontrado.";
                return RedirectToAction("Productos", "Home");
            }

            return View(producto);
        }

        [HttpPost]
        public IActionResult Eliminar(Productos producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Productos WHERE ProductosId = @Id";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", producto.ProductosId);
                command.ExecuteNonQuery();
            }

            return RedirectToAction("Productos", "Home");
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Productos producto)
        {
            if (!ModelState.IsValid || producto.Stock < 0 || producto.Precio < 0)
            {
                ModelState.AddModelError("", "Precio y Stock no pueden ser negativos.");
                return View(producto);
            }

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO Productos (Nombre, Descripcion, Precio, Stock) VALUES (@Nombre, @Descripcion, @Precio, @Stock)";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", producto.Nombre);
            command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
            command.Parameters.AddWithValue("@Precio", producto.Precio);
            command.Parameters.AddWithValue("@Stock", producto.Stock);

            command.ExecuteNonQuery();

            return RedirectToAction("Productos", "Home");
        }
    }
}
