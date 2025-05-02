using Microsoft.AspNetCore.Mvc;
using SistemaAdopcionMascotas.Data;
using SistemaAdopcionMascotas.Models;

namespace SistemaAdopcionMascotas.Controllers
{
    public class PetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Pet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Pets.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(pet);
        }
    }
}
