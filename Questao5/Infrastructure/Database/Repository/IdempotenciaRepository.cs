using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    public class IdempotenciaRepository : IIdempotenciaRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public IdempotenciaRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public string Consultar(Guid Id)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var resultado = connection.QueryFirstOrDefault<string>($"SELECT resultado from idempotencia where chave_idempotencia = '{Id}'");

            return resultado;
        }

        public void Inserir(Idempotencia model)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            string query = string.Concat("INSERT INTO idempotencia(chave_idempotencia, requisicao, resultado) "
                , " VALUES ('", model.Id, "', '", model.Requisicao, "', '", model.Resultado, "') ");

            connection.Execute(query);
        }
    }
}
