using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PossibleCombination.Infra.Repositories
{
    public class BaseRepository
    {
        private readonly IConfiguration _configuration;
        public BaseRepository(IConfiguration configuration) => _configuration = configuration;
        protected async Task<int> ExecuteAsync(string query, object param = null)
        {
            var affectedRows = 0;
            using (SqlConnection connection = new(_configuration.GetConnectionString(Constants.CONTEXT_API)))
            {
                await connection.OpenAsync();
                affectedRows = await connection.ExecuteAsync(query, param);
                connection.Close();
            }
            return affectedRows;
        }

        protected async Task<List<T>> FindAllAsync<T>(string query, object param = null)
        {
            List<T> data = default;
            using (var connection = new SqlConnection(_configuration.GetConnectionString(Constants.CONTEXT_API)))
            {
                await connection.OpenAsync();
                data = (await connection.QueryAsync<T>(query, param)).ToList();
                connection.Close();
            }
            return data;
        }
    }
}
