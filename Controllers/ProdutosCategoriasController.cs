using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoEntityFrameworkCore.Data;
using VideoEntityFrameworkCore.Models;

namespace VideoEntityFrameworkCore.Controllers
{
    public class ProdutosCategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosCategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProdutosCategorias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProdutosCategorias.Include(p => p.Categoria).Include(p => p.Produto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProdutosCategorias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoCategoria = await _context.ProdutosCategorias
                .Include(p => p.Categoria)
                .Include(p => p.Produto)
                .SingleOrDefaultAsync(m => m.ProdutoCategoriaId == id);
            if (produtoCategoria == null)
            {
                return NotFound();
            }

            return View(produtoCategoria);
        }

        // GET: ProdutosCategorias/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome");
            return View();
        }

        // POST: ProdutosCategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoCategoriaId,ProdutoId,CategoriaId")] ProdutoCategoria produtoCategoria)
        {
            if (ModelState.IsValid)
            {
                produtoCategoria.ProdutoCategoriaId = Guid.NewGuid();
                _context.Add(produtoCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome", produtoCategoria.CategoriaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", produtoCategoria.ProdutoId);
            return View(produtoCategoria);
        }

        // GET: ProdutosCategorias/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoCategoria = await _context.ProdutosCategorias.SingleOrDefaultAsync(m => m.ProdutoCategoriaId == id);
            if (produtoCategoria == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome", produtoCategoria.CategoriaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", produtoCategoria.ProdutoId);
            return View(produtoCategoria);
        }

        // POST: ProdutosCategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProdutoCategoriaId,ProdutoId,CategoriaId")] ProdutoCategoria produtoCategoria)
        {
            if (id != produtoCategoria.ProdutoCategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoCategoriaExists(produtoCategoria.ProdutoCategoriaId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome", produtoCategoria.CategoriaId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", produtoCategoria.ProdutoId);
            return View(produtoCategoria);
        }

        // GET: ProdutosCategorias/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoCategoria = await _context.ProdutosCategorias
                .Include(p => p.Categoria)
                .Include(p => p.Produto)
                .SingleOrDefaultAsync(m => m.ProdutoCategoriaId == id);
            if (produtoCategoria == null)
            {
                return NotFound();
            }

            return View(produtoCategoria);
        }

        // POST: ProdutosCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoCategoria = await _context.ProdutosCategorias.SingleOrDefaultAsync(m => m.ProdutoCategoriaId == id);
            _context.ProdutosCategorias.Remove(produtoCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoCategoriaExists(Guid id)
        {
            return _context.ProdutosCategorias.Any(e => e.ProdutoCategoriaId == id);
        }
    }
}
