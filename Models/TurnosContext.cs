using Microsoft.EntityFrameworkCore;

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

        public DbSet<Medico> Medico { get; set; } // Agregado por scafolding

        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }

        public DbSet<Turno> T { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Especialidad>(entidad => {
                entidad.ToTable("Especialidad");
                entidad.HasKey(e => e.IdEspecialidad);
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

            modelBuilder.Entity<Medico>(entidad => {
                entidad.ToTable("Medico");

                entidad.HasKey(m => m.IdMedico);

                entidad.Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(m => m.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.HorarioAtencionDesde)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.HorarioAtencionHasta)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new {x.IdMedico, x.IdEspecialidad});

            // ForeingKey en EF
            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Medico)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdMedico);
            
            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Especialidad)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdEspecialidad);

            modelBuilder.Entity<Turno>(entidad => {

                entidad.ToTable("Turno");

                entidad.HasKey(m => m.IdTurno);

                entidad.Property(m => m.IdPaciente)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.IdMedico)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.FechaHoraInicio)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.FechaHoraFin)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            });
            
            // Restriccion (Relacion entre la tabla Paciente y Turno)
            modelBuilder.Entity<Turno>().HasOne(x => x.Paciente)
            .WithMany(p => p.Turno)
            .HasForeignKey(p => p.IdPaciente);

            modelBuilder.Entity<Turno>().HasOne(x => x.Medico)
            .WithMany(p => p.Turno)
            .HasForeignKey(p => p.IdMedico);
        }
    }
}