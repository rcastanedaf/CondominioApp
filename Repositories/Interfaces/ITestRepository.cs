using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ITestRepository
    {
        public Task<List<TestModel>> GetAllAsync();
    }
}
