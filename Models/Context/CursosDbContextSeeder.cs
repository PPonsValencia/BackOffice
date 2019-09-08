using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.Models.Context
{
    public static class CursosDbContextSeeder
    {
        public static void Seed(CursosDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Add(new Curso()
            {
                Descripcion = "Patrones"
            });
            context.Add(new Curso()
            {
                Descripcion = ".Net Framework",
                Destacado = true
            });
            context.Add(new Curso()
            {
                Descripcion = ".Net Core",
                Destacado = false
            });

            context.SaveChanges();
        }
    }
}
