using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAdopcionMascotas.Models
{
    public class Adoption
    {
        public int Id { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; } = null!;

        public int AdopterId { get; set; }
        public Adopter Adopter { get; set; } = null!;
    }
}