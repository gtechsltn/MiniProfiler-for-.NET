using MyWebApi.Data;
using MyWebApi.Models;
using Dapper;

namespace MyWebApi.Services
{
    public class MyService : IMyService
    {

        private readonly DapperContext _dapperContext;

        public MyService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<SqlUser>> GetUsersAsync()
        {
            using var connection = _dapperContext.CreateConnection();
            return await connection.QueryAsync<SqlUser>("SELECT * FROM Users");
        }
    }

}
