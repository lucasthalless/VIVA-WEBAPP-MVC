using MOTTHRU.API.Domain.Entities;
using MOTTHRU.API.Domain.Interfaces;
using MOTTHRU.API.Infrastructure.Data.AppData;

namespace MOTTHRU.API.Infrastructure.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioEntity> GetAll()
        {
            var motos = _context.usuario.ToList();
            return motos;
        }

        public UsuarioEntity GetById(int id)
        {
            return _context.usuario.Find(id);
        }

        public UsuarioEntity Create(UsuarioEntity usuario)
        {
            if (usuario is null)
                throw new ArgumentNullException(nameof(usuario));

            _context.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public UsuarioEntity Update(UsuarioEntity item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            var usuario = _context.usuario.Find(item.Id);

            if (usuario is null)
                throw new InvalidOperationException("Usuario não encontrado para atualização.");

            usuario.Nome = item.Nome;
            usuario.Email = item.Email;
            usuario.Cpf = item.Cpf;
            usuario.Telefone = item.Telefone;
            usuario.TipoUsuario = item.TipoUsuario;

            _context.Update(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public UsuarioEntity Delete(int id)
        {
            var usuario = _context.usuario.Find(id);

            if (usuario is null)
                throw new InvalidOperationException("Usuario não encontrado para exclusão.");

            _context.Remove(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}