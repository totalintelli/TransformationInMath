using System;
using System.Collections.Generic;
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
        /// 숫자를 십진 로그 값으로 바꾸는 함수
        /// </summary>
        /// <param name="input">입력한 숫자</param>
        /// <param name="min">입력한 숫자가 속한 범위의 최소값</param>
        /// <param name="max">입력한 숫자가 속한 범위의 최대값</param>
        /// <param name="logType">로그의 종류</param>
        /// <returns></returns>
        public float NumToLog(float input, float min, float max, LogType logType = LogType.CommonLog)
        {
            float result = 0;

            if (input >= min && input <= max)
            {
                result = Convert.ToSingle(Math.Log10(input));
            }

            if(float.IsInfinity(result) || input < min || input > max || input == 0)
            {
                result = float.NaN;
            }

            if(input < 0)
            {
                result = Convert.ToSingle(Math.Log10(Math.Abs(input)) * (-1));
            }

            return result;
        }




        /// <summary>
        /// 십진 로그 값을 숫자로 바꾸는 함수
        /// </summary>
        /// <param name="input">입력한 로그 값</param>
        /// <param name="min">입력한 로그 값이 속한 범위의 최소값</param>
        /// <param name="max">입력한 로그 값이 속한 범위의 최대값</param>
        /// <param name="isPreviousNumberNegative">입력한 로그 값으로 바꾼 숫자가 음수인지의 여부</param>
        /// <param name="logType">입력한 로그 값의 로그 종류</param>
        /// <returns></returns>
        public float LogToNum(float input, float min, float max, bool isPreviousNumberNegative, LogType logType = LogType.CommonLog)
        {
            float result = 0;

            if(input > 0)
            {
                result = Convert.ToSingle(Math.Pow(10, Convert.ToDouble(input)));
            }
            else
            {
                if(isPreviousNumberNegative == true)
                {
                    result = Convert.ToSingle(Math.Pow(10, Convert.ToDouble(Math.Abs(input))) * (-1));
                }
                else
                {
                    result = Convert.ToSingle(Math.Pow(10, Convert.ToDouble(input)));
                }
                
            }

            return result;
        }
    }
}
