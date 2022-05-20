using Newtonsoft.Json;
using System;

namespace PossibleCombination.Domain.Models
{
    public class CombinationHistoric
    {
        public DateTime SearchDate { get; set; }
        public string Combination { get; set; }

        public CombinationHistoric(Combination combination)
        {
            SearchDate = DateTime.Now;
            Combination = JsonConvert.SerializeObject(combination);
        }

        public static implicit operator CombinationHistoric(Combination saveCompany) => new(saveCompany);
    }
}
