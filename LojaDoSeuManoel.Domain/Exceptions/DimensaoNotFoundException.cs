using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Exceptions
{
    public class DimensaoNotFoundException : Exception
    {
        public DimensaoNotFoundException(int id) : base($"Dimensão como ID {id} não localizada") { }
    }
}
