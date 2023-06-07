using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Handlers
{
    public interface ICreateMovimentoHandler
    {
        CreateMovimentoResponse Handle(CreateMovimentoRequest command);
    }
}
