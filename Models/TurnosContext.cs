using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models // Con esto podemos referenciarlos a en otras clases
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> optiones)
        : base(optiones) 
        { 
            
        }

        public DbSet<Especialidad> Especialidad { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Medico> Medico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad => {
                entidad.ToTable("Especialidad");
                entidad.HasKey(e => e.idEspecialidad);
                entidad.Property(e => e.descripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>(entidad => 
            {
                entidad.ToTable("Paciente");

                entidad.HasKey(p => p.IdPaciente);

                entidad.Property(p => p.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entidad.Property(p => p.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entidad.Property(p => p.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entidad.Property(p => p.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entidad.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }

    }
}