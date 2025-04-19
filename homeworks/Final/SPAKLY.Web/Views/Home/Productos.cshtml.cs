using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SPAKLY.Modelos;

namespace SPAKLY.Web.Views.Home
{
    public class ProductoModel : PageModel
    {
        public List<Productos> Productos { get; set; } = new();

        public void OnGet()
        {
            string connectionString = "Server=localhost;Database=SpaklyDb;Trusted_Connection=True;Encrypt=False;";

            using SqlConnection connection = new(connectionString);
            connection.Open();
            string query = "SELECT * FROM Productos";

            using SqlCommand command = new(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Productos.Add(new Productos
                {
                    ProductosId = reader.GetInt32(0),
                    Nombre = reader["Nombre"]?.ToString() ?? string.Empty,
                    Descripcion = reader["Descripcion"]?.ToString() ?? string.Empty,
                    Precio = (decimal)reader["Precio"],
                    Stock = (int)reader["Stock"]
                });

            }
        }
    }
}

