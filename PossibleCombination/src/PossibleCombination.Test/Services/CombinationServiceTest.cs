using Microsoft.VisualStudio.TestTools.UnitTesting;
using PossibleCombination.Domain.Models;
using PossibleCombination.Domain.Services;
using PossibleCombination.Test.Respository;
using System.Linq;
using System.Threading.Tasks;

namespace PossibleCombination.Test.Services
{
    [TestClass]
    public class CombinationServiceTest
    {
        [TestMethod]
        public async Task ReturnSuccessWhenModelOk()
        {
            var model = new Combination() { Sequence = new int[] { 1, 2, 3 }, Target = 19 };
            var services = new CombinationService(new CombinationRepository());
            var result = await services.Generate(model);
            Assert.IsTrue(services.IsValid);
            Assert.IsFalse(services.Notifications.Count > 0);
            Assert.IsTrue(result.Count == 7);
            Assert.IsTrue(result.Where(x => x == 3).Count() == 6);
            Assert.IsTrue(result.Where(x => x == 2).Count() == 0);
            Assert.IsTrue(result.Where(x => x == 1).Count() == 1);
        }

        [TestMethod]
        public async Task ReturnErrorWhenModelWithoutTarget()
        {
            var model = new Combination() { Sequence = new int[] { 1, 2, 3 } };
            var services = new CombinationService(new CombinationRepository());
            await services.Generate(model);
            Assert.IsFalse(services.IsValid);
            Assert.IsTrue(services.Notifications.Count > 0);
        }

        [TestMethod]
        public async Task ReturnErrorWhenModelWithoutSequence()
        {
            var model = new Combination() { Target = 19 };
            var services = new CombinationService(new CombinationRepository());
            await services.Generate(model);
            Assert.IsFalse(services.IsValid);
            Assert.IsTrue(services.Notifications.Count > 0);
        }
    }
}
