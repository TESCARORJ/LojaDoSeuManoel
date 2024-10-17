using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs
{
    public class PedidoResponseDTO
    {
        public long Pedido_Id { get; set; }
        public List<CaixaResponseDTO> Caixas { get; set; }
        public string? Observacao { get; set; }
    }
}
