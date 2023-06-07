namespace Questao5.Application.Commands.Responses
{
    public class CreateMovimentoResponse
    {
        public Guid Id { get; set; }
        public int ContaCorrenteId { get; set; }
        public Double Valor { get; set; }
        public char TipoMovimento { get; set; }
        public DateTime Date { get; set; }
    }
}
