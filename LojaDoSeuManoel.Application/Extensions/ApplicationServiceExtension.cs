using LojaDoSeuManoel.Application.Interfaces;
using LojaDoSeuManoel.Application.Mappings;
using LojaDoSeuManoel.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(ProfileMap)); 

            services.AddTransient<ICaixaService, CaixaService>();
            services.AddTransient<IDimensaoService, DimensaoService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IProdutoService, ProdutoService>();

            //injeção de dependência para o MediatR
            services.AddMediatR(m => m.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            return services;
        }
    }
}
