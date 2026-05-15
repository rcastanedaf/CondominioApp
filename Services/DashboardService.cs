using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repo;
        public DashboardService(IDashboardRepository repo) { _repo = repo; }

        public Task<DashboardModel> GetDashboardAsync() => _repo.GetDashboardAsync();
        public Task<DashboardFinancieroModel> GetDashboardFinancieroAsync() => _repo.GetDashboardFinancieroAsync();
        public Task<DashboardResidentesModel> GetDashboardResidentesAsync() => _repo.GetDashboardResidentesAsync();
        public Task<DashboardAccesoModel> GetDashboardAccesoAsync() => _repo.GetDashboardAccesoAsync();
        public Task<DashboardIncidenciasModel> GetDashboardIncidenciasAsync() => _repo.GetDashboardIncidenciasAsync();
        public Task<DashboardEspaciosModel> GetDashboardEspaciosAsync() => _repo.GetDashboardEspaciosAsync();
        public Task<DashboardPersonalModel> GetDashboardPersonalAsync() => _repo.GetDashboardPersonalAsync();
        public Task<DashboardContratosModel> GetDashboardContratosAsync() => _repo.GetDashboardContratosAsync();
        public Task<DashboardMultasModel> GetDashboardMultasAsync() => _repo.GetDashboardMultasAsync();
    }
}