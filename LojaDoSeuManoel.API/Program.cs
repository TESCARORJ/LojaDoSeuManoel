using LojaDoSeuManoel.API.Extesions;
using LojaDoSeuManoel.Infra.Data.SqlServer.Extensions;
using LojaDoSeuManoel.Domain.Extensions;
using LojaDoSeuManoel.Application.Extensions;
using LojaDoSeuManoel.API.Middlewares;
using LojaDoSeuManoel.Infra.Data.MongoDB.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerConfig();
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddMongoDB(builder.Configuration);



var app = builder.Build();

//Middleware para tratar exceções de validação.
app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseSwaggerConfig();

app.UseAuthorization();

app.MapControllers();

app.Run();
