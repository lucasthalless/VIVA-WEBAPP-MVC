using System.ComponentModel.DataAnnotations;

public enum TipoUsuarioEnum
{
    usuario,
    adm
}

namespace MOTTHRU.API.Application.Dtos
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public required string Nome { get; set; }

        [StringLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres.")]
        public string? Cpf { get; set; }

        [StringLength(11, ErrorMessage = "O telefone deve ter no máximo 11 caracteres.")]
        public string? Telefone { get; set; }

        [StringLength(30, ErrorMessage = "O email deve ter no máximo 30 caracteres.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        public required TipoUsuarioEnum TipoUsuario { get; set; }
    }
}