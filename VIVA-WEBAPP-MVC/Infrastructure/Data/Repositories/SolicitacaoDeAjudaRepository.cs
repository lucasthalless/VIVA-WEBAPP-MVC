using Microsoft.EntityFrameworkCore;
using MOTTHRU.API.Domain.Entities;
using MOTTHRU.API.Domain.Interfaces;
using MOTTHRU.API.Infrastructure.Data.AppData;

namespace VIVA_WEBAPP_MVC.Infrastructure.Data.Repositories
{
    public class SolicitacaoDeAjudaRepository : ISolicitacaoDeAjudaRepository
    {
        private readonly ApplicationContext _context;

        public SolicitacaoDeAjudaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<SolicitacaoDeAjudaEntity> GetAll()
        {
            var solicitacoesDeAjuda = _context.solicitacaoDeAjuda.ToList();
            return solicitacoesDeAjuda;
        }

        public SolicitacaoDeAjudaEntity GetById(int id)
        {
            return _context.solicitacaoDeAjuda
                .Include(x => x.Usuario)
                .FirstOrDefault(x => x.Id == id);
        }

        public SolicitacaoDeAjudaEntity Create(SolicitacaoDeAjudaEntity solicitacaoDeAjudaEntity)
        {
            if (solicitacaoDeAjudaEntity is null)
                throw new ArgumentNullException(nameof(solicitacaoDeAjudaEntity));
            
            _context.Add(solicitacaoDeAjudaEntity);
            _context.SaveChanges();

            return solicitacaoDeAjudaEntity;
        }

        public SolicitacaoDeAjudaEntity Update(SolicitacaoDeAjudaEntity item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            var solicitacaoDeAjuda = _context.solicitacaoDeAjuda.Find(item.Id);

            if (solicitacaoDeAjuda is null)
                throw new InvalidOperationException("Solicitação de ajuda não encontrada para atualização.");

            solicitacaoDeAjuda.Conteudo = item.Conteudo;
            solicitacaoDeAjuda.TipoSolicitacao = item.TipoSolicitacao;
            solicitacaoDeAjuda.DataHora = item.DataHora;
            solicitacaoDeAjuda.Nivel = item.Nivel;
            solicitacaoDeAjuda.Status = item.Status;
            solicitacaoDeAjuda.IdUsuario = item.IdUsuario;

            _context.Update(solicitacaoDeAjuda);
            _context.SaveChanges();

            return solicitacaoDeAjuda;
        }

        public SolicitacaoDeAjudaEntity Delete(int id)
        {
            var solicitacaoDeAjuda = _context.solicitacaoDeAjuda.Find(id);

            if (solicitacaoDeAjuda is null)
                throw new InvalidOperationException("Solicitação de ajuda não encontrada para exclusão.");

            _context.Remove(solicitacaoDeAjuda);
            _context.SaveChanges();

            return solicitacaoDeAjuda;
        }
    }
}