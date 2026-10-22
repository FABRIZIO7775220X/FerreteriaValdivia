using Microsoft.AspNetCore.Mvc;
using FerreteriaValdivia.Data;
using FerreteriaValdivia.Models;

namespace FerreteriaValdivia.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppDbContext _context;

        // Inyección de dependencias de la base de datos
        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // Listar todos los clientes desde MariaDB
        public IActionResult Index()
        {
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        // Mostrar formulario para crear cliente
        public IActionResult Crear() => View();

        // Guardar nuevo cliente en MariaDB
        [HttpPost]
        public IActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // Mostrar formulario para editar cliente
        public IActionResult Editar(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // Guardar cambios del cliente editado
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // Eliminar un cliente por ID
        public IActionResult Eliminar(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Pestaña "Actualizar" del menú superior
        public IActionResult Actualizar()
        {
            return View("Index", _context.Clientes.ToList());
        }

        // Pestaña "Eliminar" del menú superior
        public IActionResult EliminarPagina()
        {
            return View("Index", _context.Clientes.ToList());
        }
    }
}