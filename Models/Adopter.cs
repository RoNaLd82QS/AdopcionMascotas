using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAdopcionMascotas.Models
{
    public class Adopter
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public List<Adoption> Adopciones { get; set; } = new();
    }
}