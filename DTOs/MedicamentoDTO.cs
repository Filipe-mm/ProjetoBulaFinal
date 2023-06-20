namespace ProjetoBulaFinal.DTOs
{
    public record MedicamentoDTO
    {
        public string Marca { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public string Tipo { get; set; } = default!;
        public string RMS { get; set; } = default!;
        public string EAN { get; set; } = default!;
        public string Ativo { get; set; } = default!;
        public string Forma { get; set; } = default!;
        public string Via { get; set; } = default!;
        public string Unidade { get; set; } = default!;
        public string Consumidor { get; set; } = default!;
    }
}
