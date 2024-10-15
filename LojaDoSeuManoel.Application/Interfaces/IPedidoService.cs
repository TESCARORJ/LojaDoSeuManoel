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
        Task<PedidoResponseDTO> UpdateAsync(Guid id, PedidoRequestDTO request);
        Task<PedidoResponseDTO> DeleteAsync(Guid id);
        Task<PedidoResponseDTO?> GetByIdAsync(Guid id);

    }
}
