using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOTTHRU.API.Application.Interfaces;
using MOTTHRU.API.Domain.Entities;
using MOTTHRU.API.Infrastructure.Data.AppData;
using Swashbuckle.AspNetCore.Annotations;

namespace VIVA_WEBAPP_MVC.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    [Produces("application/json")]
    public class UsuariosApiController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsuariosApiController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Obter todos os usuários",
            Description = "Retorna uma lista com todas os usuários cadastrados."
        )]
        [ProducesResponseType(typeof(IEnumerable<UsuarioEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UsuarioEntity>>> GetAll()
        {
            return Ok(await _context.usuario.ToListAsync());
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obter usuário por ID",
            Description = "Retorna um usuário específico pelo ID."
        )]
        [ProducesResponseType(typeof(UsuarioEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<UsuarioEntity>> GetById(long id)
        {
            var usuario = await _context.usuario.FindAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Cadastrar novo usuário",
            Description = "Cria um novo usuário no sistema com base nos dados enviados."
        )]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UsuarioEntity), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<UsuarioEntity>> Create([FromBody] UsuarioEntity usuario)
        {
            _context.usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualizar usuário existente",
            Description = "Atualiza os dados de um usuário já cadastrado, com base no ID"
        )]
        [Consumes("application/json")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update(long id, [FromBody] UsuarioEntity usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletar usuário",
            Description = "Atualiza os dados de um usuário já cadastrado com base no ID"
        )]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteUsuario(long id)
        {
            var usuario = await _context.usuario.FindAsync(id);
            if (usuario == null)
                return NotFound();

            _context.usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(long id)
        {
            return _context.usuario.Any(e => e.Id == id);
        }
    }
}
