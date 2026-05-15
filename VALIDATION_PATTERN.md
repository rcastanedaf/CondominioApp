/* PATRÓN DE VALIDACIÓN PARA CONTROLLERS

Este patrón debe aplicarse a todos los controllers para garantizar validación consistente.

1. VALIDAR MODELSTATE EN POST/PUT:
   if (!ModelState.IsValid)
   {
	   var errors = ModelState.Values.SelectMany(v => v.Errors)
		   .Select(e => e.ErrorMessage)
		   .ToList();

	   return BadRequest(new ApiResponse<object>
	   {
		   Success = false,
		   Message = "Error en los datos enviados",
		   Data = errors
	   });
   }

2. VALIDAR IDs EN ROUTE:
   if (id <= 0)
   {
	   return BadRequest(new ApiResponse<object>
	   {
		   Success = false,
		   Message = "El ID debe ser un número válido mayor a 0",
		   Data = null
	   });
   }

3. USAR [FromRoute] EN GETs, NO [FromBody]:
   [HttpGet("get-id-item/{id}")]
   public async Task<IActionResult> GetById([FromRoute] int id)

4. RESPUESTAS ESTANDARIZADAS:
   - Success: OK(new ApiResponse<object> { Success = true, ... })
   - Error: BadRequest(new ApiResponse<object> { Success = false, ... })
   - NotFound: NotFound(new ApiResponse<object> { Success = false, ... })

5. LOGGING:
   _logger.LogError(ex, "Descripción del error con contexto");

6. DTOs DEBEN TENER:
   - [Required] en campos obligatorios
   - [StringLength] en textos
   - [Range] en números
   - [EmailAddress] en emails
   - [RegularExpression] para patrones específicos
   - Usar DateOnly, NO string para fechas
*/
