using Dapper;
using Microsoft.Data.Sqlite;
using Moq;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public MovimentoRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void InserirMovimentacao(Movimento model)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            string query = string.Concat("INSERT INTO movimento(idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) "
                , " VALUES ('", model.Id , "', ", model.ContaCorrenteId, ", '", model.DataMovimento, "', '", model.TipoMovimento, "', ", model.Valor, ") ");
            
                connection.Execute(query);
        }
        public IEnumerable<Movimento> ConsultarTodaMovimentacao(int idContaCorrente)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var movimentos = connection.Query<Movimento>($"SELECT * FROM movimento WHERE idcontacorrente = {idContaCorrente};");

            return movimentos;
        }

    }
}
