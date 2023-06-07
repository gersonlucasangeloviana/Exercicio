namespace Questao5.Application.Commands.Requests
{
    public class GetSaldoRequest
    {
        public Guid IdRequisicao { get; set; }
        public int ContaCorrenteId { get; set; }
    }
}
