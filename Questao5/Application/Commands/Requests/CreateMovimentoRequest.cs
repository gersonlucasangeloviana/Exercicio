namespace Questao5.Application.Commands.Requests
{
    public class CreateMovimentoRequest
    {
        public Guid IdRequisicao { get; set; }
        public int ContaCorrenteId { get; set; }
        public Double Valor { get; set; }
        public char TipoMovimento { get; set; }
    }
}
