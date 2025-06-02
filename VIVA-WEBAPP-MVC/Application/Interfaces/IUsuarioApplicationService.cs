using MOTTHRU.API.Application.Dtos;
using MOTTHRU.API.Domain.Entities;

namespace MOTTHRU.API.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        IEnumerable<UsuarioEntity> GetAll();
        UsuarioEntity GetUsuarioById(int id);
        UsuarioEntity CreateUsuario(UsuarioDto entity);
        UsuarioEntity UpdateUsuario(int id, UsuarioDto entity);
        UsuarioEntity DeleteUsuario(int id);
    }
}