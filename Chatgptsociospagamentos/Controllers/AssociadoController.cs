using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chatgptsociospagamentos.Data;
using Chatgptsociospagamentos.Models;

namespace Chatgptsociospagamentos.Controllers
{
    public class AssociadoController : Controller
    {
        private readonly AppDbContext _context;

        public AssociadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Associado
        public async Task<IActionResult> Index()
        {
            return _context.Associados != null ?
                        View(await _context.Associados.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Associados'  is null.");
        }

        // GET: Associado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Associados == null)
            {
                return NotFound();
            }

            var associado = await _context.Associados
                .FirstOrDefaultAsync(m => m.AssociadoId == id);
            if (associado == null)
            {
                return NotFound();
            }

            return View(associado);
        }

        // GET: Associado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Associado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssociadoId,Nome,Documento,Email,Telefone,Endereco,DataAniversario,Categoria,Equipamento,Necessidade,Ativo")] Associado associado)
        {
            if (ModelState.IsValid)
            {
                associado.Ativo = true;
                _context.Add(associado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(associado);
        }

        // GET: Associado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Associados == null)
            {
                return NotFound();
            }

            var associado = await _context.Associados.FindAsync(id);
            if (associado == null)
            {
                return NotFound();
            }
            return View(associado);
        }

        // POST: Associado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssociadoId,Nome,Documento,Email,Telefone,Endereco,DataAniversario,Categoria,Equipamento,Necessidade,Ativo")] Associado associado)
        {
            if (id != associado.AssociadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociadoExists(associado.AssociadoId))
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
            return View(associado);
        }

        // GET: Associado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Associados == null)
            {
                return NotFound();
            }

            var associado = await _context.Associados
                .FirstOrDefaultAsync(m => m.AssociadoId == id);
            if (associado == null)
            {
                return NotFound();
            }

            return View(associado);
        }

        // POST: Associado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Associados == null)
            {
                return Problem("Entity set 'AppDbContext.Associados'  is null.");
            }
            var associado = await _context.Associados.FindAsync(id);
            if (associado != null)
            {
                _context.Associados.Remove(associado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociadoExists(int id)
        {
          return (_context.Associados?.Any(e => e.AssociadoId == id)).GetValueOrDefault();
        }
    }
}
