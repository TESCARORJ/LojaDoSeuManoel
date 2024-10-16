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
        Task<ProdutoResponseDTO> UpdateAsync(ProdutoRequestDTO request);
        Task<ProdutoResponseDTO> DeleteAsync(int id);
        Task<ProdutoResponseDTO?> GetByIdAsync(int id);

    }
}
