using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBulaFinal.Models
{
    public class Administrador
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Column("Nome")]
        public string Nome { get; set; } = default!;

        [Column("Email")]
        public string Email { get; set; } = default!;

        [Column("Senha")]
        public string Senha { get; set; } = default!;

        [Column("Permissao")]
        public string Permissao { get; set; } = default!;

        [Column("CPF")]
        public string CPF { get; set; } = default!;

        [Column("CRF")]
        public string CRF { get; set; } = default!;

        [Column("CNAE")]
        public string CNAE { get; set; } = default!;

        [Column("VISA")]
        public string VISA { get; set; } = default!;
    }
}
