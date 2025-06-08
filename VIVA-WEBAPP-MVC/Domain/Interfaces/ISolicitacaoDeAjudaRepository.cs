using MOTTHRU.API.Domain.Entities;

namespace MOTTHRU.API.Domain.Interfaces
{
    public interface ISolicitacaoDeAjudaRepository
    {
        IEnumerable<SolicitacaoDeAjudaEntity> GetAll();
        SolicitacaoDeAjudaEntity GetById(int id);
        SolicitacaoDeAjudaEntity Create(SolicitacaoDeAjudaEntity item);
        SolicitacaoDeAjudaEntity Update(SolicitacaoDeAjudaEntity item);
        SolicitacaoDeAjudaEntity Delete(int id);
    }
}

