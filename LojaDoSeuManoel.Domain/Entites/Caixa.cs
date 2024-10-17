using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Entites
{
    public class Caixa
    {
        public int Id { get; set; }
        public string? CaixaId { get; set; }
        public int DimensaoId { get; set; }
        public Dimensao? Dimensao { get; set; }
        public List<Produto>? Produtos { get; set; }
        public string? Observacao { get; set; }

    }
}
