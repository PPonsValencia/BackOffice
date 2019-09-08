using BackOffice.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOffice.ViewComponents
{
    public class CursosDestacadosViewComponent : ViewComponent
    {
        
        private IEnumerable<Curso> _cursos;


        public CursosDestacadosViewComponent()
        {
            CursosDbContext context = new CursosDbContext();
            _cursos = context.Cursos.ToList();
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.CursosDestacados = _cursos.Where(x => x.Destacado);

            return Task.FromResult<IViewComponentResult>(View("Show"));
        }
    }
}
