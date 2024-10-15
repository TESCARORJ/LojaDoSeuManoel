using LojaDoSeuManoel.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces
{
    public interface IProdutoService : IDisposable
    {

        Task<ProdutoResponseDTO> AddAsync(ProdutoRequestDTO request);
        Task<ProdutoResponseDTO> UpdateAsync(Guid id, ProdutoRequestDTO request);
        Task<ProdutoResponseDTO> DeleteAsync(Guid id);
        Task<ProdutoResponseDTO?> GetByIdAsync(Guid id);

    }
}
