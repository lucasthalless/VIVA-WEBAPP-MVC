using MOTTHRU.API.Domain.Entities;

namespace MOTTHRU.API.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioEntity> GetAll();
        UsuarioEntity GetById(int id);
        UsuarioEntity Create(UsuarioEntity item);
        UsuarioEntity Update(UsuarioEntity item);
        UsuarioEntity Delete(int id);
    }
}