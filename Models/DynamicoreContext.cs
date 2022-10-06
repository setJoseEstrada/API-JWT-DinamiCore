using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DynamiCore.Models
{
    public partial class DynamicoreContext : DbContext
    {
        public DynamicoreContext()
        {
        }

        public DynamicoreContext(DbContextOptions<DynamicoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acceso> Accesos { get; set; }
        public virtual DbSet<Contacto> Contactos { get; set; }
        public virtual DbSet<Directorio> Directorios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server= JOSE-ESTRADA\\MSSQLSERVER01;Database=Dynamicore; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Acceso>(entity =>
            {
                entity.ToTable("Acceso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Curp)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("curp");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");
            });

            modelBuilder.Entity<Directorio>(entity =>
            {
                entity.ToTable("Directorio");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdContacto).HasColumnName("idContacto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdContactoNavigation)
                    .WithMany(p => p.Directorios)
                    .HasForeignKey(d => d.IdContacto)
                    .HasConstraintName("FK__Directori__idCon__37A5467C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Directorios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Directori__idUsu__36B12243");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Curp)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("curp");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
