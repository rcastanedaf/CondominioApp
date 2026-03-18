using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories.Interfaces;

namespace Condominio.Services
{
    public class ConceptoDescuentoService
    {
        private readonly IConceptoDescuentoRepository _conceptoDescuentoRepository;

        public ConceptoDescuentoService(IConceptoDescuentoRepository conceptoDescuentoRepository)
        {
            _conceptoDescuentoRepository = conceptoDescuentoRepository;
        }

        public async Task<ApiResponse<List<Concepto_Descuento>>> GetAllAsync()
        {
            try
            {
                var allConceptoDescuento = await _conceptoDescuentoRepository.GetAllAsync();

                return ApiResponse<List<Concepto_Descuento>>.Ok(allConceptoDescuento);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Concepto_Descuento>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<List<Concepto_Descuento>>> GetId(int id)
        {
            try
            {
                var idConceptoDescuento = await _conceptoDescuentoRepository.GetId(id);

                return ApiResponse<List<Concepto_Descuento>>.Ok(idConceptoDescuento);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Concepto_Descuento>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<List<Concepto_Descuento>>> GetNombre(string nombre)
        {
            try
            {
                var nombreConceptoDescuento = await _conceptoDescuentoRepository.GetNombre(nombre);

                return ApiResponse<List<Concepto_Descuento>>.Ok(nombreConceptoDescuento);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Concepto_Descuento>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<List<Concepto_Descuento>>> UpdateConceptoDescuento(Concepto_Descuento editConceptoDescuento)
        {
            try
            {
                var conceptoDescuento = await _conceptoDescuentoRepository.UpdatetConceptoDescuento(editConceptoDescuento);

                return ApiResponse<List<Concepto_Descuento>>.Ok(conceptoDescuento);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Concepto_Descuento>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<List<Concepto_Descuento>>> CreateConceptoDescuento(Concepto_Descuento newConceptoDescuento)
        {
            try
            {
                var bus = await _conceptoDescuentoRepository.GetNombre(newConceptoDescuento.Nombre);
                if (bus != null)
                {
                    var conceptoDescuento = await _conceptoDescuentoRepository.CreateConceptoDescuento(newConceptoDescuento);

                    return ApiResponse<List<Concepto_Descuento>>.Ok(conceptoDescuento);
                }
                else
                {
                    return ApiResponse<List<Concepto_Descuento>>.Fail("Banco ya existente");
                }
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Concepto_Descuento>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<List<Concepto_Descuento>>> DeleteConceptoDescuento(int id)
        {
            try
            {
                var conceptoDescuento = await _conceptoDescuentoRepository.DeleteConceptoDescuento(id);
                return ApiResponse<List<Concepto_Descuento>>.Ok(conceptoDescuento);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Concepto_Descuento>>.Fail(ex.Message);
            }
        }
    }
}
