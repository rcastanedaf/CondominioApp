#!/usr/bin/env pwsh

<#
.SYNOPSIS
Checklist de Validación - Sistema de Validación de Inputs
.DESCRIPTION
Verificar que todas las validaciones están implementadas correctamente
.AUTHOR
CondominioApp Backend
#>

Write-Host "
╔═══════════════════════════════════════════════════════════════╗
║       ✅ VALIDACIONES DE INPUTS - CHECKLIST DE VERIFICACIÓN       ║
╚═══════════════════════════════════════════════════════════════╝
" -ForegroundColor Cyan

$passed = 0
$failed = 0

# FUNCIÓN DE VERIFICACIÓN
function Test-Item {
	param(
		[string]$Description,
		[bool]$Condition
	)

	if ($Condition) {
		Write-Host "✅ $Description" -ForegroundColor Green
		$script:passed++
	} else {
		Write-Host "❌ $Description" -ForegroundColor Red
		$script:failed++
	}
}

Write-Host "`n📦 MIDDLEWARE" -ForegroundColor Yellow
Test-Item "ErrorHandlingMiddleware.cs existe" (Test-Path ".\Middleware\ErrorHandlingMiddleware.cs")
Test-Item "Program.cs incluye middleware" (Select-String -Path ".\Program.cs" -Pattern "ErrorHandlingMiddleware" -Quiet)

Write-Host "`n📋 DTOs CON VALIDACIONES" -ForegroundColor Yellow

$dtos = @(
	"PersonaCreateRequest.cs",
	"PersonaUpdateRequest.cs",
	"ResidenteCreateRequest.cs",
	"ResidenteUpdateRequest.cs",
	"BancoCreateRequest.cs",
	"BancoUpdateRequest.cs",
	"UsuarioCreateRequest.cs",
	"UsuarioUpdateRequest.cs",
	"EmpleadoCreateRequest.cs",
	"EmpleadoUpdateRequest.cs",
	"ProveedorCreateRequest.cs",
	"ProveedorUpdateRequest.cs",
	"VehiculoCreateRequest.cs",
	"VehiculoUpdateRequest.cs",
	"CargoCreateRequest.cs",
	"CargoUpdateRequest.cs",
	"ConceptoDescuentoCreateRequest.cs",
	"ConceptoDescuentoUpdateRequest.cs"
)

$validatedDtos = 0
foreach ($dto in $dtos) {
	$path = ".\DTOs\Request\$dto"
	if (Test-Path $path) {
		$hasValidation = Select-String -Path $path -Pattern "\[Required\]|\[StringLength\]|\[Range\]|\[EmailAddress\]|\[RegularExpression\]" -Quiet
		if ($hasValidation) {
			Write-Host "✅ $dto con validaciones" -ForegroundColor Green
			$script:passed++
			$validatedDtos++
		} else {
			Write-Host "⚠️  $dto SIN validaciones" -ForegroundColor Yellow
		}
	}
}

Write-Host "`n  → $validatedDtos/$($dtos.Count) DTOs validados" -ForegroundColor Cyan

Write-Host "`n🎮 CONTROLLERS ACTUALIZADOS" -ForegroundColor Yellow

$controllers = @(
	"PersonaController.cs",
	"BancoController.cs",
	"ResidenteController.cs",
	"EmpleadoController.cs",
	"UsuarioController.cs",
	"VehiculoController.cs",
	"ProveedorController.cs",
	"CargoController.cs",
	"ConceptoDescuentoController.cs"
)

$updatedControllers = 0
foreach ($controller in $controllers) {
	$path = ".\Controllers\$controller"
	if (Test-Path $path) {
		$hasApiResponse = Select-String -Path $path -Pattern "ApiResponse<object>" -Quiet
		$hasLogger = Select-String -Path $path -Pattern "ILogger<" -Quiet
		$hasModelStateCheck = Select-String -Path $path -Pattern "ModelState.IsValid" -Quiet

		if ($hasApiResponse -and $hasLogger -and $hasModelStateCheck) {
			Write-Host "✅ $controller completamente actualizado" -ForegroundColor Green
			$script:passed++
			$updatedControllers++
		} else {
			$missing = @()
			if (-not $hasApiResponse) { $missing += "ApiResponse" }
			if (-not $hasLogger) { $missing += "Logger" }
			if (-not $hasModelStateCheck) { $missing += "ModelStateCheck" }
			Write-Host "⚠️  $controller - Faltan: $($missing -join ', ')" -ForegroundColor Yellow
		}
	}
}

