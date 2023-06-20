namespace ProjetoBulaFinal.Repositorio.Interfaces
{
    public interface IServico<T>
    {
        Task<List<T>> TodosAsync();
        Task IncluirAsync(T obj);
        Task<T> AtualizarAsync(T obj);
        Task ApagarAsync(T obj);
    }
}
