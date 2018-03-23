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
    public class ProdutosGruposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosGruposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProdutosGrupos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProdutosGrupos.ToListAsync());
        }

        // GET: ProdutosGrupos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoGrupo = await _context.ProdutosGrupos
                .SingleOrDefaultAsync(m => m.ProdutoGrupoId == id);
            if (produtoGrupo == null)
            {
                return NotFound();
            }

            return View(produtoGrupo);
        }

        // GET: ProdutosGrupos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdutosGrupos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoGrupoId,Nome")] ProdutoGrupo produtoGrupo)
        {
            if (ModelState.IsValid)
            {
                produtoGrupo.ProdutoGrupoId = Guid.NewGuid();
                _context.Add(produtoGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtoGrupo);
        }

        // GET: ProdutosGrupos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoGrupo = await _context.ProdutosGrupos.SingleOrDefaultAsync(m => m.ProdutoGrupoId == id);
            if (produtoGrupo == null)
            {
                return NotFound();
            }
            return View(produtoGrupo);
        }

        // POST: ProdutosGrupos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProdutoGrupoId,Nome")] ProdutoGrupo produtoGrupo)
        {
            if (id != produtoGrupo.ProdutoGrupoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoGrupoExists(produtoGrupo.ProdutoGrupoId))
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
            return View(produtoGrupo);
        }

        // GET: ProdutosGrupos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoGrupo = await _context.ProdutosGrupos
                .SingleOrDefaultAsync(m => m.ProdutoGrupoId == id);
            if (produtoGrupo == null)
            {
                return NotFound();
            }

            return View(produtoGrupo);
        }

        // POST: ProdutosGrupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoGrupo = await _context.ProdutosGrupos.SingleOrDefaultAsync(m => m.ProdutoGrupoId == id);
            _context.ProdutosGrupos.Remove(produtoGrupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoGrupoExists(Guid id)
        {
            return _context.ProdutosGrupos.Any(e => e.ProdutoGrupoId == id);
        }
    }
}
