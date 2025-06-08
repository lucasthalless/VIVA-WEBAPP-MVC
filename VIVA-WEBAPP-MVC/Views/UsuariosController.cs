using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOTTHRU.API.Domain.Entities;
using MOTTHRU.API.Infrastructure.Data.AppData;

namespace VIVA_WEBAPP_MVC.Views
{
    // [ApiController]
    // [Route("/api/usuario")]
    public class UsuariosController : Controller
    {
        private readonly ApplicationContext _context;

        public UsuariosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.usuario.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEntity = await _context.usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioEntity == null)
            {
                return NotFound();
            }

            return View(usuarioEntity);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Telefone,Email,TipoUsuario")] UsuarioEntity usuarioEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioEntity);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEntity = await _context.usuario.FindAsync(id);
            if (usuarioEntity == null)
            {
                return NotFound();
            }
            return View(usuarioEntity);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Cpf,Telefone,Email,TipoUsuario")] UsuarioEntity usuarioEntity)
        {
            if (id != usuarioEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioEntityExists(usuarioEntity.Id))
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
            return View(usuarioEntity);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEntity = await _context.usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioEntity == null)
            {
                return NotFound();
            }

            return View(usuarioEntity);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var usuarioEntity = await _context.usuario.FindAsync(id);
            if (usuarioEntity != null)
            {
                _context.usuario.Remove(usuarioEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioEntityExists(long id)
        {
            return _context.usuario.Any(e => e.Id == id);
        }
    }
}
