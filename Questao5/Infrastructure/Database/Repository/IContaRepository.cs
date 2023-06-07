using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.Repository
{
    public interface IContaRepository
    {
        public ContaCorrente ConsultarConta(int numeroContaCorrente);
    }
}
