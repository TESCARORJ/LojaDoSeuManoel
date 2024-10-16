using AutoMapper;
using LojaDoSeuManoel.Application.DTOs;
using LojaDoSeuManoel.Application.Interfaces;
using LojaDoSeuManoel.Domain.Entites;
using LojaDoSeuManoel.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Services
{
    public class DimensaoService : IDimensaoService
    {
        private readonly IDimensaoDomainService _dimensaoDomainService;
        private readonly IMapper _mapper;

        public DimensaoService(IDimensaoDomainService dimensaoDomainService, IMapper mapper)
        {
            _dimensaoDomainService = dimensaoDomainService;
            _mapper = mapper;
        }

        public async Task<DimensaoResponseDTO> AddAsync(DimensaoRequestDTO request)
        {
            var cliente = _mapper.Map<Dimensao>(request);
            
            var result = await _dimensaoDomainService.AddAsync(cliente);
            return _mapper.Map<DimensaoResponseDTO>(result);
        }
        public async Task<DimensaoResponseDTO> UpdateAsync(DimensaoRequestDTO request)
        {
            var cliente = _mapper?.Map<Dimensao>(request);

            var result = await _dimensaoDomainService.UpdateAsync(cliente);

            return _mapper.Map<DimensaoResponseDTO>(result);
        }

        public async Task<DimensaoResponseDTO> DeleteAsync(int id)
        {
            var result = await _dimensaoDomainService.DeleteAsync(id);

            return _mapper.Map<DimensaoResponseDTO>(result);
        }

        public async Task<DimensaoResponseDTO> GetByIdAsync(int id)
        {
            var result = await _dimensaoDomainService.GetByIdAsync(id);

            return _mapper.Map<DimensaoResponseDTO>(result);
        }
        public void Dispose()
        {
            _dimensaoDomainService.Dispose();
        }

    }
}
