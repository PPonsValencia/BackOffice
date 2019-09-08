using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackOffice.Models.Context;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BackOffice.Controllers
{
    public class CursosController : Controller
    {
        private readonly CursosDbContext _context;

        public CursosController(CursosDbContext context)
        {
            _context = context;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
            var cursosDbContext = _context.Cursos.Include(c => c.Categoria);
            return View(await cursosDbContext.ToListAsync());
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.CodCurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Cursos/Create
        public IActionResult Create()
        {
            ViewData["CodCategoria"] = new SelectList(_context.Categorias, "CodCategoria", "Descripcion");
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCurso,Descripcion,CodCategoria,Destacado,Fecha")] Curso curso, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        image.OpenReadStream().CopyTo(memoryStream);
                        curso.ImageMimeType = image.ContentType;
                        curso.Imagen = new byte[memoryStream.Length];
                        curso.Imagen = memoryStream.ToArray();
                    }
                }

                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodCategoria"] = new SelectList(_context.Categorias, "CodCategoria", "Descripcion", curso.CodCategoria);
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            ViewData["CodCategoria"] = new SelectList(_context.Categorias, "CodCategoria", "Descripcion", curso.CodCategoria);
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodCurso,Descripcion,Imagen,CodCategoria,Destacado,Fecha")] Curso curso)
        {
            if (id != curso.CodCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.CodCurso))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodCategoria"] = new SelectList(_context.Categorias, "CodCategoria", "Descripcion", curso.CodCategoria);
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.CodCurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public FileContentResult GetImg(int id)
        {
            //Get the right photo
            Curso curso = _context.Cursos.Where(x => x.CodCurso == id).FirstOrDefault();
            if (curso != null)
            {
                return File(curso.Imagen, curso.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(e => e.CodCurso == id);
        }
    }
}
