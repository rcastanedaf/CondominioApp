using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ICicloFacturacionRepository
    {
        Task<List<CicloFacturacionModel>> GetAllAsync();
        Task<CicloFacturacionModel?> GetByIdAsync(int id);
        Task<List<CicloFacturacionModel>> GetByPropiedadAsync(int idPropiedad);
        Task CreateAsync(CicloFacturacionModel model);
        Task UpdateAsync(CicloFacturacionModel model);
        Task DeleteAsync(int id);
    }
}
