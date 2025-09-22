namespace CMS_BE.Application.Utils
{
    public class StringUtil
    {
        private static readonly Random _random = new Random();

        public static string GenerateCode(string prefix, int numberLength)
        {
            if (numberLength <= 0)
                throw new ArgumentException(
                    "Number length must be greater than 0",
                    nameof(numberLength)
                );

            int maxValue = (int)Math.Pow(10, numberLength) - 1;
            int minValue = (int)Math.Pow(10, numberLength - 1);

            int number = _random.Next(minValue, maxValue + 1);
            return $"{prefix}{number}".Trim();
        }

        public static string GenerateCode(int numberLength)
        {
            if (numberLength <= 0)
                throw new ArgumentException(
                    "Number length must be greater than 0",
                    nameof(numberLength)
                );
            if (numberLength > 18)
                throw new ArgumentException("Number length too large for long");

            long minValue = (long)Math.Pow(10, numberLength - 1);
            long maxValue = (long)Math.Pow(10, numberLength) - 1;

            long number = RandomLong(minValue, maxValue);
            return number.ToString();
        }

        private static long RandomLong(long min, long max)
        {
            return (long)(_random.NextDouble() * (max - min + 1)) + min;
        }
    }
}
