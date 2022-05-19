using PossibleCombination.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PossibleCombination.Domain.Services.Interfaces
{
    public interface ICombinationService
    {
        public Task<IList<int>> Generate(Combination combination);
    }
}
