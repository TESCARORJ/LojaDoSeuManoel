using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Exceptions
{
    public class CaixaNotFoundException : Exception
    {
        public CaixaNotFoundException(int id) : base($"Caixa como ID {id} não localizada") { }
    }
}
