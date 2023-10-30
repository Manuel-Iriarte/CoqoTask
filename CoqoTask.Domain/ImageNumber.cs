using System.Text.RegularExpressions;

namespace CoqoTask.Domain
{
    public class ImageNumber
    {
        public decimal Value { get; set; }

        private static readonly Dictionary<char, int> RomanNumerals = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        public void RomanToDecimal(string roman)
        {
            if (!IsValidRomanNumeral(roman))
                throw new ArgumentException("Invalid Roman numeral character: " + roman);

            int result = 0;
            int prevValue = 0;

            for (int i = roman.Length - 1; i >= 0; i--)
            {
                char currentChar = roman[i];

                if (!RomanNumerals.ContainsKey(currentChar))
                    throw new ArgumentException("Invalid Roman numeral character: " + currentChar);

                int currentValue = RomanNumerals[currentChar];

                if (currentValue < prevValue)
                    result -= currentValue;
                else
                    result += currentValue;

                prevValue = currentValue;
            }

            Value = result;
        }

        public static bool IsValidRomanNumeral(string roman)
        {
            return Regex.IsMatch(roman, @"^(M{0,3})(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
        }
    }
}