using PossibleCombination.Domain.IRepositories;
using PossibleCombination.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PossibleCombination.Test.Respository
{
    public class CombinationRepository : ICombinationRepository
    {
        public Task<List<CombinationHistoric>> GetByRangeDate(DateTime inicial, DateTime final) 
            => throw new NotImplementedException();

        public async Task<int> Insert(CombinationHistoric combinationHistoric) => 1;
    }
}
