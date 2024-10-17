using LojaDoSeuManoel.Domain.Entites;
using LojaDoSeuManoel.Domain.Interfaces.Services;

namespace LojaDoSeuManoel.API.Extensions
{
    public static class DataBaseExtension
    {
        public static void AddRegistros(this IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var caixaContext = scope.ServiceProvider.GetRequiredService<ICaixaDomainService>();
            
            var isExiste = caixaContext.GetAllAsync().Result.Any();

            if (!isExiste)
            {
                List<Dimensao> dimensaoList = new List<Dimensao> 
                {
                    new Dimensao { Altura = 30, Largura = 40, Comprimento = 80},
                    new Dimensao { Altura = 80, Largura = 50, Comprimento = 40},
                    new Dimensao { Altura = 50, Largura = 80, Comprimento = 60},
                };

                var dimensaoContext= scope.ServiceProvider.GetRequiredService<IDimensaoDomainService>();
                dimensaoContext.AddAsync(dimensaoList[0]).Wait();
                dimensaoContext.AddAsync(dimensaoList[1]).Wait();
                dimensaoContext.AddAsync(dimensaoList[2]).Wait();                  
            }

            List<Caixa> caixas = new List<Caixa>();

            for (int i = 1; i < 3; i++)
            {
                caixas.Add(new Caixa 
                { 
                    CaixaId = $"Caixa {i}", 
                    DimensaoId = i, 
                    Produtos = null,
                    Observacao = "" });
            }

            foreach (var item in caixas)
            {
                caixaContext.AddAsync(item).Wait();
            }


        }
    }
}
