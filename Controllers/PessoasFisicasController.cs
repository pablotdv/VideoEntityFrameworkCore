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
    public class PessoasFisicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PessoasFisicasController(ApplicationDbContext context)
        {
            _context = context;
        }
                
        // GET: PessoasFisicas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .SingleOrDefaultAsync(m => m.PessoaId == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // GET: PessoasFisicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoasFisicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sexo,PessoaId,Nome,CpfCnpj")] PessoaFisica pessoaFisica)
        {
            if (ModelState.IsValid)
            {
                pessoaFisica.PessoaId = Guid.NewGuid();
                _context.Add(pessoaFisica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Pessoas");
            }
            return View(pessoaFisica);
        }

        // GET: PessoasFisicas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas.SingleOrDefaultAsync(m => m.PessoaId == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }
            return View(pessoaFisica);
        }

        // POST: PessoasFisicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Sexo,PessoaId,Nome,CpfCnpj")] PessoaFisica pessoaFisica)
        {
            if (id != pessoaFisica.PessoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaFisica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaFisicaExists(pessoaFisica.PessoaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Pessoas");
            }
            return View(pessoaFisica);
        }

        // GET: PessoasFisicas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = await _context.PessoasFisicas
                .SingleOrDefaultAsync(m => m.PessoaId == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return View(pessoaFisica);
        }

        // POST: PessoasFisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pessoaFisica = await _context.PessoasFisicas.SingleOrDefaultAsync(m => m.PessoaId == id);
            _context.PessoasFisicas.Remove(pessoaFisica);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Pessoas");
        }

        private bool PessoaFisicaExists(Guid id)
        {
            return _context.PessoasFisicas.Any(e => e.PessoaId == id);
        }
    }
}
