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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoDomainService _produtoDomainService;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoDomainService produtoDomainService, IMapper mapper)
        {
            _produtoDomainService = produtoDomainService;
            _mapper = mapper;
        }

        public async Task<ProdutoResponseDTO> AddAsync(ProdutoRequestDTO request)
        {
            var cliente = _mapper.Map<Produto>(request);

            var result = await _produtoDomainService.AddAsync(cliente);
            return _mapper.Map<ProdutoResponseDTO>(result);
        }
        public async Task<ProdutoResponseDTO> UpdateAsync(ProdutoRequestDTO request)
        {
            var cliente = _mapper?.Map<Produto>(request);

            var result = await _produtoDomainService.UpdateAsync(cliente);

            return _mapper.Map<ProdutoResponseDTO>(result);
        }

        public async Task<ProdutoResponseDTO> DeleteAsync(int id)
        {
            var result = await _produtoDomainService.DeleteAsync(id);

            return _mapper.Map<ProdutoResponseDTO>(result);
        }

        public async Task<ProdutoResponseDTO> GetByIdAsync(int id)
        {
            var result = await _produtoDomainService.GetByIdAsync(id);

            return _mapper.Map<ProdutoResponseDTO>(result);
        }
        public void Dispose()
        {
            _produtoDomainService.Dispose();
        }

    }
}
