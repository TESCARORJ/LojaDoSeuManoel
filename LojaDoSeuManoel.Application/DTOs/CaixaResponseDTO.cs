using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs
{
    public class CaixaResponseDTO
    {
        public string Caixa { get; set; }
        public List<string> Produto { get; set; }

    }
}
