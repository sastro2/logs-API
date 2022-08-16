using logs_API.Data;
using logs_API.Dtos;
using logs_API.Models.ResponseModels;

namespace logs_API.Interfaces
{
    public interface ITypes
    {
        public List<TypeDto> GetTypes(DataContext context, int projectId);
        public Task<Error?> CreateType(DataContext context, string name, int projectId, bool sendImmediately);
        public Task<Error?> DeleteType(DataContext context, int id, int projectId);
    }
}
