using MyWebApi.Models;

namespace MyWebApi.Services
{
    public interface IMyService
    {
        Task<IEnumerable<SqlUser>> GetUsersAsync();
    }
}