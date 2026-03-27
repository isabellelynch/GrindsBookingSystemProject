using GrindsBookingSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GrindsBookingSystemTests
{
    [TestClass]
    public sealed class TutorTests
    {
        [TestMethod]
        public void TestZeroArgumentConstructor()
        {
            Tutor t = new Tutor();

            Assert.AreEqual(t.RateCode, null);
            Assert.AreEqual(t.Email, null);
            Assert.AreEqual(t.Phone, null);
            Assert.AreEqual(t.FirstName, null);
            Assert.AreEqual(t.Surname, null);

        }
    }
}
