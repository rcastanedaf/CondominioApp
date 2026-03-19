using Condominio.Repositories;
using Condominio.Repositories.Interfaces;
using Condominio.Services;
using Condominio.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITestService, TestService>();

builder.Services.AddScoped<ITestRepository, TestRepository>();

builder.Services.AddScoped<IParentescoService, ParentescoService>();
builder.Services.AddScoped<IParentescoRepository, ParentescoRepository>();

builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();

builder.Services.AddScoped<IBancoService, BancoService>();
builder.Services.AddScoped<IBancoRepository, BancoRepository>();

builder.Services.AddScoped<ITipoMonedaService, TipoMonedaService>();
builder.Services.AddScoped<ITipoMonedaRepository, TipoMonedaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
