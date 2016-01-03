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
            float min = 1;
            float max = 11;
            
            float actualResult = logTrans.NumToLog(input, min, max);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = 3.30103f;
            input = 2000;
            min = 0;
            max = 10000;
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
            float min = -9;
            float max = -11;
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
            float max = 10;
            bool isPreviousNumberNegative = false;
            float actualResult = logTrans.LogToNum(input, min, max, isPreviousNumberNegative);
            Assert.AreEqual(expectedResult, actualResult);
        }



        [TestMethod]
        public void WhenNegativeLogValue_ShouldReturnMinusValue()
        {
            LogTransformation logTrans = new LogTransformation();
            float expectedResult = -10;
            float input = -1;
            float min = -2;
            float max = 0;
            bool isPreviousNumberNegative = true;
            float actualResult = logTrans.LogToNum(input, min, max, isPreviousNumberNegative);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = 0.000014f;
            input = -4.853872f;
            min = -3;
            max = -5;
            isPreviousNumberNegative = false;
            actualResult = logTrans.LogToNum(input, min, max, isPreviousNumberNegative);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000000);
        }
    }
}
