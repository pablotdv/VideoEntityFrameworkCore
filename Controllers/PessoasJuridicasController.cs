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
    public class PessoasJuridicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PessoasJuridicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PessoasJuridicas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoasJuridicas
                .SingleOrDefaultAsync(m => m.PessoaId == id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
        }

        // GET: PessoasJuridicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PessoasJuridicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeFantasia,PessoaId,Nome,CpfCnpj")] PessoaJuridica pessoaJuridica)
        {
            if (ModelState.IsValid)
            {
                pessoaJuridica.PessoaId = Guid.NewGuid();
                _context.Add(pessoaJuridica);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Pessoas");
            }
            return View(pessoaJuridica);
        }

        // GET: PessoasJuridicas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoasJuridicas.SingleOrDefaultAsync(m => m.PessoaId == id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }
            return View(pessoaJuridica);
        }

        // POST: PessoasJuridicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("NomeFantasia,PessoaId,Nome,CpfCnpj")] PessoaJuridica pessoaJuridica)
        {
            if (id != pessoaJuridica.PessoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaJuridica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaJuridicaExists(pessoaJuridica.PessoaId))
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
            return View(pessoaJuridica);
        }

        // GET: PessoasJuridicas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaJuridica = await _context.PessoasJuridicas
                .SingleOrDefaultAsync(m => m.PessoaId == id);
            if (pessoaJuridica == null)
            {
                return NotFound();
            }

            return View(pessoaJuridica);
        }

        // POST: PessoasJuridicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pessoaJuridica = await _context.PessoasJuridicas.SingleOrDefaultAsync(m => m.PessoaId == id);
            _context.PessoasJuridicas.Remove(pessoaJuridica);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Pessoas");
        }

        private bool PessoaJuridicaExists(Guid id)
        {
            return _context.PessoasJuridicas.Any(e => e.PessoaId == id);
        }
    }
}
