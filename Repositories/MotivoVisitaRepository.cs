using Condominio.Models;
using Condominio.Repositories.Interfaces;

namespace Condominio.Repositories
{
    public class MotivoVisitaRepository : IMotivoVisitaRepository
    {
        private static List<MotivoVisitaModel> list = new List<MotivoVisitaModel>();

        public async Task<List<MotivoVisitaModel>> GetAllAsync()
        {
            return list;
        }

        public async Task<MotivoVisitaModel?> GetByIdAsync(int id)
        {
            return list.FirstOrDefault(x => x.Id == id);
        }

        public async Task<MotivoVisitaModel> CreateAsync(MotivoVisitaModel model)
        {
            model.Id = list.Count == 0 ? 1 : list.Max(x => x.Id) + 1;

            list.Add(model);

            return model;
        }

        public async Task<bool> UpdateAsync(MotivoVisitaModel model)
        {
            var existing = list.FirstOrDefault(x => x.Id == model.Id);

            if (existing == null)
                return false;

            existing.Descripcion = model.Descripcion;

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = list.FirstOrDefault(x => x.Id == id);

            if (existing == null)
                return false;

            list.Remove(existing);

            return true;
        }
    }
}