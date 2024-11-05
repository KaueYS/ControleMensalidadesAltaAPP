using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chatgptsociospagamentos.Data;
using Chatgptsociospagamentos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Chatgptsociospagamentos.Controllers
{
    [Authorize]
    public class AssociadoController : Controller
    {


        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AssociadoController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Associado
        public async Task<IActionResult> Index()
        {
            return View(await _context.Associados.ToListAsync());
        }

        // GET: Associado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
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
        public async Task<IActionResult> Create([Bind("AssociadoId,Nome,Email,Documento,Telefone,DataAniversario,Ativo")] Associado associado)
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
            if (id == null)
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
        public async Task<IActionResult> Edit(int id, [Bind("AssociadoId,Nome,Email,Documento,Telefone,DataAniversario,Ativo")] Associado associado)
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
            if (id == null)
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
            return _context.Associados.Any(e => e.AssociadoId == id);
        }
    }
}
