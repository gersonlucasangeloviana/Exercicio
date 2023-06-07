using Castle.Core.Resource;
using Moq;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.Repository;

namespace Questao5.Application.Handlers
{
    public class GetContaCorrenteHandler : IGetContaCorrenteHandler
    {
        IContaRepository _repository;
        IMovimentoRepository _movimentoRepository;

        public GetContaCorrenteHandler(IContaRepository repository, IMovimentoRepository movimentoRepository)
        {
            _repository = repository;
            _movimentoRepository = movimentoRepository;
        }

        public GetSaldoResponse Handle(GetSaldoRequest command)
        {
            var contaCorrente = _repository.ConsultarConta(command.ContaCorrenteId);
            if (contaCorrente == null)
            {
                throw new Exception("INVALID_ACCOUNT");
            }
            if (contaCorrente.Ativo.Equals(false))
            {
                throw new Exception("INACTIVE_ACCOUNT");
            }

            
            var movimentacoes = _movimentoRepository.ConsultarTodaMovimentacao(command.ContaCorrenteId);
            var valorSaldo = 0.0;

            foreach (var item in movimentacoes)
            {
                if(item.TipoMovimento.Equals('C'))
                {
                    valorSaldo += item.Valor;
                } else if (item.TipoMovimento.Equals('D'))
                {
                    valorSaldo -= item.Valor;
                }
            }

            return new GetSaldoResponse
            {
                Numero = command.ContaCorrenteId,
                Nome = contaCorrente.Nome,
                Valor = valorSaldo,
                Date = DateTime.Now
            };
        }
    }
}
