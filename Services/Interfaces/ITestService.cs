using Condominio.DTOs.Response;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ITestService
    {
        public Task<ApiResponse<List<TestModel>>> GetAllAsync();
    }
}
