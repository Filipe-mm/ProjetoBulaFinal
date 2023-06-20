using Microsoft.EntityFrameworkCore;
using ProjetoBulaFinal.Models;

namespace ProjetoBulaFinal.Repositorio.Entity
{
    public class BulaContexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexao = Environment.GetEnvironmentVariable("DATABASE_URL_Projeto_Bula");
            if (conexao is null) conexao = "server=localhost;database=Projeto_Bula;uid=root;pwd=123456";
            optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
        }

        public DbSet<Administrador> Administradores { get; set; } = default!;
        public DbSet<Medicamento> Medicamentos { get; set; } = default!;
    }
}
