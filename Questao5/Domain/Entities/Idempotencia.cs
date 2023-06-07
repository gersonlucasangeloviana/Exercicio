namespace Questao5.Domain.Entities
{
    public class Idempotencia
    {
        public Guid Id { get; set; }
        public string Requisicao { get; set; }
        public string Resultado { get; set; }
    }
}
