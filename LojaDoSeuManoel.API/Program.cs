//using LojaDoSeuManoel.API.Extesions;
using LojaDoSeuManoel.Infra.Data.SqlServer.Extensions;
using LojaDoSeuManoel.Domain.Extensions;
using LojaDoSeuManoel.Application.Extensions;
using LojaDoSeuManoel.API.Middlewares;
using LojaDoSeuManoel.Infra.Data.MongoDB.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddSwaggerConfig();
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddMongoDB(builder.Configuration);

builder.Services.AddSwaggerGen(options =>
{
    // Configurar o Swagger para autenticação básica
    options.AddSecurityDefinition("basic", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Entre com o nome de usuário e senha na seguinte estrutura: `username:password`."
    });

    // Configurar os requisitos de segurança globais para o Swagger
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "basic"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("FullCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()    // Permitir qualquer origem
              .AllowAnyMethod()    // Permitir qualquer método (GET, POST, PUT, etc.)
              .AllowAnyHeader();   // Permitir qualquer cabeçalho
    });
});

var app = builder.Build();

//Middleware para tratar exceções de validação.
app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Loja Do Seu Manoel API v1");
    options.DocumentTitle = "Loja Do Seu Manoel - Documentação com Autenticação Básica";
});

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
