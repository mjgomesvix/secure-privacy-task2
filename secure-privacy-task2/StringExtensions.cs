using System;
using System.Collections.Generic;
using System.Linq;

namespace secure_privacy_task2
{
    public static class StringExtensions
    {
        public static bool ValidateBinaryString(this string binaryString)
        {
            if(string.IsNullOrEmpty(binaryString))
                throw new InvalidBinaryStringException("Binary String is null or empty");

            var binaryStringList = binaryString.ToCharArray().ToList();

            if (binaryStringList.Any(b => b != '0' && b != '1'))
                throw new InvalidBinaryStringException("Binary String contains invalid characters");

            if (binaryStringList.Count(b => b == '0') != binaryStringList.Count(b => b == '1'))
                throw new InvalidBinaryStringException("Binary String with 0's quantity different of 1's quantity");

            static bool zerosQuantityIsSmallerOrEqualsThanOnesQuantityInPrefix(List<char> prefix) => prefix.Count(b => b == '0') <= prefix.Count(b => b == '1');

            var prefix = new List<char>();

            foreach (var bit in binaryStringList)
            {
                prefix.Add(bit);

                if(!zerosQuantityIsSmallerOrEqualsThanOnesQuantityInPrefix(prefix))
                    throw new InvalidBinaryStringException("Binary String contains invalid prefix");
            }

            return true;
        }
    }

#pragma warning disable RCS1194 // Implement exception constructors.
    public class InvalidBinaryStringException : Exception
#pragma warning restore RCS1194 // Implement exception constructors.
    {
        public InvalidBinaryStringException(string message = "Invalid Binary String")
            : base(message)
        {
        }
    }
}