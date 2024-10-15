using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Exceptions
{
    public class PedidoNotFoundException : Exception
    {
        public PedidoNotFoundException(long id) : base($"Pedido como ID {id} não localizado") { }
    }
}
