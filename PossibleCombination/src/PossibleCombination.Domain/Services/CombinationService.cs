using PossibleCombination.Domain.IRepositories;
using PossibleCombination.Domain.Models;
using PossibleCombination.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PossibleCombination.Domain.Services
{
    public class CombinationService : ICombinationService 
    {
        private int value;
        private int[] ordenado;
        private readonly IList<int> arrayretorno = new List<int>();
        private readonly ICombinationRepository _repository;
        public CombinationService(ICombinationRepository repository) => _repository = repository;

        public override async Task<IList<int>> Generate(Combination combination)
        {
            combination.Validate();
            if (!combination.IsValid)
            {
                AddNotifications(combination);
                return new List<int>();
            }
            await _repository.Insert(combination);
            value = combination.Target;
            ordenado = combination.Sequence.OrderByDescending(x => x).ToArray();
            foreach (var ord in ordenado)
                ProcessValue(ord);
            return arrayretorno.OrderBy(x => x).ToList();
        }

        private void ProcessValue(int ord)
        {
            var val = value - ord;
            if (val >= 0)
            {
                value = val;
                arrayretorno.Add(ord);
                ProcessValue(ord);
            }
        }
    }
}
