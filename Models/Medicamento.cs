using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoBulaFinal.Models
{
    public class Medicamento
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = default!;

        [Column("Marca")]
        public string Marca { get; set; } = default!;

        [Column("Nome")]
        public string Nome { get; set; } = default!;

        [Column("Tipo")]
        public string Tipo { get; set; } = default!;

        [Column("RMS")]
        public string RMS { get; set; } = default!;

        [Column("EAN")]
        public string EAN { get; set; } = default!;

        [Column("Ativo")]
        public string Ativo { get; set; } = default!;

        [Column("Forma")]
        public string Forma { get; set; } = default!;

        [Column("Via")]
        public string Via { get; set; } = default!;

        [Column("Unidade")]
        public string Unidade { get; set; } = default!;

        [Column("Consumidor")]
        public string Consumidor { get; set; } = default!;
    }
}
