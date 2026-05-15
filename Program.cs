using Condominio.Repositories;
using Condominio.Repositories.Interfaces;
using Condominio.Services;
using Condominio.Services.Interfaces;
using Condominio.Middleware;
using Oracle.ManagedDataAccess.Client;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 CONEXIÓN A ORACLE
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new OracleConnection(connectionString);
});

// 🔹 CORS
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

// 🔹 SERVICES & REPOSITORIES
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

builder.Services.AddScoped<IMetodoPagoService, MetodoPagoService>();
builder.Services.AddScoped<IMetodoPagoRepository, MetodoPagoRepository>();

builder.Services.AddScoped<IConceptoDescuentoService, ConceptoDescuentoService>();
builder.Services.AddScoped<IConceptoDescuentoRepository, ConceptoDescuentoRepository>();

builder.Services.AddScoped<ItipoPropiedadService, tipoPropiedadService>();
builder.Services.AddScoped<ItipoPropiedadRepository, tipoPropiedadRepository>();

builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();

builder.Services.AddScoped<IResidenteService, ResidenteService>();
builder.Services.AddScoped<IResidenteRepository, ResidenteRepository>();

builder.Services.AddScoped<IMultaService, MultaService>();
builder.Services.AddScoped<IMultaRepository, MultaRepository>();

builder.Services.AddScoped<IgravamenPropiedadService, gravamenPropiedadService>();
builder.Services.AddScoped<IgravamenPropiedadRepository, gravamenPropiedadRepository>();

builder.Services.AddScoped<IcontratoRepository, contratoRepository>();
builder.Services.AddScoped<IcontratoService, contratoService>();

builder.Services.AddScoped<IrenovacionContratoRepository, renovacionContratoRepository>();
builder.Services.AddScoped<IrenovacionContratoService, renovacionContratoService>();

builder.Services.AddScoped<IPagoService, PagoService>();
builder.Services.AddScoped<IPagoRepository, PagoRepository>();

builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();

builder.Services.AddScoped<IDetalleFacturaService, DetalleFacturaService>();
builder.Services.AddScoped<IDetalleFacturaRepository, DetalleFacturaRepository>();

builder.Services.AddScoped<ICicloFacturacionService, CicloFacturacionService>();
builder.Services.AddScoped<ICicloFacturacionRepository, CicloFacturacionRepository>();

builder.Services.AddScoped<ICuentaPorCobrarService, CuentaPorCobrarService>();
builder.Services.AddScoped<ICuentaPorCobrarRepository, CuentaPorCobrarRepository>();

builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();

builder.Services.AddScoped<IRegistroAccesoService, RegistroAccesoService>();
builder.Services.AddScoped<IRegistroAccesoRepository, RegistroAccesoRepository>();

builder.Services.AddScoped<IListaNegraService, ListaNegraService>();
builder.Services.AddScoped<IListaNegraRepository, ListaNegraRepository>();

builder.Services.AddScoped<IEspacioComunService, EspacioComunService>();
builder.Services.AddScoped<IEspacioComunRepository, EspacioComunRepository>();

builder.Services.AddScoped<IReservaEspacioService, ReservaEspacioService>();
builder.Services.AddScoped<IReservaEspacioRepository, ReservaEspacioRepository>();

builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<ILogAuditoriaService, LogAuditoriaService>();
builder.Services.AddScoped<ILogAuditoriaRepository, LogAuditoriaRepository>();

builder.Services.AddScoped<IVisitaAutorizadaService, VisitaAutorizadaService>();
builder.Services.AddScoped<IVisitaAutorizadaRepository, VisitaAutorizadaRepository>();

builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<ICargoRepository, CargoRepository>();

builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();
builder.Services.AddScoped<IAsistenciaRepository, AsistenciaRepository>();

builder.Services.AddScoped<IHorarioTurnoService, HorarioTurnoService>();
builder.Services.AddScoped<IHorarioTurnoRepository, HorarioTurnoRepository>();

builder.Services.AddScoped<IFamiliarResidenteService, FamiliarResidenteService>();
builder.Services.AddScoped<IFamiliarResidenteRepository, FamiliarResidenteRepository>();

builder.Services.AddScoped<IAcuerdoPagoService, AcuerdoPagoService>();
builder.Services.AddScoped<IAcuerdoPagoRepository, AcuerdoPagoRepository>();

builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();

builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();

builder.Services.AddScoped<IServicioActivoService, ServicioActivoService>();
builder.Services.AddScoped<IServicioActivoRepository, ServicioActivoRepository>();

builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();

builder.Services.AddScoped<IpropiedadService, propiedadService>();
builder.Services.AddScoped<IpropiedadRepository, propiedadRepository>();



var app = builder.Build();

// 🔹 MIDDLEWARE DE MANEJO DE ERRORES
app.UseMiddleware<ErrorHandlingMiddleware>();

// 🔹 ACTIVAR CORS
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