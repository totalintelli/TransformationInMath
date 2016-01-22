using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transformation;
namespace TransformationTest
{
    [TestClass]
    public class TransformationTest
    {

        /*
        함수 이름 : WhenPositiveNumber_ShouldReturnValue
        기    능 : 입력한 값이 양수인 경우 양수 로그 값으로 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 입력한 값이 양수인 경우 양수 로그 값으로 출력하는지 테스트
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
        #endregion



        /*
        함수 이름 : WhenMiniPositiveNumber_ShouldReturnMinusNumber
        기    능 : 입력한 값이 0과 1사이의 수인 경우 음수 로그 값으로 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 입력한 값이 0과 1사이의 수인 경우 음수 로그 값으로 출력하는지 테스트
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
        #endregion



        /*
        함수 이름 : WhenNegativeNumber_ShouldReturnMinusNumber
        기    능 : 입력한 값이 음수인 경우 음수 로그 값으로 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 입력한 값이 음수인 경우 음수 로그 값으로 출력하는지 테스트
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
        #endregion



        /*
        함수 이름 : WhenZero_ShouldReturnNaN
        기    능 : 입력한 값이 0인 경우 로그 값으로 나타낼 수 없다고 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        # region 입력한 값이 0인 경우 로그 값으로 나타낼 수 없다고 출력하는지 테스트
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
        #endregion



        /*
        함수 이름 : WhenOutOfRangeNumber_ShouldReturnNaN
        기    능 : 입력한 실수 값이 범위에서 벗어났을 경우 로그 값으로 나타낼 수 없다고 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 입력한 실수 값이 범위에서 벗어났을 경우 로그 값으로 나타낼 수 없다고 출력하는지 테스트
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
        #endregion



        /*
        함수 이름 : WhenPositiveLogVaule_ShouldReturnMinusValue
        기    능 : 양수 로그 값이 입력될 경우 로그 값에 해당하는 실수 값을 올바르게 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 양수 로그 값이 입력될 경우 로그 값에 해당하는 실수 값을 올바르게 출력하는지 테스트
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
        #endregion



        /*
        함수 이름 : WhenNegativeLogValue_ShouldReturnMinusValue
        기    능 : 음수 로그 값이 입력될 경우 로그 값에 해당하는 실수 값을 올바르게 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 음수 로그 값이 입력될 경우 로그 값에 해당하는 실수 값을 올바르게 출력하는지 테스트
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
        #endregion



        /*
        함수 이름 : WhenPositiveValue_ShouldReturnPositivePointValue
        기    능 : 양수 데이터가 들어올 경우 그 데이터의 그래프 상의 위치를 올바르게 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 양수 데이터가 들어올 경우 그 데이터의 그래프 상의 위치를 올바르게 출력하는지 테스트
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

            Min = 0.1030832976102829f;
            Max = 1.0994292497634888f;
            Value = 1;
            isX = false;
            expectedResult = 242;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult, delta: actualResult / 1000000);

            Min = 0.00585543f;
            Max = 0.9957746f;
            Value = 0.001f;
            isX = true;
            expectedResult = 80;
            actualResult = logTrans.ValueToLogGraph(isX, Value, Min, Max);
            Assert.AreEqual(expectedResult, actualResult, delta: actualResult / 1000000);
        }
        #endregion



        /*
        함수 이름 : WhenNegativeValue_ShouldReturnPositivePointValue
        기    능 : 음수 데이터가 들어올 경우 그 데이터의 그래프 상의 위치를 올바르게 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 음수 데이터가 들어올 경우 그 데이터의 그래프 상의 위치를 올바르게 출력하는지 테스트
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
        #endregion



        /*
        함수 이름 : WhenMinMaxValue_ShouldReturnCount
        기    능 : 최대값과 최소값을 입력받을 경우 눈금의 개수를 올바르게 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 최대값과 최소값을 입력받을 경우 눈금의 개수를 올바르게 출력하는지 테스트
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
            ExpectedResult = 2;
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


            Min = 0.1030832976102829f;
            Max = 1.0994292497634888f;
            ExpectedResult = 2;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 1;
            Max = 99;
            ExpectedResult = 3;
            ActualResult = logTrans.GetCount(Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        #endregion

        /*
        함수 이름 : WhenPositiveLogValue_ShouldReturnPositiveValue
        기    능 : 양의 마우스 좌표 값을 입력받으면 양의 실수를 올바르게 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 양의 마우스 좌표 값을 입력받으면 양의 실수를 올바르게 출력하는지 테스트
        [TestMethod]
        public void WhenPositiveLogValue_ShouldReturnPositiveValue()
        {
            double PointValue = 0;
            float Min = 0;
            float Max = 0;
            double ExpectedResult = 0;
            double ActualResult = 0;
            bool isX = true;
            LogTransformation logTrans = new LogTransformation();

            Min = 0;
            Max = 43.78f;
            PointValue = 80;
            ExpectedResult = 0;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 0;
            Max = 43.78f;
            PointValue = 196.333;
            ExpectedResult = 1;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult, delta: ActualResult / 10);

            Min = 0;
            Max = 43.78f;
            PointValue = 312.666;
            ExpectedResult = 10;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 0;
            Max = 43.78f;
            PointValue = 429;
            ExpectedResult = 100;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 0;
            Max = 154;
            PointValue = 262;
            ExpectedResult = 0;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 0;
            Max = 154;
            PointValue = 216.5;
            ExpectedResult = 1;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 0;
            Max = 154;
            PointValue = 171;
            ExpectedResult = 10;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 0;
            Max = 154;
            PointValue = 125.5;
            ExpectedResult = 100;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 0;
            Max = 154;
            PointValue = 80;
            ExpectedResult = 1000;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = 1;
            Max = 154;
            PointValue = 80;
            ExpectedResult = 1000;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        #endregion



        /*
        함수 이름 : WhenPositiveLogValue_ShouldReturnNagativeValue
        기    능 : 양의 마우스 좌표 값을 입력받으면 양의 실수를 올바르게 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 양의 마우스 좌표 값을 입력받으면 음의 실수를 올바르게 출력하는지 테스트
        [TestMethod]
        public void WhenPositiveLogValue_ShouldReturnNagativeValue()
        {
            LogTransformation logTrans = new LogTransformation();
            float Min = 0;
            float Max = 0;
            double PointValue = 0;
            double ExpectedResult = 0;
            double ActualResult = 0;
            bool isX = true;

            Min = -1000;
            Max = -5;
            PointValue = 80;
            ExpectedResult = -1000;
            isX = true;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -1000;
            Max = -5;
            PointValue = 196.333;
            ExpectedResult = -100;
            isX = true;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -1000;
            Max = -5;
            PointValue = 312.666;
            ExpectedResult = -10;
            isX = true;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -1000;
            Max = -5;
            PointValue = 428.999;
            ExpectedResult = -1;
            isX = true;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -200;
            Max = -3;
            PointValue = 262;
            ExpectedResult = -1000;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -200;
            Max = -3;
            PointValue = 201.333;
            ExpectedResult = -100;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -200;
            Max = -3;
            PointValue = 140.666;
            ExpectedResult = -10;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -200;
            Max = -3;
            PointValue = 80;
            ExpectedResult = -1;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -200;
            Max = 0;
            PointValue = 80;
            ExpectedResult = -1;
            isX = false;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        #endregion

        /*
        함수 이름 : WhenPositiveLogValue_ShouldReturnPositveValueOrNagativeValue
        기    능 : 양의 마우스 좌표 값을 입력받으면 양의 실수나 음의 실수를 올바르게 출력하는지 테스트한다.
        입    력 : 없음
        출    력 : 없음
        */
        #region 양의 마우스 좌표 값을 입력받으면 양의 실수나 음의 실수를 올바르게 출력하는지 테스트
        [TestMethod]
        public void WhenPositiveLogValue_ShouldReturnPositveValueOrNagativeValue()
        {
            LogTransformation logTrans = new LogTransformation();
            float Min = 0;
            float Max = 0;
            double PointValue = 0;
            bool isX;
            double ExpectedResult = 0;
            double ActualResult = 0;

            Min = -1000;
            Max = 2990;
            PointValue = 80;
            isX = true;
            ExpectedResult = -1000;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -1000;
            Max = 2990;
            PointValue = 80;
            isX = true;
            ExpectedResult = -1000;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -1000;
            Max = 2990;
            PointValue = 123.625;
            isX = true;
            ExpectedResult = -100;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -1000;
            Max = 2990;
            PointValue = 167.25;
            isX = true;
            ExpectedResult = -10;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            Min = -1000;
            Max = 2990;
            PointValue = 210.875;
            isX = true;
            ExpectedResult = -1;
            ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            Assert.AreEqual(ExpectedResult, ActualResult);

            //Min = -1000;
            //Max = 2990;
            //PointValue = 254.5;
            //isX = true;
            //ExpectedResult = 1;
            //ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            //Assert.AreEqual(ExpectedResult, ActualResult);

            //Min = -1000;
            //Max = 2990;
            //PointValue = 298.125;
            //isX = true;
            //ExpectedResult = 10;
            //ActualResult = logTrans.LogGraphToValue(isX, PointValue, Min, Max);
            //Assert.AreEqual(ExpectedResult, ActualResult);

        }
        #endregion
    }
}
