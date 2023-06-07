using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public ContaRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

 
        public ContaCorrente ConsultarConta(int numeroContaCorrente)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var resultado = connection.QueryFirstOrDefault<ContaCorrente>($"SELECT * from contacorrente where numero = {numeroContaCorrente}");

            return resultado;

        }
    }
}
