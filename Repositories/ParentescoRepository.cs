using Condominio.Models;
using Condominio.Repositories.Interfaces;

namespace Condominio.Repositories
{
    public class ParentescoRepository : IParentescoRepository
    {
        private static List<ParentescoModel> parentescos = new List<ParentescoModel>()
        {
            new ParentescoModel { Id = 1, Nombre = "Padre" },
            new ParentescoModel { Id = 2, Nombre = "Madre" }
        };

        public async Task<List<ParentescoModel>> GetAll()
        {
            return await Task.FromResult(parentescos);
        }

        public async Task<ParentescoModel> Create(ParentescoModel model)
        {
            model.Id = parentescos.Count + 1;
            parentescos.Add(model);
            return await Task.FromResult(model);
        }

        public async Task<ParentescoModel> GetById(int id)
        {
            var parentesco = parentescos.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(parentesco);
        }

        public async Task<ParentescoModel> Update(int id, ParentescoModel model) 
        {
            var parentesco = parentescos.FirstOrDefault(x => x.Id == id);

            if (parentesco == null)
                return null;

            parentesco.Nombre = model.Nombre;

            return await Task.FromResult(parentesco);
        }

        public async Task<ParentescoModel> Delete(int id)
        {
            var parentesco = parentescos.FirstOrDefault(x => x.Id == id);

            if (parentesco == null)
                return null;

            parentescos.Remove(parentesco);

            return await Task.FromResult(parentesco);
        }
    }
}
