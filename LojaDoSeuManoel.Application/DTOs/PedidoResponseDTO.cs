using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs
{
    public class PedidoResponseDTO
    {
        public long PedidoId { get; set; }
        public ICollection<ProdutoResponseDTO>? Produtos { get; set; }
    }
}
