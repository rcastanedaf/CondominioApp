using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ICicloFacturacionService
    {
        Task<List<CicloFacturacionModel>> GetAllAsync();
        Task<CicloFacturacionModel?> GetByIdAsync(int id);
        Task<List<CicloFacturacionModel>> GetByPropiedadAsync(int idPropiedad);
        Task CreateAsync(CicloFacturacionModel model);
        Task UpdateAsync(CicloFacturacionModel model);
        Task DeleteAsync(int id);
    }
}
