using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformation
{
    public class LogTransformation
    {
        public enum LogType
        {
            CommonLog, // 밑이 10인 로그, 상용 로그
            BinaryLog, // 밑이 2인 로그
            NatualLog // 밑이 e인 로그, 자연 로그
        }




        /// <summary>
        /// 숫자를 상용로그 값으로 바꾸는 함수
        /// </summary>
        /// <param name="input">입력한 숫자</param>
        /// <param name="min">입력한 숫자가 속한 범위의 최소값</param>
        /// <param name="max">입력한 숫자가 속한 범위의 최대값</param>
        /// <param name="logType">로그의 종류</param>
        /// <returns></returns>
        public float NumToLog(float input, float min, float max, LogType logType = LogType.CommonLog)
        {
            float result = float.NaN;

            if (input >= min && input <= max)
            {
                result = Convert.ToSingle(Math.Log10(input));
            }

            if (input < 0)
            {
                result = Convert.ToSingle(Math.Log10(Math.Abs(input)) * (-1));
            }

            // 무한대 값 처리
            if (float.IsInfinity(result))
            {
                result = float.NaN;
            }

            return result;
        }




        /// <summary>
        /// 상용로그 값을 숫자로 바꾸는 함수
        /// </summary>
        /// <param name="input">입력한 로그 값</param>
        /// <param name="min">입력한 로그 값이 속한 범위의 최소값</param>
        /// <param name="max">입력한 로그 값이 속한 범위의 최대값</param>
        /// <param name="isPreviousNumberNegative">입력한 로그 값으로 바꾼 숫자가 음수인지의 여부</param>
        /// <param name="logType">입력한 로그 값의 로그 종류</param>
        /// <returns></returns>
        public float LogToNum(float input, float min, float max, LogType logType = LogType.CommonLog)
        {
            float result = float.NaN;

            if (input > 0)
            {
                result = Convert.ToSingle(Math.Pow(10, input));
            }
            else
            {
                if (input > max || input > min)
                {
                    result = Convert.ToSingle(Math.Pow(10, Math.Abs(input))) * (-1);
                }
                else if (input < min || input < max)
                {
                    result = Convert.ToSingle(Math.Pow(10, input));
                }
            }

            return result;
        }

        public double ValueToLogGraph(bool isX, float Data, float Min, float Max)
        {
            double Pos = 0; // 그래프 상 위치
            double Data_Log = 0; // 데이터를 로그로 변환한 값과 최소값을 로그로 변환한 값의 비율
            double LogValue = 0; // 입력값을 로그로 변환한 값
            double RealMinLogValue = 0; // 실제 최소 로그 값
            double Rate_Log = 0; // 최대값의 로그 값과 최소값의 로그 값의 비율 
            double LogBase = 10; // 로그의 밑
            double GraphWidth = 349; // 그래프의 너비
            double GraphHeight = 182; // 그래프의 높이
            PointF GraphZeroPoint = new PointF(80, 262); // 그래프 원점의 좌표
            int ZeroSpace = 20; // 값이 0인 경우 1을 넣을 공간
            int RulerCount = 3;
            double RealMinData_Plus = Math.Round((Max * Math.Pow(0.1, RulerCount)), 6); // 실제 +로그의 최소값

            if (Min == 0 && Max > 0)
            {
                if (Min == 0)
                {
                    Min = 1;
                }
                LogValue = Math.Log(Data, LogBase);
                Data_Log = LogValue;
                RealMinLogValue = Math.Log(Math.Pow(Max, -3));
                Rate_Log = Math.Ceiling(Math.Log(Max, LogBase));

                if (isX)
                {
                    if (Data > 1)
                    {
                        Pos = Data_Log / Rate_Log * (GraphWidth - ZeroSpace) + GraphZeroPoint.X + ZeroSpace;
                    }

                    else
                    {
                        Pos = GraphZeroPoint.X + Data * ZeroSpace;
                    }
                }
                else
                {
                    if (Data == 1)
                    {
                        Pos = GraphZeroPoint.Y - ZeroSpace;
                    }

                    else if (Max == 1)
                    {
                        Pos = GraphZeroPoint.Y - GraphHeight;
                    }
                    else if (Min < 1 && Max > 1)
                    {
                        Pos = GraphZeroPoint.Y - Data * ZeroSpace;
                    }

                    else
                    {
                        Pos = GraphZeroPoint.Y - ZeroSpace - (((GraphHeight - ZeroSpace) * (Data_Log / Rate_Log)));
                    }
                }
            }

            if (Min > 0 && Max > 0)
            {
                LogValue = Math.Log(Data, LogBase);
                Data_Log = LogValue;
                RealMinLogValue = Math.Log(Math.Pow(Max, -3));
                Rate_Log = Math.Ceiling(Math.Log(Max, LogBase));

                if (isX)
                {
                    if (Data > 1)
                    {
                        Pos = Data_Log / Rate_Log * (GraphWidth - ZeroSpace) + GraphZeroPoint.X + ZeroSpace;
                    }

                    else if (Max < 1)
                    {
                        Pos = 80;
                    }

                    else
                    {
                        Pos = GraphZeroPoint.X + Data * ZeroSpace;
                    }
                }
                else
                {
                    if (Data == 1)
                    {
                        Pos = GraphZeroPoint.Y - ZeroSpace;
                    }

                    else if (Max == 1)
                    {
                        Pos = GraphZeroPoint.Y - GraphHeight;
                    }
                    else if (Min < 1 && Max > 1)
                    {
                        if (Data > Min && Data < Max)
                        {
                            Pos = GraphZeroPoint.Y - Data * ZeroSpace;
                        }
                        else
                        {
                            Pos = GraphZeroPoint.Y - ZeroSpace - (GraphHeight - ZeroSpace) * Data_Log / Rate_Log;
                        }
                    }

                    else if (Min > 1 && Max > 1)
                    {
                        Pos = GraphZeroPoint.Y - ZeroSpace - (((GraphHeight - ZeroSpace) * (Data_Log / Rate_Log)));
                    }
                }
            }

            if (Min < 0 && Max < 0)
            {
                if (isX)
                {
                    if (Data > Max)
                    {
                        Pos = GraphZeroPoint.X + GraphWidth;
                    }

                }
                else
                {
                    if ((Data == Min))
                    {
                        Pos = GraphZeroPoint.Y;
                    }
                    else if (Data == Max || (Data > Max))
                    {
                        Pos = GraphZeroPoint.Y - GraphHeight;
                    }
                    else
                    {
                        LogValue = Math.Log(Math.Abs(Data), LogBase);
                        Data_Log = LogValue;
                        Rate_Log = Math.Ceiling(Math.Log(Math.Abs(Min), LogBase));
                        Pos = GraphZeroPoint.Y - GraphHeight * Data_Log / Rate_Log;
                    }
                }

            }

            if (Min < 0 && Max > 0)
            {
                if (isX)
                {
                    Rate_Log = Math.Ceiling(Math.Log(Math.Abs(Max), LogBase))
                        + Math.Ceiling(Math.Log(Math.Abs(Min), LogBase));
                    Data_Log = Math.Log(Math.Abs(Data), LogBase) + Math.Ceiling(Math.Log(Math.Abs(Min), LogBase));

                    if (Data > 0 && Data < Max)
                    {
                        Pos = GraphZeroPoint.X + GraphWidth * ((Data_Log + 1) / (Rate_Log + 1));
                    }

                    else if (Data == Min)
                    {
                        Pos = GraphZeroPoint.X;
                    }

                    else if (Math.Log(Math.Abs(Data), LogBase) == Math.Ceiling(Math.Log(Math.Abs(Max), LogBase)))
                    {
                        Pos = GraphZeroPoint.X + GraphWidth;
                    }
                }

            }

            return Pos;
        }

        public int GetCount(double Min, double Max)
        {
            int Count = 0; // 눈금의 개수
            double MinLogVal = 0; // 최소값의 로그값
            double MaxLogVal = 0; // 최대값의 로그값
            double LogBase = 10;

            if (Min == 0 && Max > 0)
            {
                // 최소값의 로그값을 구한다.
                if (Min >= 1)
                {
                    MinLogVal = Math.Floor(Math.Log(Math.Abs(Min), LogBase));
                }

                // 최대값의 로그값을 구한다.
                if (Max >= 1)
                {
                    MaxLogVal = Math.Ceiling(Math.Log(Math.Abs(Max), LogBase));
                }

                // 눈금의 개수를 구한다.
                Count = Convert.ToInt16(MaxLogVal - MinLogVal) + 1;

            }

            else if (Min > 0 && Max > 0)
            {
                // 최대값의 로그값을 구한다.
                MaxLogVal = Math.Ceiling(Math.Abs(Math.Log(Max, LogBase)));

                // 최소값의 로그값을 구한다.
                MinLogVal = Math.Floor(Math.Abs(Math.Log(Min, LogBase)));

                if (Max > 1)
                {
                    // 눈금의 개수를 구한다.
                    Count = Convert.ToInt16(MaxLogVal - MinLogVal) + 1;
                }
                else if (Min > 0 && Min < 1)
                {
                    // 최대값의 로그값을 구한다.
                    MaxLogVal = Math.Ceiling(Math.Abs(Math.Log(Min, LogBase)));

                    // 최소값의 로그값을 구한다.
                    MinLogVal = Math.Floor(Math.Abs(Math.Log(Max, LogBase)));

                    // 눈금의 개수를 구한다.
                    Count = Convert.ToInt16(MaxLogVal - MinLogVal) + 1;
                }

            }

            else if (Min < 0 && Max < 0)
            {
                // 최대값의 로그값을 구한다.
                MaxLogVal = Math.Floor(Math.Log(Math.Abs(Max), LogBase));

                // 최소값의 로그값을 구한다. 
                MinLogVal = Math.Ceiling(Math.Log(Math.Abs(Min), LogBase));

                // 눈금의 개수를 구한다.
                Count = Convert.ToInt16(MinLogVal - MaxLogVal) + 1;
            }

            else if (Min < 0 && Max > 0)
            {
                // 최대값의 로그값을 구한다.
                MaxLogVal = Math.Ceiling(Math.Log(Math.Abs(Max), LogBase));

                // 최소값의 로그값을 구한다. 
                MinLogVal = Math.Ceiling(Math.Log(Math.Abs(Min), LogBase));

                // 눈금의 개수를 구한다.
                Count = Convert.ToInt16(MinLogVal + MaxLogVal) + 2;
            }

            return Count;
        }

        public double LogGraphToValue(bool isX, double PointValue, float Min, float Max)
        {
            double Value = double.NaN; // 로그 값을 상수로 변환한 값
            double GraphWidth = 349; // 그래프의 너비
            double GraphHeight = 182; // 그래프의 높이
            PointF GraphZeroPoint = new PointF(80, 262); // 그래프 원점의 좌표
            double LogBase = 10; // 로그의 밑
            double power = 0; // 지수
            double MinLogValue = 0; // 최소값의 로그값
            double MaxLogValue = 0; // 최대값의 로그값
            double CurrentPoint = 0; // 현재까지 이동한 좌표
            double RulerCount = 0; // 눈금의 개수
            double Gap = 0; // 눈금의 숫자 간격
            int i = 0; // 반복제어변수
            int j = 0; // 반복제어변수

            if (isX)
            {
                if (Min >= 0 && Max > 0)
                {
                    Value = 0;

                    if (Min > 0)
                    {
                        MaxLogValue = Math.Ceiling(Math.Log(Max, LogBase)) - Math.Floor(Math.Log(Min, LogBase));
                    }
                    else
                    {
                        MaxLogValue = Math.Ceiling(Math.Log(Max, LogBase));
                    }

                    RulerCount = MaxLogValue + 1;

                    CurrentPoint = 80 + GraphWidth / RulerCount; // x축에 있는 눈금 1의 좌표

                    if (PointValue != GraphZeroPoint.X)
                    {
                        // 눈금의 숫자값 초기화
                        Value = 1;

                        while (CurrentPoint < PointValue)
                        {
                            Gap = Math.Pow(LogBase, i + 1) - Math.Pow(LogBase, i);

                            j = 0;

                            while (j < Gap)
                            {
                                CurrentPoint += (GraphWidth / RulerCount) / Gap;

                                Value += 1;

                                j++;
                            }

                            i++;
                        }
                    }
                }

                else if (Min < 0 && Max <= 0)
                {

                    if (Max < 0)
                    {
                        MaxLogValue = Math.Ceiling(Math.Log(Math.Abs(Min), LogBase)) 
                            - Math.Floor(Math.Log(Math.Abs(Max), LogBase));
                    }
                    else
                    {
                        MaxLogValue = Math.Ceiling(Math.Log(Math.Abs(Min), LogBase));
                    }

                    Value = Math.Pow(LogBase, MaxLogValue) * (-1);

                    RulerCount = MaxLogValue + 1;

                    CurrentPoint = 80 + GraphWidth / RulerCount; // x축에 있는 눈금 1의 좌표

                    if (PointValue != GraphZeroPoint.X)
                    {
                        while (CurrentPoint < PointValue)
                        {
                            Gap = Math.Pow(LogBase, MaxLogValue - i) - Math.Pow(LogBase, MaxLogValue - (i + 1));

                            j = 0;

                            while (j < Gap)
                            {
                                CurrentPoint += (GraphWidth / RulerCount) / Gap;

                                Value += 1;

                                j++;
                            }

                            i++;
                        }
                    }
                }
            }
            else
            {
                if (Min >= 0 && Max > 0)
                {
                    Value = 0;

                    if(Min > 0)
                    {
                        MaxLogValue = Math.Ceiling(Math.Log(Max, LogBase)) - Math.Floor(Math.Log(Min,LogBase));
                    }
                    else
                    {
                        MaxLogValue = Math.Ceiling(Math.Log(Max, LogBase));
                    }

                    RulerCount = MaxLogValue + 1;

                    CurrentPoint = GraphZeroPoint.Y - 1 - GraphHeight / RulerCount; // y축에 있는 눈금 1의 좌표

                    if (PointValue != GraphZeroPoint.Y)
                    {
                        // 눈금의 숫자값 초기화
                        Value = 1;

                        while (CurrentPoint > PointValue)
                        {
                            Gap = Math.Pow(LogBase, i + 1) - Math.Pow(LogBase, i);

                            j = 0;

                            while (j < Gap)
                            {
                                CurrentPoint -= (GraphHeight / RulerCount) / Gap;

                                Value += 1;

                                j++;
                            }

                            i++;
                        }
                    }
                }

                else if (Min < 0 && Max <= 0)
                {
                    if (Max < 0)
                    {
                        MaxLogValue = Math.Ceiling(Math.Log(Math.Abs(Min), LogBase))
                            - Math.Floor(Math.Log(Math.Abs(Max), LogBase));
                    }
                    else
                    {
                        MaxLogValue = Math.Ceiling(Math.Log(Math.Abs(Min), LogBase));
                    }

                    Value = Math.Pow(LogBase, MaxLogValue) * (-1);

                    RulerCount = MaxLogValue + 1;

                    CurrentPoint = GraphZeroPoint.Y - 1 - GraphHeight / RulerCount; // y축에 있는 눈금 1의 좌표

                    if (PointValue != GraphZeroPoint.Y)
                    {
                        while (CurrentPoint > PointValue)
                        {
                            Gap = Math.Pow(LogBase, MaxLogValue - i) - Math.Pow(LogBase, MaxLogValue - (i + 1));

                            j = 0;

                            while (j < Gap)
                            {
                                CurrentPoint -= (GraphHeight / RulerCount) / Gap;

                                Value += 1;

                                j++;
                            }

                            i++;
                        }
                    }
                }
            }

            return Value;
        }
    }
}
