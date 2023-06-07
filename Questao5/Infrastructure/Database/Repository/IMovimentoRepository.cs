using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.Repository
{
    public interface IMovimentoRepository
    {
        public void InserirMovimentacao(Movimento model);
        public IEnumerable<Movimento> ConsultarTodaMovimentacao(int idContaCorrente);
    }
}
