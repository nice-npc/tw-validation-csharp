using System;
using System.Linq;

namespace TwValidationCsharp
{
    public class IDNumber
    {
        static string letters = "ABCDEFGHJKLMNPQRSTUVXYWZIO";

        /// <summary>
        /// Validate Taiwan ID Number Is Real or Fake.
        /// </summary>
        /// <param name="idNumber">Taiwan ID Number.</param>
        /// <returns>true is real, otherwise is Fake.</returns>
        public static bool ValidateIDNumber(string idNumber)
        {
            // 驗證身分證號碼格式
            // 開頭1是男生，2是女生
            if (idNumber.Length != 10 || !char.IsLetter(idNumber[0]) || (idNumber[1] != '1' && idNumber[1] != '2') || !idNumber.Substring(2).All(char.IsDigit))
            {
                return false;
            }

            // 計算驗證碼
            // 第一個字母轉換成數字 + 10
            int letterValue = letters.IndexOf(idNumber[0]) + 10;

            // 第二個要乘以 9 - i的數字並相加，直到第九碼
            int sum = letterValue / 10 + (letterValue % 10) * 9;

            for (int i = 1; i < 9; i++)
            {
                sum += (idNumber[i] - '0') * (9 - i);   
            }

            // 取得驗證碼
            int checkDigit = (10 - sum % 10) % 10;

            // 跟第九碼: 驗證碼比對
            int lastChar = idNumber[9] - '0';
            return checkDigit == lastChar;
        }
    }
}
