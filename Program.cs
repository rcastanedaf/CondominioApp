using Condominio.Repositories;
using Condominio.Repositories.Interfaces;
using Condominio.Services;
using Condominio.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITestService, TestService>();

builder.Services.AddScoped<ITestRepository, TestRepository>();

builder.Services.AddScoped<IMotivoVisitaService, MotivoVisitaService>();
builder.Services.AddScoped<IMotivoVisitaRepository, MotivoVisitaRepository>();

builder.Services.AddScoped<ITipoContratoService, TipoContratoService>();
builder.Services.AddScoped<ITipoContratoRepository, TipoContratoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReact");

app.UseAuthorization();

app.MapControllers();

app.Run();
