using MOTTHRU.API.Application.Dtos;
using MOTTHRU.API.Application.Interfaces;
using MOTTHRU.API.Domain.Entities;
using MOTTHRU.API.Domain.Interfaces;

namespace MOTTHRU.API.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApplicationService(IUsuarioRepository repository)
        {
            _usuarioRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<UsuarioEntity> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public UsuarioEntity GetUsuarioById(int id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario is null)
                throw new InvalidOperationException($"Usuário com ID {id} não encontrado.");

            return usuario;
        }

        public UsuarioEntity CreateUsuario(UsuarioDto usuario)
        {
            if (usuario is null)
                throw new ArgumentNullException(nameof(usuario));

            var newUsuario = new UsuarioEntity
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                TipoUsuario = usuario.TipoUsuario,
                Cpf = usuario.Cpf,
            };

            return _usuarioRepository.Create(newUsuario);
        }

        public UsuarioEntity UpdateUsuario(int id, UsuarioDto usuario)
        {
            if (usuario is null)
                throw new ArgumentNullException(nameof(usuario));

            var usuarioUpdated = new UsuarioEntity
            {
                Id = id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                TipoUsuario = usuario.TipoUsuario,
                Cpf = usuario.Cpf,
            };

            return _usuarioRepository.Update(usuarioUpdated);
        }

        public UsuarioEntity DeleteUsuario(int id)
        {
            return _usuarioRepository.Delete(id);
        }
    }
}