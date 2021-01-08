using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _context;

        public PacienteController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == id);
            if(paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        /* Creacion del metodo create como ejercicio*/

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        // Valida que nuestro metodo create a sido ejecutado atravez del formulario
        // y no atravez de la url del navegador
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create([Bind("IdPaciente, Nombre, Apellido, Direccion, Telefono, Email")] Paciente paciente)
        {
            if(ModelState.IsValid) 
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {   
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(id);

            if(paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente, Nombre, Apellido, Direccion, Telefono, Email")] Paciente paciente)
        {
            if(id != paciente.IdPaciente)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _context.Update(paciente);
                await _context.SaveChangesAsync();
                RedirectToAction(nameof(Index));
            }

            return View(paciente);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == id);

            if(paciente == null)
            {
                return View(paciente);
            }
            return View(paciente);
        }


            [HttpPost, ActionName("Delete")] // Definimos un alias para el metodo DeleteConfirmed quedando como Delete
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int? id)
            {
                if(id == null)
                {
                    return NotFound();
                }

                var paciente = await _context.Paciente.FindAsync(id);

                if(paciente == null)
                {
                    return NotFound();
                }

                _context.Paciente.Remove(paciente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
    }
}