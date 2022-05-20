using Microsoft.VisualStudio.TestTools.UnitTesting;
using PossibleCombination.Domain.Models;

namespace PossibleCombination.Test.Models
{
    public class CombinationTest
    {
        [TestMethod]
        public void ReturnSuccessWhenModelOk()
        {
            var model = new Combination() { Sequence = new int[] { 1, 2, 3 }, Target = 19 };
            model.Validate();
            Assert.IsTrue(model.IsValid);
            Assert.IsFalse(model.Notifications.Count > 0);
        }

        [TestMethod]
        public void ReturnErrorWhenModelWithoutTarget()
        {
            var model = new Combination() { Sequence = new int[] { 1, 2, 3 } };
            model.Validate();
            Assert.IsFalse(model.IsValid);
            Assert.IsTrue(model.Notifications.Count > 0);
        }

        [TestMethod]
        public void ReturnErrorWhenModelWithoutSequence()
        {
            var model = new Combination() { Target = 19 };
            model.Validate();
            Assert.IsFalse(model.IsValid);
            Assert.IsTrue(model.Notifications.Count > 0);
        }
    }
}
