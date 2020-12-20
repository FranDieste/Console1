using ConsoleApp1.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestingSamples
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ResultOfTheAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything()
        {
            // arrange
            int expected = 42;
            var dt = new DeepThrought();

            // act
            int actual = dt.TheAnswerOfTheUltimateQuestionOfLifeTheUniverseAndEverything();
            // assert
            Assert.AreEqual(expected, actual);
        }




    }
}
