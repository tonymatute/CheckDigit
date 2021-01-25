using API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Data
{
    public class CheckDigitRepository : ICheckDigitRepository
    {
        public int calculateCheckDigit(long trackingNumber)
        {
            var trackingNumberArr = trackingNumberToArray(trackingNumber);

            var trackingNumberList = trackingNumberArr.Reverse();
            List<int> digits = new List<int>();


            for (int i = trackingNumberArr.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    splitDigits(digits, trackingNumberArr[i]);
                }
                else
                {
                    splitDigits(digits, 2 * trackingNumberArr[i]);
                }

            }

            var total = subTotalAdd(digits);
            var checkDigit = 10 - totalAdd(total);

            return checkDigit;
        }

        private void splitDigits(List<int> digits, int number)
        {
            if (0 == number)
            {
                digits.Add(0);
            }
            else
            {
                while (number != 0)
                {
                    int last = number % 10;
                    digits.Add(last);
                    number = (number - last) / 10;
                }
            }
        }

        private int totalAdd(int number)
        {
            var total = 0;
            while (number != 0)
            {
                int last = number % 10;
                total += last;
                number = (number - last) / 10;
            }

            if (total > 9)
            {
                total = totalAdd(total);
            }

            return total;
        }

        private int[] trackingNumberToArray(long trackingNumber)
        {
            int[] outArray = Array.ConvertAll(trackingNumber.ToString().ToArray(), x => (int)x - 48);

            return outArray;
        }

        private int subTotalAdd(List<int> digits)
        {
            var result = 0;
            foreach (var digit in digits)
            {
                result += digit;
            }

            return result;
        }
    }
}
