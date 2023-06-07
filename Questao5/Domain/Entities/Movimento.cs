using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Questao5.Domain.Entities
{
    public partial class Movimento
    {
        [Column("idmovimento")]
        public Guid Id { get; set; }

        [Column("idcontacorrente")]
        public int ContaCorrenteId { get; set; }

        [Column("datamovimento")]
        public DateTime DataMovimento { get; set; }

        [Column("tipomovimento")]
        public char TipoMovimento { get; set; }

        [Column("valor")]
        public Double Valor { get; set; }


        public Movimento()
        {
            
        }
        public Movimento(int ContaCorrenteId, char TipoMovimento, Double Valor)
        {
            Id = Guid.NewGuid();
            this.ContaCorrenteId = ContaCorrenteId;
            this.TipoMovimento = TipoMovimento;
            this.Valor = Valor;
            this.DataMovimento = DateTime.Now;
        }
    }
}
