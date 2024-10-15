using FluentValidation;
using LojaDoSeuManoel.Domain.Entites;
using LojaDoSeuManoel.Domain.Interfaces.Services;
using LojaDoSeuManoel.Domain.Services;
using LojaDoSeuManoel.Domain.Validations;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IDimensaoDomainService, DimensaoDomainService>();
            services.AddTransient<IValidator<Dimensao>, DimensaoValidator>();
            
            services.AddTransient<IProdutoDomainService, ProdutoDomainService>();
            services.AddTransient<IValidator<Produto>, ProdutoValidator>();
            
            services.AddTransient<IPedidoDomainService, PedidoDomainService>();
            services.AddTransient<IValidator<Pedido>, PedidoValidator>();

            return services;
        }
    }
}
