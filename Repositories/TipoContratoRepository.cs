using Condominio.Models;
using Condominio.Repositories.Interfaces;

namespace Condominio.Repositories
{
    public class TipoContratoRepository : ITipoContratoRepository
    {
        private static List<TipoContratoModel> list = new List<TipoContratoModel>();

        public async Task<List<TipoContratoModel>> GetAllAsync()
        {
            return list;
        }

        public async Task<TipoContratoModel?> GetByIdAsync(int id)
        {
            return list.FirstOrDefault(x => x.Id == id);
        }

        public async Task<TipoContratoModel> CreateAsync(TipoContratoModel model)
        {
            model.Id = list.Count == 0 ? 1 : list.Max(x => x.Id) + 1;

            list.Add(model);

            return model;
        }

        public async Task<bool> UpdateAsync(TipoContratoModel model)
        {
            var existing = list.FirstOrDefault(x => x.Id == model.Id);

            if (existing == null)
                return false;

            existing.Nombre = model.Nombre;

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