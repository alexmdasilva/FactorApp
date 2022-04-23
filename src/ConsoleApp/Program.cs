using Application;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("Write a natural number other than zero: ");

                var input = Console.ReadLine();

                Console.Clear();

                bool success = int.TryParse(input, out int inputNumber);

                if (!success)
                {
                    Console.WriteLine($"Couldn't convert {input} to a number. \nPress any key to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                if (inputNumber <= 0)
                {
                    Console.WriteLine($"Invalid number.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                var divisors = MathFunctions.GetDivisors(inputNumber);
                var primeDivisors = divisors.Where(number => MathFunctions.IsPrime(number));

                Console.Write($"Divisors of {inputNumber}: ");
                PrintIntegerCollection(divisors);

                Console.Write($"Prime divisors of {inputNumber}: ");
                PrintIntegerCollection(primeDivisors);

                Console.WriteLine("\nPress any key to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void PrintIntegerCollection(IEnumerable<int> numberCollection)
        {
            if (!numberCollection.Any())
            {
                Console.Write("None\n");
                return;
            }

            foreach (var number in numberCollection)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
