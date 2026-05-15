#!/usr/bin/env pwsh

<#
.SYNOPSIS
Script para aplicar validaciones a DTOs restantes
.DESCRIPTION
Este script ayuda a identificar y actualizar DTOs sin validaciones
#>

# DTOs que aún NECESITAN validaciones basado en el análisis
$DTOsPendientes = @(
	"MultaCreateRequest",
	"MultaUpdateRequest",
	"FacturaCreateRequest",
	"PagoCreateRequest",
	"PagoUpdateRequest",
	"VisitaAutorizadaCreateRequest",
	"VisitaAutorizadaUpdateRequest",
	"ReservaEspacioCreateRequest",
	"ReservaEspacioUpdateRequest",
	"EspacioComunCreateRequest",
	"EspacioComunUpdateRequest",
	"ListaNegraCreateRequest",
	"ListaNegraUpdateRequest",
	"CuentaPorCobrarCreateRequest",
	"DetalleFacturaCreateRequest",
	"IncidenciaCreateRequest",
	"SeguimientoIncidenciaCreateRequest",
	"RegistroAccesoCreateRequest",
	"AsistenciaCreateRequest",
	"CicloFacturacionCreateRequest",
	"CobroMoraCreateRequest",
	"CategoriaIncidenciaCreateRequest",
	"TipoContratoCreateRequest",
	"TipoMonedaCreateRequest",
	"MetodoPagoCreateRequest"
)

# Mostrar DTOs pendientes
Write-Host "=== DTOs QUE AÚN NECESITAN VALIDACIONES ===" -ForegroundColor Cyan
$DTOsPendientes | ForEach-Object { Write-Host "- $_" -ForegroundColor Yellow }

Write-Host "`n=== PATRÓN A APLICAR ===" -ForegroundColor Green
Write-Host @"
using System.ComponentModel.DataAnnotations;

namespace Condominio.DTOs.Request
{
	public class TuDTOCreateRequest
	{
		[Required(ErrorMessage = "Campo requerido")]
		[StringLength(100, MinimumLength = 1)]
		public required string Nombre { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Debe ser un número válido")]
		public required int Id { get; set; }

		[Range(0, double.MaxValue)]
		public required decimal Monto { get; set; }
	}
}
"@

Write-Host "`n=== CONTROLLERS QUE NECESITAN ACTUALIZACIÓN ===" -ForegroundColor Cyan

$ControllersActualizados = @(
	"PersonaController",
	"BancoController",
	"ResidenteController",
	"EmpleadoController"
)

$ControllersRestantes = @(
	"MultaController",
	"FacturaController",
	"PagoController",
	"VisitaAutorizadaController",
	"ReservaEspacioController",
	"EspacioComunController",
	"ListaNegraController",
	"CuentaPorCobrarController",
	"DetalleFacturaController",
	"IncidenciaController",
	"SeguimientoIncidenciaController",
	"RegistroAccesoController",
	"AsistenciaController",
	"CicloFacturacionController",
	"CobroMoraController",
	"CategoriaIncidenciaController",
	"TipoContratoController",
	"TipoMonedaController",
	"MetodoPagoController",
	"ProveedorController",
	"UsuarioController",
	"VehiculoController",
	"CargoController",
	"ConceptoDescuentoController"
)

Write-Host "`n✅ ACTUALIZADOS: $($ControllersActualizados.Count)" -ForegroundColor Green
$ControllersActualizados | ForEach-Object { Write-Host "✓ $_" }

Write-Host "`n⏳ PENDIENTES: $($ControllersRestantes.Count)" -ForegroundColor Yellow
$ControllersRestantes | ForEach-Object { Write-Host "○ $_" }

Write-Host "`n=== CHECKLIST DE CAMBIOS ===" -ForegroundColor Magenta
Write-Host @"
Para cada DTO:
☐ Añadir 'using System.ComponentModel.DataAnnotations;'
☐ Aplicar [Required] a campos obligatorios
☐ Aplicar [StringLength] a textos
☐ Aplicar [Range] a números
☐ Aplicar [EmailAddress] a emails
☐ Aplicar [RegularExpression] a patrones
☐ Convertir strings de fecha a DateOnly
☐ Mantener valores por defecto si aplica

Para cada Controller:
☐ Añadir 'using Condominio.DTOs.Response;'
☐ Inyectar ILogger<NombreController>
☐ Cambiar [FromBody] por [FromRoute] en GETs
☐ Añadir validación de ModelState en POST/PUT
☐ Usar ApiResponse<object> en respuestas
☐ Añadir _logger.LogError en catch blocks
☐ Añadir NotFound() para resultados vacíos
☐ Validar IDs <= 0
"@

Write-Host "`n=== ESTIMADO ===" -ForegroundColor Blue
Write-Host "DTOs restantes: $($DTOsPendientes.Count)"
Write-Host "Controllers restantes: $($ControllersRestantes.Count)"
Write-Host "Tiempo estimado: 2-3 horas (siguiendo el patrón)"
