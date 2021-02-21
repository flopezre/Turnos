using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{   public class EspecialidadController : Controller
    {
        // Este es el objeto que vamos a inicializar en nuestro constructor
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {
            _context = context;
        }

        // Este metodo sera el que llamemos desde el navegador
        public async Task<IActionResult> Index()
        {
            // ToList es acceder a LINQ, que la operacion que realiza es similar
            // a un SELECT * FROM tabla
            return View( await _context.Especialidad.ToListAsync());
        }

        /**** Metodo editar desde la vista ****/
        public async Task<IActionResult> Edit(int? id) 
        { // ? permite valores nulos

            if(id == null) 
            {
                return NotFound(); // Retorna un error 404 
            }

            // Metodo Find es similar a un SELECT FROM WHERE
            var especialidad = await _context.Especialidad.FindAsync(id);

            if(especialidad == null) 
            {

                return NotFound();    
            }

            return View(especialidad);
        }

        /**** Metodo para editar desde la vista ****/
        [HttpPost] // Indicamos que este metodo va hacer el POST
                    // Esto diferencia al metodo que graba y edita
        /**** Bind permite enlazar los datos en el formulario ****/
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad,descripcion")] Especialidad especialidad) 
        {
            if(id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }

            if(ModelState.IsValid) 
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        /*** Metodo para eliminar desde la vista***/
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            // Estamos ejecutando el metodo FirstOrDefaulr
            var especialidad = await _context.Especialidad.FirstOrDefaultAsync(e => e.IdEspecialidad == id);
            if(especialidad == null) 
            {
                return NotFound();
            }
            return View(especialidad);
        }

        /*** Metodo para eliminar desde la vista mediante POST ***/
        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            var especialidad = await _context.Especialidad.FindAsync(id);
            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**** Metodo para crear nuevas especialidades desde la vista ****/
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEspecialidad", "descripcion")] Especialidad especialidad)
        {
            if(ModelState.IsValid) 
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}