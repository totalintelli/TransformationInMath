using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transformation;
namespace TransformationTest
{
    [TestClass]
    public class TransformationTest
    {
        [TestMethod]
        public void WhenPositiveNumber_ShouldReturnValue()
        {
            LogTransformation logTrans = new LogTransformation();
            float expectedResult = 1.0f;
            float input = 10;
            float min = 0;
            float max = 43.78f;
            
            float actualResult = logTrans.NumToLog(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = 3;
            input = 1000;
            min = 0;
            max = 1779;
            actualResult = logTrans.NumToLog(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);
        }



        [TestMethod]
        public void WhenMiniPositiveNumber_ShouldReturnMinusNumber()
        {
            LogTransformation logTrans = new LogTransformation();
            float expectedResult = -4.853872f;
            float input = 0.000014f;
            float min = 0;
            float max = 1;
            float actualResult = logTrans.NumToLog(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);
        }



        [TestMethod]
        public void WhenNegativeNumber_ShouldReturnMinusNumber()
        {
            LogTransformation logTrans = new LogTransformation();
            float expectedResult = -1;
            float input = -10;
            float min = -1235;
            float max = -5;
            float actualResult = logTrans.NumToLog(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void WhenZero_ShouldReturnNaN()
        {
            LogTransformation logTrans = new LogTransformation();
            float expectedResult = float.NaN;
            float input = 0;
            float min = -1;
            float max = 1;
            float actualResult = logTrans.NumToLog(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);
        }



        [TestMethod]
        public void WhenOutOfRangeNumber_ShouldReturnNaN()
        {
            LogTransformation logTrans = new LogTransformation();
            float expectedResult = float.NaN;
            float input = 3;
            float min = 4;
            float max = 5;
            float actualResult = logTrans.NumToLog(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);
        }



        [TestMethod]
        public void WhenPositiveLogVaule_ShouldReturnValue()
        {
            LogTransformation logTrans = new LogTransformation();
            float expectedResult = 10;
            float input = 1;
            float min = 0;
            float max = 1779;
            float actualResult = logTrans.LogToNum(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = 0.1f;
            input = -1;
            min = 0.1170848f;
            max = 1.09512f;
            actualResult = logTrans.LogToNum(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);
        }



        [TestMethod]
        public void WhenNegativeLogValue_ShouldReturnMinusValue()
        {
            LogTransformation logTrans = new LogTransformation();
            float expectedResult = -1000;
            float input = -3;
            float min = -1235;
            float max = -5;
            float actualResult = logTrans.LogToNum(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = -10;
            input = -1;
            min = -100;
            max = -2;
            actualResult = logTrans.LogToNum(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = -100;
            input = -2;
            min = -1000;
            max = 2990;
            actualResult = logTrans.LogToNum(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
