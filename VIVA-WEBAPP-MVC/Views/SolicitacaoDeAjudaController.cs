using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOTTHRU.API.Domain.Entities;
using MOTTHRU.API.Domain.Interfaces;
using MOTTHRU.API.Infrastructure.Data.AppData;

namespace VIVA_WEBAPP_MVC.Views
{
    // [ApiController]
    // [Route("[controller]")]
    public class SolicitacaoDeAjudaController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IUsuarioRepository _usuarioRepository;

        public SolicitacaoDeAjudaController(ApplicationContext context, IUsuarioRepository usuarioRepository)
        {
            _context = context;
            _usuarioRepository = usuarioRepository;
        }

        // GET: SolicitacaoDeAjuda
        public async Task<IActionResult> Index()
        {
            return View(await _context.solicitacaoDeAjuda.Include(s => s.Usuario).ToListAsync());
        }

        // GET: SolicitacaoDeAjuda/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacaoDeAjuda = await _context.solicitacaoDeAjuda
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitacaoDeAjuda == null)
            {
                return NotFound();
            }

            return View(solicitacaoDeAjuda);
        }

        // GET: SolicitacaoDeAjuda/Create
        public IActionResult Create()
        {
            var listUsuarios = _usuarioRepository.GetAll();
            
            ViewBag.Usuarios = new SelectList(listUsuarios, "Id", "Nome");
            
            return View();
        }

        // POST: SolicitacaoDeAjuda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,TipoSolicitacao,Conteudo,DataHora,Status,Nivel,IdUsuario")]
            SolicitacaoDeAjudaEntity solicitacaoDeAjuda)
        {
            if (ModelState.IsValid)
            {
                solicitacaoDeAjuda.DataHora = DateTime.SpecifyKind(solicitacaoDeAjuda.DataHora, DateTimeKind.Utc);
                _context.Add(solicitacaoDeAjuda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}");
                    foreach (var subError in error.Value.Errors)
                    {
                        Console.WriteLine($"  Error: {subError.ErrorMessage}");
                    }
                }
            }
            
            var listUsuarios = _usuarioRepository.GetAll();

            ViewBag.Usuarios = new SelectList(listUsuarios, "Id", "Nome", solicitacaoDeAjuda.IdUsuario);
            
            return View(solicitacaoDeAjuda);
        }

        // GET: SolicitacaoDeAjuda/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacaoDeAjuda = await _context.solicitacaoDeAjuda.FindAsync(id);
            if (solicitacaoDeAjuda == null)
            {
                return NotFound();
            }
            
            var listUsuarios = _usuarioRepository.GetAll();
            ViewBag.Usuarios = new SelectList(listUsuarios, "Id", "Nome", solicitacaoDeAjuda.IdUsuario);

            return View(solicitacaoDeAjuda);
        }

        // POST: SolicitacaoDeAjuda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,
            [Bind("Id,TipoSolicitacao,Conteudo,DataHora,Status,Nivel,IdUsuario,Usuario")]
            SolicitacaoDeAjudaEntity solicitacaoDeAjuda)
        {
            if (id != solicitacaoDeAjuda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitacaoDeAjuda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitacaoDeAjudaExists(solicitacaoDeAjuda.Id))
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

            var listUsuarios = _usuarioRepository.GetAll();
            ViewBag.Usuarios = new SelectList(listUsuarios, "Id", "Nome", solicitacaoDeAjuda.IdUsuario);
            return View(solicitacaoDeAjuda);
        }

        // GET: SolicitacaoDeAjuda/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitacaoDeAjuda = await _context.solicitacaoDeAjuda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitacaoDeAjuda == null)
            {
                return NotFound();
            }

            return View(solicitacaoDeAjuda);
        }

        // POST: SolicitacaoDeAjuda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var solicitacaoDeAjuda = await _context.solicitacaoDeAjuda.FindAsync(id);
            if (solicitacaoDeAjuda != null)
            {
                _context.solicitacaoDeAjuda.Remove(solicitacaoDeAjuda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitacaoDeAjudaExists(long id)
        {
            return _context.solicitacaoDeAjuda.Any(e => e.Id == id);
        }
    }
}