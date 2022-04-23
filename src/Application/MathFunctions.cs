namespace Application
{
    public static class MathFunctions
    {
        public static bool IsPrime(int number)
        {
            if (number == 2) return true;
            if (number % 2 == 0 || number < 2) return false;

            var squareRoot = (int)Math.Sqrt(number);

            for (int divisor = 3; divisor <= squareRoot; divisor += 2)
            {
                if (number % divisor == 0)
                    return false;
            }

            return true;
        }

        public static IEnumerable<int> GetDivisors(int number)
        {
            if (number < 1)
                throw new ArgumentOutOfRangeException(nameof(number));

            var divisors = new List<int>();

            var squareRoot = (int)Math.Sqrt(number);

            for (int divisor = 1; divisor <= squareRoot; divisor++)
            {
                if (number % divisor == 0)
                {
                    if (number / divisor == divisor)
                    {
                        divisors.Add(divisor);
                    }
                    else
                    {
                        divisors.Add(number / divisor);
                        divisors.Add(divisor);
                    }
                }
            }

            divisors.Sort();
            return divisors;
        }
    }
}
