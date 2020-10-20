using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace INPTPZ1.Mathematics.Tests
{
    [TestClass()]
    public class ComplexNumberTests
    {

        [TestMethod()]
        public void AddTest()
        {
            ComplexNumber fistNumber = new ComplexNumber()
            {
                RealPartOfNumber = 10,
                ImaginarPartOfNumber = 20
            };
            ComplexNumber secondNumber = new ComplexNumber()
            {
                RealPartOfNumber = 1,
                ImaginarPartOfNumber = 2
            };

            ComplexNumber actual = fistNumber.Add(secondNumber);
            ComplexNumber shouldBe = new ComplexNumber()
            {
                RealPartOfNumber = 11,
                ImaginarPartOfNumber = 22
            };

            Assert.AreEqual(shouldBe, actual);
        }
    }
}


