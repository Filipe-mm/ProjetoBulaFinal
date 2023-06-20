namespace ProjetoBulaFinal.Repositorio.Interfaces
{
    public interface IServicoAdm<T> : IServico<T>
    {
        Task<T?> Login(string email, string senha);
    }
}
