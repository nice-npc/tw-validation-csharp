using TwValidationCsharp;

namespace TwValidationCsharp.Test
{
    [TestClass]
    public class UnitTestIDNumber
    {
        [TestMethod]
        public void TestMethodRealId()
        {
            Assert.IsTrue(IDNumber.ValidateIDNumber("A123456789"));
        }

        [TestMethod]
        public void TestMethodFakeId()
        {
            Assert.IsFalse(IDNumber.ValidateIDNumber("L125742501"));
        }

        [TestMethod]
        public void TestMethodErrFormat1()
        {
            Assert.IsFalse(IDNumber.ValidateIDNumber("G555666"));
        }

        [TestMethod]
        public void TestMethodErrFormat2()
        {
            Assert.IsFalse(IDNumber.ValidateIDNumber("K9999999999"));
        }
    }
}