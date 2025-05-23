using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SPAKLY.Web.Models;
using SPAKLY.Modelos;
using Microsoft.Data.SqlClient;

namespace SPAKLY.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Productos(string searchString)
        {
            var productos = new List<Productos>();
            string connectionString = "Server=localhost;Database=SpaklyDb;Trusted_Connection=True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Productos";

                if (!string.IsNullOrEmpty(searchString))
                {
                    query += " WHERE Nombre LIKE @search";
                }

                using SqlCommand command = new(query, connection);
                if (!string.IsNullOrEmpty(searchString))
                {
                    command.Parameters.AddWithValue("@search", $"%{searchString}%");
                }

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productos.Add(new Productos
                    {
                        ProductosId = reader.GetInt32(0),
                        Nombre = reader["Nombre"]?.ToString() ?? string.Empty,
                        Descripcion = reader["Descripcion"]?.ToString() ?? string.Empty,
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Stock = Convert.ToInt32(reader["Stock"])
                    });
                }
            }

            return View(productos);
        }
        public IActionResult Search(string searchString)
        {
            return RedirectToAction("Productos", new { searchString });
        }
    }
}
