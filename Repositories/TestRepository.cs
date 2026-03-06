using Condominio.Models;
using Condominio.Repositories.Interfaces;

namespace Condominio.Repositories
{
    public class TestRepository : ITestRepository
    {

        public async Task<List<TestModel>> GetAllAsync()
        {
            var list = new List<TestModel>
            {
                new TestModel { Id = 1, Name = "Test 1" , Description = "desc 1"},
                new TestModel { Id = 2, Name = "Test 2", Description = "desc 1" },
                new TestModel { Id = 3, Name = "Test 3", Description = "desc 1" }
            };
            return list;
        }
    }
}
