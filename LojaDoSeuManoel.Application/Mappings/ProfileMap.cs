using AutoMapper;
using LojaDoSeuManoel.Application.DTOs;
using LojaDoSeuManoel.Domain.Entites;

namespace LojaDoSeuManoel.Application.Mappings
{
    public class ProfileMap : Profile
    {
        public ProfileMap() 
        {
            CreateMap<CaixaRequestDTO, Caixa>();
            CreateMap<Caixa, CaixaResponseDTO>();
            CreateMap<DimensaoRequestDTO, Dimensao>();
            CreateMap<Dimensao, DimensaoResponseDTO>();
            CreateMap<PedidoRequestDTO, Pedido>();
            CreateMap<Pedido, PedidoResponseDTO>();
            CreateMap<ProdutoRequestDTO, Produto>();    
            CreateMap<Produto, ProdutoResponseDTO>();
        }
    }
}
