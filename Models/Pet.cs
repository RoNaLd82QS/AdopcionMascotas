using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAdopcionMascotas.Models
{
    // Models/Pet.cs
public class Pet {
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public int Edad { get; set; }
    public string Tipo { get; set; } = "";
    public string Estado { get; set; } = "disponible"; // disponible o adoptada

    public Adoption? Adopcion { get; set; }
}

}