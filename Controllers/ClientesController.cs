using Microsoft.AspNetCore.Mvc;
using FerreteriaValdivia.Models;

namespace FerreteriaValdivia.Controllers
{
    public class ClientesController : Controller
    {
        // Lista temporal en memoria
        private static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nombre = "Juan", Apellido = "Pérez", Telefono = "70012345", Email = "juan@gmail.com" },
            new Cliente { Id = 2, Nombre = "María", Apellido = "Gómez", Telefono = "70054321", Email = "maria@gmail.com" }
        };

        public IActionResult Index() => View(clientes);

        public IActionResult Crear() => View();

        [HttpPost]
        public IActionResult Crear(Cliente cliente)
        {
            cliente.Id = clientes.Count > 0 ? clientes.Max(c => c.Id) + 1 : 1;
            clientes.Add(cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            var existente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (existente != null)
            {
                existente.Nombre = cliente.Nombre;
                existente.Apellido = cliente.Apellido;
                existente.Telefono = cliente.Telefono;
                existente.Email = cliente.Email;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null) clientes.Remove(cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Buscar(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return View(clientes);
            var resultados = clientes.Where(c => 
                c.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase) || 
                c.Apellido.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
            return View(resultados);
        }
    }
}