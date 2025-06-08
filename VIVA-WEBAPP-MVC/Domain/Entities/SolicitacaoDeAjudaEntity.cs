using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOTTHRU.API.Domain.Entities
{
    public class SolicitacaoDeAjudaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(10)]
        [DisplayName("Tipo de solicitação")]
        public string TipoSolicitacao { get; set; } = string.Empty;

        public string? Conteudo { get; set; }

        [Required]
        [DisplayName("Data e hora")]
        public DateTime DataHora { get; set; }

        [Required]
        [MaxLength(10)]
        public string Status { get; set; } = string.Empty;

        [Required]
        [MaxLength(5)]
        public string Nivel { get; set; } = string.Empty;

        [Required]
        [DisplayName("Id do usuário")]
        public long IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public UsuarioEntity? Usuario { get; set; }
    }
}
