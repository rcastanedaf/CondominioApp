using Condominio.Models;
using Condominio.Repositories.Interfaces;

namespace Condominio.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private static List<PaisModel> paises = new List<PaisModel>()
        {
            new PaisModel { Id = 1, Codigo = "GT", Nombre = "Guatemala"},
            new PaisModel { Id = 2, Codigo = "AR", Nombre = "Argentina"}
        };

        public async Task<List<PaisModel>> GetAll()
        {
            return await Task.FromResult(paises);
        }

        public async Task<PaisModel> Create(PaisModel model)
        {
            model.Id = paises.Count + 1;
            paises.Add(model);
            return await Task.FromResult(model);
        }

        public async Task<PaisModel> GetById(int id)
        {
            var pais = paises.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(pais);
        }

        public async Task<PaisModel> Update(int id, PaisModel model)
        {
            var pais = paises.FirstOrDefault(x => x.Id == id);

            if (pais == null)
                return null;

            pais.Codigo = model.Codigo;
            pais.Nombre = model.Nombre;

            return await Task.FromResult(pais);
        }

        public async Task<PaisModel> Delete(int id)
        {
            var pais = paises.FirstOrDefault(x => x.Id == id);
            if (pais == null)
                return null;

            paises.Remove(pais);
            return await Task.FromResult(pais);
        }
    }
}
