using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOTTHRU.API.Domain.Entities;
using MOTTHRU.API.Domain.Interfaces;
using MOTTHRU.API.Infrastructure.Data.AppData;
using Swashbuckle.AspNetCore.Annotations;

namespace VIVA_WEBAPP_MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitacaoDeAjudaApiController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IUsuarioRepository _usuarioRepository;

        public SolicitacaoDeAjudaApiController(ApplicationContext context, IUsuarioRepository usuarioRepository)
        {
            _context = context;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna todas as solicitações de ajuda")]
        public async Task<ActionResult<IEnumerable<SolicitacaoDeAjudaEntity>>> GetAll()
        {
            return await _context.solicitacaoDeAjuda.ToListAsync();
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retorna uma solicitação de ajuda por ID")]
        [ProducesResponseType(typeof(SolicitacaoDeAjudaEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SolicitacaoDeAjudaEntity>> GetById(long id)
        {
            var solicitacao = await _context.solicitacaoDeAjuda.FindAsync(id);

            if (solicitacao == null)
                return NotFound();

            return solicitacao;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova solicitação de ajuda")]
        [ProducesResponseType(typeof(SolicitacaoDeAjudaEntity), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SolicitacaoDeAjudaEntity>> Create(SolicitacaoDeAjudaEntity solicitacaoDeAjuda)
        {
            solicitacaoDeAjuda.DataHora = DateTime.SpecifyKind(solicitacaoDeAjuda.DataHora, DateTimeKind.Utc);
            _context.Add(solicitacaoDeAjuda);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = solicitacaoDeAjuda.Id }, solicitacaoDeAjuda);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Atualiza uma solicitação de ajuda existente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(long id, SolicitacaoDeAjudaEntity solicitacaoDeAjuda)
        {
            if (id != solicitacaoDeAjuda.Id)
                return BadRequest();

            _context.Entry(solicitacaoDeAjuda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitacaoDeAjudaExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Exclui uma solicitação de ajuda por ID")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(long id)
        {
            var solicitacao = await _context.solicitacaoDeAjuda.FindAsync(id);
            if (solicitacao == null)
                return NotFound();

            _context.solicitacaoDeAjuda.Remove(solicitacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolicitacaoDeAjudaExists(long id)
        {
            return _context.solicitacaoDeAjuda.Any(e => e.Id == id);
        }
    }
}