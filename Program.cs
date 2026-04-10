using Condominio.Repositories;
using Condominio.Repositories.Interfaces;
using Condominio.Services;
using Condominio.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 🔹 CORS (AGREGAR ESTO)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


// Services
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<ITestRepository, TestRepository>();

builder.Services.AddScoped<IMotivoVisitaService, MotivoVisitaService>();
builder.Services.AddScoped<IMotivoVisitaRepository, MotivoVisitaRepository>();

builder.Services.AddScoped<ITipoContratoService, TipoContratoService>();
builder.Services.AddScoped<ITipoContratoRepository, TipoContratoRepository>();

builder.Services.AddScoped<IIncidenciaService, IncidenciaService>();
builder.Services.AddScoped<IIncidenciaRepository, IncidenciaRepository>();

builder.Services.AddScoped<ICategoriaIncidenciaService, CategoriaIncidenciaService>();
builder.Services.AddScoped<ICategoriaIncidenciaRepository, CategoriaIncidenciaRepository>();

builder.Services.AddScoped<ISeguimientoIncidenciaService, SeguimientoIncidenciaService>();
builder.Services.AddScoped<ISeguimientoIncidenciaRepository, SeguimientoIncidenciaRepository>();

builder.Services.AddScoped<ITipoServicioService, TipoServicioService>();
builder.Services.AddScoped<ITipoServicioRepository, TipoServicioRepository>();

builder.Services.AddScoped<ICobroMoraService, CobroMoraService>();
builder.Services.AddScoped<ICobroMoraRepository, CobroMoraRepository>();

builder.Services.AddScoped<IParentescoService, ParentescoService>();
builder.Services.AddScoped<IParentescoRepository, ParentescoRepository>();

builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();

builder.Services.AddScoped<IBancoService, BancoService>();
builder.Services.AddScoped<IBancoRepository, BancoRepository>();

builder.Services.AddScoped<ITipoMonedaService, TipoMonedaService>();
builder.Services.AddScoped<ITipoMonedaRepository, TipoMonedaRepository>();


var app = builder.Build();


// 🔹 ACTIVAR CORS (AGREGAR ESTO)
app.UseCors("AllowFrontend");


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
