using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Entites
{
    public class Produto
    {
        public int Id { get; set; }
        public string? ProdutoId { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; } 
    }
}
