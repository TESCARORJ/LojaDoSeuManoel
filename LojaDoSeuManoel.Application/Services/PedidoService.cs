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
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoDomainService _pedidoDomainService;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoDomainService pedidoDomainService, IMapper mapper)
        {
            _pedidoDomainService = pedidoDomainService;
            _mapper = mapper;
        }

        public async Task<PedidoResponseDTO> AddAsync(PedidoRequestDTO request)
        {
            var cliente = _mapper.Map<Pedido>(request);

            var result = await _pedidoDomainService.AddAsync(cliente);
            return _mapper.Map<PedidoResponseDTO>(result);
        }
        public async Task<PedidoResponseDTO> UpdateAsync(PedidoRequestDTO request)
        {
            var cliente = _mapper?.Map<Pedido>(request);

            var result = await _pedidoDomainService.UpdateAsync(cliente);

            return _mapper.Map<PedidoResponseDTO>(result);
        }

        public async Task<PedidoResponseDTO> DeleteAsync(long id)
        {
            var result = await _pedidoDomainService.DeleteAsync(id);

            return _mapper.Map<PedidoResponseDTO>(result);
        }

        public async Task<PedidoResponseDTO> GetByIdAsync(long id)
        {
            var result = await _pedidoDomainService.GetByIdAsync(id);

            return _mapper.Map<PedidoResponseDTO>(result);
        }
        public void Dispose()
        {
            _pedidoDomainService.Dispose();
        }

    }
}
