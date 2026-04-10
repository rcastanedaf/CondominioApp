using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class ConceptoDescuentoService : IConceptoDescuentoService
    {
        private readonly IConceptoDescuentoRepository _conceptoDescuentoRepository;

        public ConceptoDescuentoService(IConceptoDescuentoRepository conceptoDescuentoRepository)
        {
            _conceptoDescuentoRepository = conceptoDescuentoRepository;
        }

        public async Task<List<Concepto_Descuento>> GetAllAsync()
        {
            try
            {
                var allConceptoDesc = await _conceptoDescuentoRepository.GetAllAsync();

                return allConceptoDesc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Concepto_Descuento>> GetId(int id)
        {
            try
            {
                var allConceptoDesc = await _conceptoDescuentoRepository.GetId(id);

                return allConceptoDesc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Concepto_Descuento>> GetNombre(string nombre)
        {
            try
            {
                var allConceptoDesc = await _conceptoDescuentoRepository.GetNombre(nombre);

                return allConceptoDesc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ConceptoDescuentoUpdateRequest> UpdateConceptoDescuento(ConceptoDescuentoUpdateRequest editConceptoDescuento)
        {
            try
            {
                var conceptoDesc = await _conceptoDescuentoRepository.UpdateConceptoDescuento(editConceptoDescuento);

                return conceptoDesc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ConceptoDescuentoCreateRequest> CreateConceptoDescuento(ConceptoDescuentoCreateRequest newConceptoDescuento)
        {
            try
            {
                var conceptoDesc = await _conceptoDescuentoRepository.CreateConceptoDescuento(newConceptoDescuento);

                return conceptoDesc;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> DeleteConceptoDescuento(int id)
        {
            try
            {
                var response = _conceptoDescuentoRepository.DeleteConceptoDescuento(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
