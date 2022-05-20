using Flunt.Notifications;
using Flunt.Validations;

namespace PossibleCombination.Domain.Models
{
    public class Combination : Notifiable<Notification>
    {
        public int Target { get; set; }
        public int[] Sequence { get; set; }
        public Combination() => Sequence = System.Array.Empty<int>();

        public void Validate()
        {
            AddNotifications(new Contract<Combination>()
                .Requires()
                .IsGreaterThan(Target, 0, "Target", "O número alvo não pode estar vazio")
                .IsTrue(Sequence.Length > 0, "Sequence", "As pontuações não podem estar vazias")
            );
        }
    }
}
