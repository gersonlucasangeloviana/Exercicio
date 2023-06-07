using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    public interface IIdempotenciaRepository
    {
        public string Consultar(Guid Id);

        public void Inserir(Idempotencia model); 
    }
}
