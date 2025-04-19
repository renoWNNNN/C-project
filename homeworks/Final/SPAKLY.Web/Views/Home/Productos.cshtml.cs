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
                       Precio = (decimal)reader["Precio"],
                       Stock = (int)reader["Stock"]
                    });

                    }
                }
            }
        }
    }
}

