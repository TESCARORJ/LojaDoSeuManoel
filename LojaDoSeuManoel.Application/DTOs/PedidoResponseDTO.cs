﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs
{
    public class PedidoResponseDTO
    {
        public long Id { get; set; }
        public string? CaixaId { get; set; }
        public List<ProdutoResponseDTO>? Produtos { get; set; }
        public string? Observacao { get; set; }
    }
}
