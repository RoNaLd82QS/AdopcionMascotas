using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAdopcionMascotas.Data;
using SistemaAdopcionMascotas.Models;

namespace SistemaAdopcionMascotas.Controllers
{
    public class AdopterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdopterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Adopter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Adopter/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Adopter adopter)
        {
            if (ModelState.IsValid)
            {
                _context.Adopters.Add(adopter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Lista");
            }
            return View(adopter);
        }

        // GET: /Adopter/Lista
        public async Task<IActionResult> Lista()
        {
            var adoptantes = await _context.Adopters.ToListAsync();
            return View(adoptantes);
        }
    }
}
