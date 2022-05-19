using PossibleCombination.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PossibleCombination.Domain.IRepositories
{
    public interface ICombinationRepository
    {
        Task<List<CombinationHistoric>> GetByRangeDate(DateTime inicial, DateTime final);
        Task<int> Insert(CombinationHistoric combinationHistoric);
    }
}
