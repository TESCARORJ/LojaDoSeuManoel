﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs
{
    public class PedidoRequestDTO
    {
        public ICollection<ProdutoRequestDTO>? Produtos { get; set; }
    }
}
