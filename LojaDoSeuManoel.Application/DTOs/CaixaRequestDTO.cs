using LojaDoSeuManoel.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.DTOs
{
    public class CaixaRequestDTO
    {
        public string? CaixaId { get; set; }
        public Dimensao? Dimensao { get; set; }

    }
}
