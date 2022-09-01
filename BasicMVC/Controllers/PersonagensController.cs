using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasicMVC.Data;
using BasicMVC.Models;

namespace BasicMVC.Controllers
{
    public class PersonagensController : Controller
    {
        private readonly AppDbContext _context;

        public PersonagensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Personagens
        public async Task<IActionResult> Index()
        {
              return _context.Personagens != null ? 
                          View(await _context.Personagens.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Personagens'  is null.");
        }

        // GET: Personagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personagens == null)
            {
                return NotFound();
            }

            var personagem = await _context.Personagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personagem == null)
            {
                return NotFound();
            }

            return View(personagem);
        }

        // GET: Personagens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Descricao")] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personagem);
        }

        // GET: Personagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personagens == null)
            {
                return NotFound();
            }

            var personagem = await _context.Personagens.FindAsync(id);
            if (personagem == null)
            {
                return NotFound();
            }
            return View(personagem);
        }

        // POST: Personagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Descricao")] Personagem personagem)
        {
            if (id != personagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonagemExists(personagem.Id))
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
            return View(personagem);
        }

        // GET: Personagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personagens == null)
            {
                return NotFound();
            }

            var personagem = await _context.Personagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personagem == null)
            {
                return NotFound();
            }

            return View(personagem);
        }

        // POST: Personagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personagens == null)
            {
                return Problem("Entity set 'AppDbContext.Personagens'  is null.");
            }
            var personagem = await _context.Personagens.FindAsync(id);
            if (personagem != null)
            {
                _context.Personagens.Remove(personagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonagemExists(int id)
        {
          return (_context.Personagens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
