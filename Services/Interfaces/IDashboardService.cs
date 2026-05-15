using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IDashboardService
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