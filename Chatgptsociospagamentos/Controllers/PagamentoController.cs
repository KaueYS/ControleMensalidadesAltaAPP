using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chatgptsociospagamentos.Data;
using Chatgptsociospagamentos.Models;

using Microsoft.AspNetCore.Authorization;

namespace Chatgptsociospagamentos.Controllers
{
    [Authorize]
    public class PagamentoController : Controller
    {
        private readonly AppDbContext _context;

        public PagamentoController(AppDbContext context)
        {
            _context = context;
        }





        public IActionResult Index(string statusFiltro, int? page)
        {
            var pagamentos = _context.Pagamentos
                                     .Include(p => p.Associado).ToList()
                                     .Where(x => x.Associado.Ativo == true);
            
            

            return View(pagamentos);
        }
       
        // GET: Pagamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.Associado)
                .FirstOrDefaultAsync(m => m.PagamentoId == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // GET: Pagamento/Create
        public IActionResult Create()
        {
            ViewData["AssociadoId"] = new SelectList(_context.Associados.OrderBy(x => x.Nome), "AssociadoId", "Nome");
            
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoId,AssociadoId,Valor,DataPagamento,")] Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                double diarias = 0.60;
                double dias = 0;
                DateTime suporte = DateTime.Now;

                var pagamentoBD = await _context.Pagamentos.FirstOrDefaultAsync(x => x.AssociadoId == pagamento.AssociadoId);

                if (pagamentoBD != null)
                {
                    dias = pagamento.Valor * diarias;
                    suporte = pagamentoBD.Validade.AddDays(Convert.ToInt32(dias));
                    pagamentoBD.Validade= suporte;
                    pagamentoBD.Valor += pagamento.Valor;
                    pagamentoBD.DataPagamento = pagamento.DataPagamento;
                   
                   
                    
                    _context.Update(pagamentoBD);
                }
                else
                {
                    dias = pagamento.Valor * diarias;
                    pagamento.Validade = pagamento.DataPagamento.AddDays(Convert.ToInt32(dias));
                    
                    
                    
                    _context.Add(pagamento);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssociadoId"] = new SelectList(_context.Associados, "AssociadoId", "AssociadoId", pagamento.AssociadoId);
            


            return View(pagamento);
        }



        // GET: Pagamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }
            ViewData["AssociadoId"] = new SelectList(_context.Associados, "AssociadoId", "Nome", pagamento.AssociadoId);
            return View(pagamento);
        }

        // POST: Pagamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssociadoId,Valor,DataPagamento")] Pagamento pagamento)
        {
            if (id != pagamento.PagamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoExists(pagamento.PagamentoId))
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
            ViewData["AssociadoId"] = new SelectList(_context.Associados, "AssociadoId", "AssociadoId", pagamento.AssociadoId);
            return View(pagamento);
        }

        // GET: Pagamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamento = await _context.Pagamentos
                .Include(p => p.Associado)
                .FirstOrDefaultAsync(m => m.PagamentoId == id);
            if (pagamento == null)
            {
                return NotFound();
            }

            return View(pagamento);
        }

        // POST: Pagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento != null)
            {
                _context.Pagamentos.Remove(pagamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoExists(int id)
        {
            return _context.Pagamentos.Any(e => e.PagamentoId == id);
        }
    }
}
