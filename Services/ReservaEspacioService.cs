using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class ReservaEspacioService : IReservaEspacioService
    {
        private readonly IReservaEspacioRepository _repo;
        public ReservaEspacioService(IReservaEspacioRepository repo) => _repo = repo;

        public Task<List<ReservaEspacioModel>> GetAllAsync()    => _repo.GetAllAsync();
        public Task<List<ReservaEspacioModel>> GetByEspacio(int id)   => _repo.GetByEspacio(id);
        public Task<List<ReservaEspacioModel>> GetByResidente(int id) => _repo.GetByResidente(id);
        public Task<bool> CambiarEstado(int id, string estado, int? aprobadoPor) => _repo.CambiarEstado(id, estado, aprobadoPor);

        public async Task<ReservaEspacioCreateRequest> Create(ReservaEspacioCreateRequest r)
        {
            await CheckOverlap(r.Id_Espacio, r.Fecha_Reserva, r.Hora_Inicio, r.Hora_Fin);
            return await _repo.Create(r);
        }

        public async Task<ReservaEspacioUpdateRequest> Update(ReservaEspacioUpdateRequest r)
        {
            await CheckOverlap(r.Id_Espacio, r.Fecha_Reserva, r.Hora_Inicio, r.Hora_Fin, r.Id_Reserva);
            return await _repo.Update(r);
        }

        private async Task CheckOverlap(int idEspacio, DateOnly fecha, TimeSpan horaInicio, TimeSpan horaFin, int? excludeId = null)
        {
            var fechaStr  = fecha.ToString("yyyy-MM-dd");
            var inicioStr = horaInicio.ToString(@"hh\:mm\:ss");
            var finStr    = horaFin.ToString(@"hh\:mm\:ss");

            bool overlap = await _repo.HasOverlap(idEspacio, fechaStr, inicioStr, finStr, excludeId);
            if (overlap)
                throw new InvalidOperationException(
                    $"El espacio ya tiene una reserva activa que se cruza con el horario {inicioStr[..5]}–{finStr[..5]} el {fechaStr}.");
        }
    }
}
