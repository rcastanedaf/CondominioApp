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
                .WithOrigins("http://localhost:5173", "https://localhost:5173")
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

builder.Services.AddScoped<IParentescoService, ParentescoService>();
builder.Services.AddScoped<IParentescoRepository, ParentescoRepository>();

builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();

builder.Services.AddScoped<IBancoService, BancoService>();
builder.Services.AddScoped<IBancoRepository, BancoRepository>();

builder.Services.AddScoped<ITipoMonedaService, TipoMonedaService>();
builder.Services.AddScoped<ITipoMonedaRepository, TipoMonedaRepository>();

builder.Services.AddScoped<IMetodoPagoService,  MetodoPagoService>();
builder.Services.AddScoped<IMetodoPagoRepository, MetodoPagoRepository>();

builder.Services.AddScoped<IConceptoDescuentoService, ConceptoDescuentoService>();
builder.Services.AddScoped<IConceptoDescuentoRepository, ConceptoDescuentoRepository>();

builder.Services.AddScoped<ITipoPropiedadService, TipoPropiedadService>();
builder.Services.AddScoped<ITipoPropiedadRepository, TipoPropiedadRepository>();

//builder.Services.AddScoped<IPropiedadService, PropiedadService>();
//builder.Services.AddScoped<IPropiedadRepository, PropiedadRepository>();

builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();

builder.Services.AddScoped<IResidenteService, ResidenteService>();
builder.Services.AddScoped<IResidenteRepository, ResidenteRepository>();

//builder.Services.AddScoped<IContratoService, ContratoService>();
//builder.Services.AddScoped<IContratoRepository, ContratoRepository>();

//builder.Services.AddScoped<IRenovacionContratoService, RenovacionContratoService>();
//builder.Services.AddScoped<IRenovacionContratoRepository, RenovacionContratoRepository>();

//builder.Services.AddScoped<ITipoServicioService, TipoServicioService>();
//builder.Services.AddScoped<ITipoServicioRepository, TipoServicioRepository>();

//builder.Services.AddScoped<ICicloFacturacionService, CicloFacturacionService>();
//builder.Services.AddScoped<ICicloFacturacionRepository, CicloFacturacionRepository>();

//builder.Services.AddScoped<IFacturaService, FacturaService>();
//builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();

//builder.Services.AddScoped<IDetalleFacturaService, DetalleFacturaService>();
//builder.Services.AddScoped<IDetalleFacturaRepository, DetalleFacturaRepository>();

//builder.Services.AddScoped<IPagoService, PagoService>();
//builder.Services.AddScoped<IPagoRepository, PagoRepository>();

//builder.Services.AddScoped<ICuentaCobrarService, CuentaCobrarService>();
//builder.Services.AddScoped<ICuentaCobrarRepository, CuentaCobrarRepository>();

//builder.Services.AddScoped<ICobroMoraService, CobroMoraService>();
//builder.Services.AddScoped<ICobroMoraRepository, CobroMoraRepository>();

builder.Services.AddScoped<IMultaService, MultaService>();
builder.Services.AddScoped<IMultaRepository, MultaRepository>();



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
