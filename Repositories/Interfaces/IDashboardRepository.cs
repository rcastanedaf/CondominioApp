using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IDashboardRepository
    {
        Task<DashboardModel> GetDashboardAsync();
        Task<DashboardFinancieroModel> GetDashboardFinancieroAsync();
        Task<DashboardResidentesModel> GetDashboardResidentesAsync();
        Task<DashboardAccesoModel> GetDashboardAccesoAsync();
        Task<DashboardIncidenciasModel> GetDashboardIncidenciasAsync();
        Task<DashboardEspaciosModel> GetDashboardEspaciosAsync();
        Task<DashboardPersonalModel> GetDashboardPersonalAsync();
        Task<DashboardContratosModel> GetDashboardContratosAsync();
        Task<DashboardMultasModel> GetDashboardMultasAsync();
    }
}