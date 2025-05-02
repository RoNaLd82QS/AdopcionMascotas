using Microsoft.AspNetCore.Mvc;
using SistemaAdopcionMascotas.Data;
using SistemaAdopcionMascotas.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaAdopcionMascotas.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Asignar()
        {
            ViewBag.Pets = _context.Pets.Where(p => p.Estado == "disponible").ToList();
            ViewBag.Adopters = _context.Adopters.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Asignar(int petId, int adopterId)
        {
            var pet = await _context.Pets.FindAsync(petId);
            if (pet == null || pet.Estado == "adoptada") return NotFound();

            var adoption = new Adoption { PetId = petId, AdopterId = adopterId };
            pet.Estado = "adoptada";

            _context.Adoptions.Add(adoption);
            await _context.SaveChangesAsync();

            return RedirectToAction("Lista");
        }

        public async Task<IActionResult> Lista()
        {
            var adopciones = await _context.Adoptions
                .Include(a => a.Pet)
                .Include(a => a.Adopter)
                .ToListAsync();

            return View("Lista", adopciones);
        }
    }
}
