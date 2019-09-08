using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.Models.Context
{
    public class CursosDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = CursosDB; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                        .Property(p => p.Imagen)
                        .HasColumnType("image");
            modelBuilder.Entity<Categoria>()
                        .Property(p => p.Fecha)
                        .HasColumnType("date");
            modelBuilder.Entity<Curso>()
                        .Property(p => p.Imagen)
                        .HasColumnType("image");
            modelBuilder.Entity<Curso>()
                        .Property(p => p.Fecha)
                        .HasColumnType("date");
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Curso> Cursos { get; set; }
    }
}
