using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Exceptions
{
    public class ProdutoNotFoundException : Exception
    {
        public ProdutoNotFoundException(int id) : base($"Produto como ID {id} não localizado") { }
    }
}
