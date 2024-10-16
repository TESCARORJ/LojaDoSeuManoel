using AutoMapper;
using LojaDoSeuManoel.Application.Commands;
using LojaDoSeuManoel.Application.DTOs;
using LojaDoSeuManoel.Application.Interfaces;
using LojaDoSeuManoel.Application.Models;
using LojaDoSeuManoel.Domain.Entites;
using LojaDoSeuManoel.Domain.Interfaces.Services;
using MediatR;
using Newtonsoft.Json;
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
        private readonly IMediator _mediator;
        private readonly ICaixaDomainService _caixaDomainService;

        public PedidoService(IPedidoDomainService pedidoDomainService, IMapper mapper, IMediator mediator, ICaixaDomainService caixaDomainService)
        {
            _pedidoDomainService = pedidoDomainService;
            _mapper = mapper;
            _mediator = mediator;
            _caixaDomainService = caixaDomainService;
        }

        public async Task<PedidoResponseDTO> AddAsync(PedidoRequestDTO request)
        {
            var pedido = _mapper.Map<Pedido>(request);
            string observacao = string.Empty;
            Caixa caixa = new Caixa();

            //Verifica as dimenssões do pedido
            foreach (var item in pedido.Produtos)
            {
                var isExisteDimensao = _caixaDomainService.VerificaDimensao(item.Dimensao.Altura, item.Dimensao.Largura, item.Dimensao.Comprimento).Result;
                if (!isExisteDimensao)
                {
                    observacao = "Produto não cabe em nenhuma caixa disponível.";
                }
                else
                {
                    caixa = _caixaDomainService.GetCaixa(item.Dimensao.Altura, item.Dimensao.Largura, item.Dimensao.Comprimento).Result;
                }


            }

            var result = await _pedidoDomainService.AddAsync(pedido);

            #region Executar o COMMAND (CQRS)

            await _mediator.Send(new PedidoCommand
            {
                LogPedido = new LogPedidoModel
                {
                    Id = Guid.NewGuid(),
                    TipoOperacao = TipoOperacao.Add,
                    DataOperacao = DateTime.Now,
                    PedidoId = pedido.PedidoId,
                    DadosPedido = JsonConvert.SerializeObject(pedido)
                }
            });

            #endregion

            // Mapeamento manual de result para PedidoResponseDTO
            var response = new PedidoResponseDTO
            {
                Id = result.PedidoId,
                CaixaId = caixa?.Id.ToString(),
                Produtos = result.Produtos?.Select(x => new ProdutoResponseDTO
                {
                    Id = x.Id,
                    ProdutoId = x.ProdutoId
                }).ToList(),
                Observacao = observacao
            };

            return response;
        }
        public async Task<PedidoResponseDTO> UpdateAsync(PedidoRequestDTO request)
        {
            var pedido = _mapper?.Map<Pedido>(request);

            var result = await _pedidoDomainService.UpdateAsync(pedido);


            #region Executar o COMMAND (CQRS)

            await _mediator.Send(new PedidoCommand
            {
                LogPedido = new LogPedidoModel
                {
                    Id = Guid.NewGuid(),
                    TipoOperacao = TipoOperacao.Update,
                    DataOperacao = DateTime.Now,
                    PedidoId = pedido.PedidoId,
                    DadosPedido = JsonConvert.SerializeObject(result)
                }
            });

            #endregion


            return _mapper.Map<PedidoResponseDTO>(result);
        }

        public async Task<PedidoResponseDTO> DeleteAsync(long id)
        {
            var result = await _pedidoDomainService.DeleteAsync(id);

            #region Executar o COMMAND (CQRS)

            await _mediator.Send(new PedidoCommand
            {
                LogPedido = new LogPedidoModel
                {
                    Id = Guid.NewGuid(),
                    TipoOperacao = TipoOperacao.Delete,
                    DataOperacao = DateTime.Now,
                    PedidoId = result.PedidoId,
                    DadosPedido = JsonConvert.SerializeObject(result)
                }
            });

            #endregion

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
