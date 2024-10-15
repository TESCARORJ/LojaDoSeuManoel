using Microsoft.OpenApi.Models;

namespace LojaDoSeuManoel.API.Extesions
{
    /// <summary>
    /// Classe de extensão para o Swagger
    /// </summary>
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                             new OpenApiInfo
                             {
                                 Title = "Loja do Seu Manoel API",
                                 Version = "v1",
                                 Description = "API para automatizar o processo de embalagem dos pedidos da loja do Seu Manoel",
                             });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loja do Seu Manoel API");
            });

            return app;
        }
    }
}
