using Flunt.Notifications;
using PossibleCombination.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PossibleCombination.Domain.Services.Interfaces
{
    public abstract class ICombinationService : Notifiable<Notification>
    {
        public abstract Task<IList<int>> Generate(Combination combination);
    }
}
