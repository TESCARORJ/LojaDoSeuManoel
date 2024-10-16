using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Entites
{
    public class Pedido
    {
        public long PedidoId { get; set; }
        public List<Produto>? Produtos { get; set; }
    }
}
