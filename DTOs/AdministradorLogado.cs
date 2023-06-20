namespace ProjetoBulaFinal.DTOs
{
    public class AdministradorLogado
    {
        public int Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Permissao { get; set; } = default!;
        public string CPF { get; set; } = default!;
        public string CRF { get; set; } = default!;
        public string CNAE { get; set; } = default!;
        public string VISA { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
