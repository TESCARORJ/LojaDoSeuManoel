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
    public class CaixaService : ICaixaService
    {
        private readonly ICaixaDomainService _caixaDomainService;
        private readonly IMapper _mapper;

        public CaixaService(ICaixaDomainService caixaDomainService, IMapper mapper)
        {
            _caixaDomainService = caixaDomainService;
            _mapper = mapper;
        }

        public async Task<CaixaResponseDTO> AddAsync(CaixaRequestDTO request)
        {
            var cliente = _mapper.Map<Caixa>(request);

            var result = await _caixaDomainService.AddAsync(cliente);
            return _mapper.Map<CaixaResponseDTO>(result);
        }
        public async Task<CaixaResponseDTO> UpdateAsync(CaixaRequestDTO request)
        {
            var cliente = _mapper?.Map<Caixa>(request);

            var result = await _caixaDomainService.UpdateAsync(cliente);

            return _mapper.Map<CaixaResponseDTO>(result);
        }

        public async Task<CaixaResponseDTO> DeleteAsync(int id)
        {
            var result = await _caixaDomainService.DeleteAsync(id);

            return _mapper.Map<CaixaResponseDTO>(result);
        }

        public async Task<CaixaResponseDTO> GetByIdAsync(int id)
        {
            var result = await _caixaDomainService.GetByIdAsync(id);

            return _mapper.Map<CaixaResponseDTO>(result);
        }

        public async Task<List<CaixaResponseDTO>> GetAllAsync()
        {
            var result = await _caixaDomainService.GetAllAsync();
            var mapResult = _mapper.Map<List<CaixaResponseDTO>>(result);
            return mapResult;
        }

        public void Dispose()
        {
            _caixaDomainService.Dispose();
        }

    }
}
