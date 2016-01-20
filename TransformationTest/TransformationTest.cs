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

            expectedResult = 3.475671f;
            input = 2990;
            min = 2990;
            max = 2990;
            actualResult = logTrans.NumToLog(input, min, max);
            Assert.AreEqual(expectedResult, actualResult, delta: actualResult / 1000000);

            expectedResult = 3.601517f;
            input = 3995;
            min = 3995;
            max = 3995;
            actualResult = logTrans.NumToLog(input, min, max);
            Assert.AreEqual(expectedResult, actualResult, delta: actualResult / 1000000);
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

            expectedResult = -3;
            input = -1000;
            min = -1000;
            max = -1000;
            actualResult = logTrans.NumToLog(input, min, max);
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

        [TestMethod]
        public void WhenPositiveValue_ShouldReturnPositivePointValue()
        {
            LogTransformation logTrans = new LogTransformation();
            double expectedResult = 242;
            float Value = 1;
            float Min = 0;
            float Max = 154;
            bool isX = false;
            double actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = 264.5;
            Value = 10;
            Min = 0;
            Max = 43.78f;
            isX = true;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = 429;
            Value = 100;
            Min = 0;
            Max = 43.78f;
            isX = true;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = 100;
            Value = 1;
            Min = 0;
            Max = 43.78f;
            isX = true;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = 80;
            Value = 0;
            Min = 0;
            Max = 43.78f;
            isX = true;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            expectedResult = 82;
            Value = 0.1f;
            Min = 0;
            Max = 43.78f;
            isX = true;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult, delta: actualResult / 1000000);

            Value = 0.044f;
            Min = 0;
            Max = 43.78f;
            isX = true;
            expectedResult = 80.88f;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult, delta: actualResult / 1000000);

            Value = 10;
            Min = 0;
            Max = 154;
            isX = false;
            expectedResult = 188;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult, delta: actualResult / 1000000);

            Value = 0.2677702f;
            Min = 0.01099479f;
            Max = 1.095801f;
            isX = false;
            expectedResult = 256.644596;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult, delta: actualResult / 1000000);

            Min = 0.01000768f;
            Max = 1.096188f;
            Value = 10;
            isX = false;
            expectedResult = 80;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult, delta: actualResult / 1000000);
        }

        [TestMethod]
        public void WhenNegativeValue_ShouldReturnPositivePointValue()
        {
            LogTransformation logTrans = new LogTransformation();
            float Min = 0;
            float Max = 0;
            float Data = 0;
            double expectedResult = 0;
            double actualResult = 0;

            Min = -100;
            Max = -2;
            Data = -100;
            expectedResult = 262;
            actualResult = logTrans.ValueToLogGraph(false, Data, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            Min = -100;
            Max = -2;
            Data = -10;
            expectedResult = 171;
            actualResult = logTrans.ValueToLogGraph(false, Data, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            Min = -100;
            Max = -2;
            Data = -1;
            expectedResult = 80;
            actualResult = logTrans.ValueToLogGraph(false, Data, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            Min = -1235;
            Max = -5;
            Data = -1;
            expectedResult = 429;
            actualResult = logTrans.ValueToLogGraph(true, Data, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            Min = -1000;
            Max = 2990;
            Data = 1000;
            expectedResult = 385.375;
            actualResult = logTrans.ValueToLogGraph(true, Data, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            Min = -1000;
            Max = 2990;
            Data = -1000;
            expectedResult = 80;
            actualResult = logTrans.ValueToLogGraph(true, Data, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            Min = -1000;
            Max = 2990;
            Data = 10000;
            expectedResult = 429;
            actualResult = logTrans.ValueToLogGraph(true, Data, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);

            Min = -1000;
            Max = 2990;
            Data = 1;
            expectedResult = 254.5;
            actualResult = logTrans.ValueToLogGraph(true, Data, Min, Max);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void WhenMinMaxValue_ShouldReturnCount()
        {
            LogTransformation logTrans = new LogTransformation();
            double Min = 0;
            double Max = 0;
            int ExpectedResult = 0;
            int ActualResult = 0;

            Min = 0;
            Max = 1779;
            ExpectedResult = 5;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 0.1056422;
            Max = 1.09837;
            ExpectedResult = 3;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 0;
            Max = 154;
            ExpectedResult = 4;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -100;
            Max = -2;
            ExpectedResult = 3;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -200;
            Max = -1;
            ExpectedResult = 4;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -1235;
            Max = -5;
            ExpectedResult = 5;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -1000;
            Max = -5;
            ExpectedResult = 4;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -1000;
            Max = 2990;
            ExpectedResult = 9;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -998;
            Max = 3995;
            ExpectedResult = 9;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

        }
    }
}
