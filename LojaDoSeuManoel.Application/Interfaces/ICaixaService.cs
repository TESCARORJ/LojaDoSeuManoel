using LojaDoSeuManoel.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces
{
    public interface ICaixaService : IDisposable
    {

        Task<CaixaResponseDTO> AddAsync(CaixaRequestDTO request);
        Task<CaixaResponseDTO> UpdateAsync(CaixaRequestDTO request);
        Task<CaixaResponseDTO> DeleteAsync(int id);
        Task<CaixaResponseDTO?> GetByIdAsync(int id);
        Task<List<CaixaResponseDTO>> GetAllAsync();

    }
}