Write-Host "`n  → $updatedControllers/$($controllers.Count) Controllers actualizados" -ForegroundColor Cyan

Write-Host "`n📐 VALIDACIONES DE TIPOS DE DATOS" -ForegroundColor Yellow

$validationChecks = @(
	@{ Name = "DateOnly en Persona"; File = ".\DTOs\Request\PersonaCreateRequest.cs"; Pattern = "public required DateOnly Fecha_Nacimiento" },
	@{ Name = "DateOnly en Residente"; File = ".\DTOs\Request\ResidenteCreateRequest.cs"; Pattern = "public required DateOnly Fecha_Ingreso" },
	@{ Name = "DateOnly en Usuario"; File = ".\DTOs\Request\UsuarioCreateRequest.cs"; Pattern = "public DateOnly Fecha_Vencimiento" },
	@{ Name = "RegEx para nombres"; File = ".\DTOs\Request\PersonaCreateRequest.cs"; Pattern = "RegularExpression.*[a-záéíóúñ" },
	@{ Name = "EmailAddress"; File = ".\DTOs\Request\PersonaCreateRequest.cs"; Pattern = "EmailAddress" },
	@{ Name = "Range para activo"; File = ".\DTOs\Request\BancoCreateRequest.cs"; Pattern = "Range\(0, 1\)" }
)

foreach ($check in $validationChecks) {
	$found = Select-String -Path $check.File -Pattern $check.Pattern -Quiet -ErrorAction SilentlyContinue
	Test-Item $check.Name $found
}

Write-Host "`n🔍 PATRONES EN CONTROLLERS" -ForegroundColor Yellow

$patternChecks = @(
	@{ Name = "PersonaController valida IDs"; File = ".\Controllers\PersonaController.cs"; Pattern = "if \(id <= 0\)" },
	@{ Name = "BancoController usa ApiResponse"; File = ".\Controllers\BancoController.cs"; Pattern = "new ApiResponse<object>" },
	@{ Name = "EmpleadoController tiene logging"; File = ".\Controllers\EmpleadoController.cs"; Pattern = "_logger.LogError" },
	@{ Name = "ResidenteController [FromRoute]"; File = ".\Controllers\ResidenteController.cs"; Pattern = "\[FromRoute\] int id" },
	@{ Name = "UsuarioController NotFound"; File = ".\Controllers\UsuarioController.cs"; Pattern = "NotFound" }
)

foreach ($check in $patternChecks) {
	$found = Select-String -Path $check.File -Pattern $check.Pattern -Quiet -ErrorAction SilentlyContinue
	Test-Item $check.Name $found
}

Write-Host "`n📊 RESUMEN" -ForegroundColor Magenta
Write-Host "════════════════════════════════════════════════════════════════"
Write-Host "✅ APROBADO:  $passed" -ForegroundColor Green
Write-Host "❌ FALLÓ:     $failed" -ForegroundColor Red
Write-Host "📈 TOTAL:     $($passed + $failed)" -ForegroundColor Cyan
Write-Host "════════════════════════════════════════════════════════════════"

$percentage = if ($($passed + $failed) -gt 0) { [math]::Round(($passed / ($passed + $failed)) * 100, 2) } else { 0 }
Write-Host "📈 PORCENTAJE: $percentage%" -ForegroundColor Cyan

if ($percentage -eq 100) {
	Write-Host "`n🎉 ¡TODO ESTÁ PERFECTO! 🎉" -ForegroundColor Green
	Write-Host "La validación de inputs está completamente implementada." -ForegroundColor Green
	exit 0
} elseif ($percentage -ge 90) {
	Write-Host "`n⚠️  Casi completado. Revisar los items pendientes." -ForegroundColor Yellow
	exit 1
} else {
	Write-Host "`n❌ Aún hay trabajo pendiente." -ForegroundColor Red
	exit 1
}
