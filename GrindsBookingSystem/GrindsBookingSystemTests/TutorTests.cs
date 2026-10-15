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

            // the zero-argument constructors set every field to "" (not null), so the test now expects ""
            Assert.AreEqual("", t.RateCode);
            Assert.AreEqual("", t.Email);
            Assert.AreEqual("", t.Phone);
            Assert.AreEqual("", t.FirstName);
            Assert.AreEqual("", t.Surname);

        }

        [TestMethod]
        public void TestValidTutor()
        {
            Tutor t = new Tutor("Seán", "O'Brien", "sean.obrien@example.ie", "087-1234567", "SNR");

            Assert.AreEqual("Valid", t.IsValid());
        }

        [TestMethod]
        public void TestInvalidEmail()
        {
            Tutor t = new Tutor("Mary", "Murphy", "mary.murphy.example.ie", "087-1234567", "SNR");

            Assert.AreEqual("Email not in the correct format.", t.IsValid());
        }

        [TestMethod]
        public void TestInvalidPhone()
        {
            Tutor t = new Tutor("Mary", "Murphy", "mary@example.ie", "0871234567", "SNR");

            Assert.AreEqual("Phone Number not in the correct format, must be XXX-XXXXXXX.", t.IsValid());
        }

        [TestMethod]
        public void TestMissingRateCode()
        {
            Tutor t = new Tutor("Mary", "Murphy", "mary@example.ie", "087-1234567", "");

            Assert.AreEqual("Rate Code must be selected", t.IsValid());
        }

        [TestMethod]
        public void TestNameWithNumberIsInvalid()
        {
            Tutor t = new Tutor("Mary2", "Murphy", "mary@example.ie", "087-1234567", "SNR");

            Assert.AreEqual("First Name not in the correct format.", t.IsValid());
        }
    }
}
