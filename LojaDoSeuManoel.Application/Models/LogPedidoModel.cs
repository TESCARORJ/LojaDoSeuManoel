using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Models
{
    /// <summary>
    /// Modelo de dados para gravação dos logs de pedido
    /// </summary>
    public class LogPedidoModel
    {


        public Guid? Id { get; set; }
        public TipoOperacao? TipoOperacao { get; set; }
        public DateTime? DataOperacao { get; set; }
        public long? PedidoId { get; set; }
        public string? DadosPedido { get; set; }

    }


    public enum TipoOperacao
    {
        Add = 1,
        Update = 2,
        Delete = 3
    }
}

