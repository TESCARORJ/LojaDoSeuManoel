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
        private readonly IDimensaoDomainService _dimensaoDomainService;

        public PedidoService(IPedidoDomainService pedidoDomainService, IMapper mapper, IMediator mediator, ICaixaDomainService caixaDomainService, IDimensaoDomainService dimensaoDomainService)
        {
            _pedidoDomainService = pedidoDomainService;
            _mapper = mapper;
            _mediator = mediator;
            _caixaDomainService = caixaDomainService;
            _dimensaoDomainService = dimensaoDomainService;
        }


        public async Task<Pedido> Empacotar(Pedido pedido)
        {
            // Verifica se a lista de caixas do pedido está inicializada. Se não, inicializa.
            if (pedido.Caixas == null)
            {
                pedido.Caixas = new List<Caixa>();
            }

            var caixas = _caixaDomainService.GetAllAsync().Result;
            var caixasUsadas = new List<Caixa>();
            

            foreach (var produto in pedido.Produtos)
            {
                bool alocado = false;

                foreach (var caixa in caixas)
                {
                    if (ProdutoCabeNaCaixa(produto, caixa))
                    {
                        if (caixa.Produtos == null)
                        {
                            caixa.Produtos = new List<Produto>();
                        }
                        caixa.Produtos.Add(produto);
                        caixasUsadas.Add(caixa);
                        alocado = true;
                        break;
                    }
                }

                if (!alocado)                    
                {
                    var caixaDisponivel = SelecionarCaixaDisponivel(produto);
                    if (caixaDisponivel != null)
                    {
                        if (caixaDisponivel.Produtos == null)
                        {
                            caixaDisponivel.Produtos = new List<Produto>();
                        }
                        caixaDisponivel.Produtos.Add(produto);
                        caixasUsadas.Add(caixaDisponivel);
                    }
                    else
                    {
                       pedido.Observacao = $"Produto {produto.ProdutoId} não cabe em nenhuma caixa disponível.";

                    }
                }
                else
                {
                    pedido.Observacao = $"Produto {produto.ProdutoId} embalado com sucesso.";

                }
            }

            pedido.Caixas.AddRange(caixasUsadas);

            return pedido;
        }

        private bool ProdutoCabeNaCaixa(Produto produto, Caixa caixa)
        {
            var dimensao = _dimensaoDomainService.GetByIdAsync(caixa.DimensaoId).Result;

            return produto.Dimensao?.Altura <= dimensao.Altura &&
                   produto.Dimensao.Largura <= dimensao.Largura &&
                   produto.Dimensao.Comprimento <= dimensao.Comprimento;
        }

        private Caixa SelecionarCaixaDisponivel(Produto produto)
        {
            List<Caixa> caixasDisponiveis = _caixaDomainService.GetAllAsync().Result;

            foreach (var caixa in caixasDisponiveis)
            {
                if (ProdutoCabeNaCaixa(produto, caixa))
                {
                    return new Caixa
                    {
                        CaixaId = caixa.CaixaId,
                        Dimensao = caixa.Dimensao
                        
                    };
                }
            }
            return null;
        }

        public async Task<PedidoResponseDTO> AddAsync(PedidoRequestDTO request)
        {
            var pedido = _mapper.Map<Pedido>(request);
            string observacao = string.Empty;
            List<Caixa?> caixas = new List<Caixa?>();

          

            pedido = await Empacotar(pedido);

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
                Pedido_Id = result.PedidoId,
                Caixas = result.Caixas
                .GroupBy(caixa => caixa.CaixaId) 
                .Select(grupoCaixa => new CaixaResponseDTO
                {
                    Caixa = grupoCaixa.Key, 
                    Produto = grupoCaixa.SelectMany(c => c.Produtos.Select(p => p.ProdutoId.ToString())).ToList() // Agrupa os produtos da mesma caixa
                }).ToList(),
                Observacao = result.Observacao
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
