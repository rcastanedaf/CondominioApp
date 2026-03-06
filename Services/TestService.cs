using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public async Task<ApiResponse<List<TestModel>>> GetAllAsync()
        {
            try
            {
                var allTest = await _testRepository.GetAllAsync();

                return ApiResponse<List<TestModel>>.Ok(allTest);
            }
            catch(Exception ex)
            {
                return ApiResponse<List<TestModel>>.Fail(ex.Message);
            }
        }
    }
}
