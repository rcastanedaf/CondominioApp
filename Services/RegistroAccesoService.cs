using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class RegistroAccesoService : IRegistroAccesoService
    {
        private readonly IRegistroAccesoRepository _repo;
        public RegistroAccesoService(IRegistroAccesoRepository repo) => _repo = repo;

        public Task<List<RegistroAccesoModel>> GetAllAsync(int? top) => _repo.GetAllAsync(top);
        public Task<List<RegistroAccesoModel>> GetByFecha(string d, string h) => _repo.GetByFecha(d, h);
        public Task<RegistroAccesoCreateRequest> Create(RegistroAccesoCreateRequest r) => _repo.Create(r);

    }
}
