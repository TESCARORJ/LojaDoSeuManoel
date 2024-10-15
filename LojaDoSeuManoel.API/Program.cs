using LojaDoSeuManoel.API.Extesions;
using LojaDoSeuManoel.Infra.Data.SqlServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerConfig();
builder.Services.AddEntityFramework(builder.Configuration);


var app = builder.Build();

app.UseSwaggerConfig();

app.UseAuthorization();

app.MapControllers();

app.Run();
