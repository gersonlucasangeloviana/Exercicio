using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database.Repository;
using System.Text.Json;

namespace Questao5.Application.Handlers
{
    public class CreateMovimentoHandler : ICreateMovimentoHandler
    {
        IContaRepository _repository;
        IMovimentoRepository _movimentoRepository;
        IIdempotenciaRepository _indempontencia;

        public CreateMovimentoHandler(IContaRepository repository, IMovimentoRepository movimentoRepository, IIdempotenciaRepository indempontencia)
        {
            _repository = repository;
            _movimentoRepository = movimentoRepository;
            _indempontencia = indempontencia;
        }

        public CreateMovimentoResponse Handle(CreateMovimentoRequest command)
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
            if (command.Valor < 0)
            {
                throw new Exception("INVALID_VALUE");
            }
            if (!command.TipoMovimento.ToString().Contains("D") && !command.TipoMovimento.ToString().Contains("C"))
            {
                throw new Exception("INVALID_TYPE");
            }

            var movimento = new Movimento(command.ContaCorrenteId, command.TipoMovimento, command.Valor);

            _movimentoRepository.InserirMovimentacao(movimento);

            var respose = new CreateMovimentoResponse
            {
                Id = movimento.Id,
                ContaCorrenteId = movimento.ContaCorrenteId,
                Valor = movimento.Valor,
                TipoMovimento = movimento.TipoMovimento,
                Date = movimento.DataMovimento
            };

            Idempotencia idempotencia = new Idempotencia()
            {
                Id = command.IdRequisicao,
                Requisicao = JsonSerializer.Serialize(command),
                Resultado = JsonSerializer.Serialize(respose)
            };

            _indempontencia.Inserir(idempotencia);

            return respose;



        }
    }
}
