using LojaDoSeuManoel.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces
{
    public interface IDimensaoService : IDisposable
    {

        Task<DimensaoResponseDTO> AddAsync(DimensaoRequestDTO request);
        Task<DimensaoResponseDTO> UpdateAsync(DimensaoRequestDTO request);
        Task<DimensaoResponseDTO> DeleteAsync(int id);
        Task<DimensaoResponseDTO?> GetByIdAsync(int id);
       
    }
}
