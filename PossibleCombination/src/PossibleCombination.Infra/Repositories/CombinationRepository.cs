using Microsoft.Extensions.Configuration;
using PossibleCombination.Domain.IRepositories;
using PossibleCombination.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PossibleCombination.Infra.Repositories
{
    public class CombinationRepository : BaseRepository, ICombinationRepository
    {
        public CombinationRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<List<CombinationHistoric>> GetByRangeDate(DateTime inicial, DateTime final)
        {
            var query = "select * from CombinationHistoric where SearchDate between @inicial and @final";
            var param = new { inicial, final };
            return await FindAllAsync<CombinationHistoric>(query, param);
        }

        public async Task<int> Insert(CombinationHistoric combinationHistoric)
        {
            var query = "insert into CombinationHistoric (Combination, SearchDate) values (@Combination, @SearchDate)";
            return await ExecuteAsync(query, combinationHistoric);
        }
    }
}
