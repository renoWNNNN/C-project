using Microsoft.AspNetCore.Mvc;
using SPAKLY.Modelos;
using Microsoft.Data.SqlClient;
using SPAKLY.Datos;

namespace SPAKLY.Web.Controllers
{
    public class EnviosController : Controller
    {
        private readonly string connectionString = "Server=localhost;Database=SpaklyDb;Trusted_Connection=True;Encrypt=False;";
        private readonly SPAKLYDbContext _context;

        public EnviosController(SPAKLYDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var envios = new List<Envio>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT EnvioId, Direccion, FechaEnvio, Estado FROM Envios";

                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    envios.Add(new Envio
                    {
                        EnvioId = reader.GetInt32(0),
                        Direccion = reader.GetString(1),
                        FechaEnvio = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2),
                        Estado = reader.GetString(3),
                    });
                }
            }

            return View(envios);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Envio envio)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var query = "INSERT INTO Envios (Direccion, FechaEnvio, Estado) VALUES ( @Direccion, @FechaEnvio, @Estado)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Direccion", envio.Direccion);
            command.Parameters.AddWithValue("@FechaEnvio", envio.FechaEnvio);
            command.Parameters.AddWithValue("@Estado", envio.Estado);
            command.ExecuteNonQuery();

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var envio = _context.Envios.FirstOrDefault(e => e.EnvioId == id);
            if (envio == null)
                return RedirectToAction("Index");

            return View(envio);
        }

        [HttpPost]
        public IActionResult Editar(Envio envio)
        {
            if (!ModelState.IsValid)
            {
                return View(envio);
            }

            _context.Envios.Update(envio);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var envio = _context.Envios.FirstOrDefault(e => e.EnvioId == id);

            if (envio == null)
            {
                return RedirectToAction("Index");
            }

            return View(envio);
        }

        [HttpPost]
        public IActionResult Eliminar(int id, Envio envio)
        {
            var envioToDelete = _context.Envios.FirstOrDefault(e => e.EnvioId == id);

            if (envioToDelete != null)
            {
                _context.Envios.Remove(envioToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
