using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class TurnoController : Controller
    {
        private readonly TurnosContext _context;

        private IConfiguration _configuration;

        public TurnoController(TurnosContext context, IConfiguration configuration) {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index() {

            ViewData["IdMedico"]
            return View();
        }
    }
}