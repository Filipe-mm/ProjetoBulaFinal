using Microsoft.EntityFrameworkCore;
using ProjetoBulaFinal.Models;
using ProjetoBulaFinal.Repositorio.Interfaces;

namespace ProjetoBulaFinal.Repositorio.Entity
{
    public class MedicamentoRepositorio : IServico<Medicamento>
    {
        private BulaContexto contexto;
        public MedicamentoRepositorio()
        {
            contexto = new BulaContexto();
        }

        public async Task<List<Medicamento>> TodosAsync()
        {
            return await contexto.Medicamentos.ToListAsync();
        }

        public async Task IncluirAsync(Medicamento medicamento)
        {
            contexto.Medicamentos.Add(medicamento);
            await contexto.SaveChangesAsync();
        }

        public async Task<Medicamento> AtualizarAsync(Medicamento medicamento)
        {
            contexto.Entry(medicamento).State = EntityState.Modified;
            await contexto.SaveChangesAsync();

            return medicamento;
        }

        public async Task ApagarAsync(Medicamento medicamento)
        {
            var obj = await contexto.Medicamentos.FindAsync(medicamento.Id);
            if (obj is null) throw new Exception("Medicamento não encontrado");
            contexto.Medicamentos.Remove(obj);
            await contexto.SaveChangesAsync();
        }
    }
}
