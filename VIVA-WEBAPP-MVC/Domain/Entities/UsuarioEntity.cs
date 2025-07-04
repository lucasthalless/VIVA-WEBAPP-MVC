using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOTTHRU.API.Domain.Entities
{
    
    [Table("usuario")]
    public class UsuarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

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
        [StringLength(10, ErrorMessage = "O tipo de usuário deve ter no máximo 10 caracteres.")]
        [DisplayName("Tipo do usuário")]
        public required string TipoUsuario { get; set; }
        
        public virtual ICollection<SolicitacaoDeAjudaEntity>? SolicitacoesDeAjuda { get; set; }
    }
}