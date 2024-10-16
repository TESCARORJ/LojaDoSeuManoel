using LojaDoSeuManoel.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces
{
    public interface IPedidoService : IDisposable
    {
        Task<PedidoResponseDTO> AddAsync(PedidoRequestDTO request);
        Task<PedidoResponseDTO> UpdateAsync(PedidoRequestDTO request);
        Task<PedidoResponseDTO> DeleteAsync(long id);
        Task<PedidoResponseDTO?> GetByIdAsync(long id);

    }
}
