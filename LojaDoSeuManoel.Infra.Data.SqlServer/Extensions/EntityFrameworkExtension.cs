using FluentValidation;
using LojaDoSeuManoel.Domain.Entites;
using LojaDoSeuManoel.Domain.Interfaces.Repositories;
using LojaDoSeuManoel.Domain.Validations;
using LojaDoSeuManoel.Infra.Data.SqlServer.Contexts;
using LojaDoSeuManoel.Infra.Data.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infra.Data.SqlServer.Extensions
{
    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LojaDoSeuManoel");

            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<ICaixaRepository, CaixaRepository>();
            services.AddTransient<IDimensaoRepository, DimensaoRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            

            return services;
        }
    }
}
