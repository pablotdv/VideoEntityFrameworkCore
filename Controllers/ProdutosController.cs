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
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos
                .Include(a => a.ProdutoGrupo)
                .ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(a => a.ProdutoGrupo)
                .SingleOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["ProdutoGrupoId"] = new SelectList(_context.ProdutosGrupos
                .OrderBy(a => a.Nome), "ProdutoGrupoId", "Nome");

            return View(new Produto()
            {
                ProdutoId = Guid.NewGuid(),
                Categorias = new List<ProdutoCategoria>()
            });
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ProdutoId,ProdutoGrupoId,Nome,Valor,Categorias")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (produto.ProdutoId == Guid.Empty)
                    produto.ProdutoId = Guid.NewGuid();
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProdutoGrupoId"] = new SelectList(_context.ProdutosGrupos
                .OrderBy(a => a.Nome), "ProdutoGrupoId", "Nome",
                produto.ProdutoGrupoId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(a => a.Categorias)
                .SingleOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            ViewData["ProdutoGrupoId"] = new SelectList(_context.ProdutosGrupos
               .OrderBy(a => a.Nome), "ProdutoGrupoId", "Nome",
               produto.ProdutoGrupoId);

            ViewData["CategoriaId"] = new SelectList(_context.Categorias
                .OrderBy(a => a.Nome), "CategoriaId", "Nome");
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, 
            [Bind("ProdutoId,ProdutoGrupoId,Nome,Valor,Categorias")] Produto viewModel)
        {
            if (id != viewModel.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var produto = await _context.Produtos
                        .Include(a => a.Categorias)
                        .SingleOrDefaultAsync(a => a.ProdutoId == id);
                    produto.ProdutoGrupoId = viewModel.ProdutoGrupoId;
                    produto.Nome = viewModel.Nome;
                    produto.Valor = viewModel.Valor;

                    if (viewModel.Categorias == null)
                    {
                        viewModel.Categorias = new List<ProdutoCategoria>();
                    }

                    foreach(var categoriaViewModel in viewModel.Categorias)
                    {
                        var categoria = produto.Categorias
                            .FirstOrDefault(a => a.ProdutoCategoriaId == categoriaViewModel.ProdutoCategoriaId);

                        if (categoria == null)
                        {
                            produto.Categorias.Add(categoriaViewModel);
                        }
                        else
                        {
                            categoria.CategoriaId = categoriaViewModel.CategoriaId;
                        }
                    }

                    var categorias = produto.Categorias.ToList();
                    foreach (var categoria in categorias)
                    {
                        if (!viewModel.Categorias
                            .Any(a => a.ProdutoCategoriaId == categoria.ProdutoCategoriaId))
                        {
                            _context.ProdutosCategorias.Remove(categoria);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(viewModel.ProdutoId))
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

            ViewData["ProdutoGrupoId"] = new SelectList(_context.ProdutosGrupos
               .OrderBy(a => a.Nome), "ProdutoGrupoId", "Nome",
               viewModel.ProdutoGrupoId);
            return View(viewModel);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(a => a.ProdutoGrupo)
                .SingleOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await _context.Produtos.SingleOrDefaultAsync(m => m.ProdutoId == id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AdicionarCategoria()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias.OrderBy(a => a.Nome),
                "CategoriaId", "Nome");

            return PartialView("_Categoria", new ProdutoCategoria()
            {
                ProdutoCategoriaId = Guid.NewGuid(),
            });
        }

        private bool ProdutoExists(Guid id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
