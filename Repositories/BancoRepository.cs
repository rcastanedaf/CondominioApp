using Condominio.Models;
using Condominio.Repositories.Interfaces;

namespace Condominio.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        public async Task<List<Banco>> GetAllAsync()
        {
            var list = new List<Banco>
            {
                new Banco { Id = 1, Nombre = "Test 1", Pais = 1, Activo = 1},
                new Banco { Id = 2, Nombre = "Test 2", Pais = 1, Activo = 1},
                new Banco { Id = 3, Nombre = "Test 3", Pais = 1, Activo = 1}
            };
            return list;
        }

        public async Task<List<Banco>> GetId(int id)
        {
            var list = new List<Banco>
            {
                new Banco { Id = 1, Nombre = "Test 1", Pais = 1, Activo = 1}
            };
            return list;
        }

        public async Task<List<Banco>> GetNombre(string nombre)
        {
            var list = new List<Banco>
            {
                new Banco { Id = 1, Nombre = "Test 1", Pais = 1, Activo = 1}
            };
            return list;
        }

        public async Task<List<Banco>> CreateBanco(Banco newBanco)
        {
            var list = new List<Banco>
            {
                new Banco { Id = 1, Nombre = "Test 1", Pais = 1, Activo = 1}
            };
            return list;
        }

        public async Task<List<Banco>> UpdateBanco(Banco editBanco)
        {
            var list = new List<Banco>
            {
                new Banco { Id = 1, Nombre = "Test 1", Pais = 1, Activo = 1}
            };
            return list;
        }

        public async Task<List<Banco>> DeleteBanco(int id)
        {
            var list = new List<Banco>
            {
                new Banco { Id = 1, Nombre = "Test 1", Pais = 1, Activo = 1}
            };
            return list;
        }
    }
}
