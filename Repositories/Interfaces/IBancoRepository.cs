using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IBancoRepository
    {
        public Task<List<Banco>> GetAllAsync();
        public Task<List<Banco>> GetId(int id);
        public Task<List<Banco>> GetNombre(string nombre);
        public Task<List<Banco>> CreateBanco(Banco newbanco);
        public Task<List<Banco>> UpdateBanco(Banco editbanco);
        public Task<List<Banco>> DeleteBanco(int id);

    }
}
