using Microsoft.EntityFrameworkCore;
using SistemaAdopcionMascotas.Models;

namespace SistemaAdopcionMascotas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets => Set<Pet>();
        public DbSet<Adopter> Adopters => Set<Adopter>();
        public DbSet<Adoption> Adoptions => Set<Adoption>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Adopcion)
                .WithOne(a => a.Pet)
                .HasForeignKey<Adoption>(a => a.PetId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
