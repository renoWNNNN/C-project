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

        public IActionResult Productos()
        {
            var Productos = new List<Productos>();
            string connectionString = "Server=localhost;Database=SpaklyDb;Trusted_Connection=True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Productos";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Productos.Add(new Productos
                        {
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                        });
                    }
                }
            }

            return View(Productos);
        }
    }
}
