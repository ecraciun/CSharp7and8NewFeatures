using System;

namespace CS7._0
{
    class Program
    {
        static void Main(string[] args)
        {
            OutVariables();

            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }

        #region Out Variables

        private static void OutVariables()
        {
            var first = 5;
            var second = 2;

            // Example 1
            Console.WriteLine($"{first} divided by {second} is: ");
            var divideResult = DivideNumbers(first, second, out int remainder);
            Console.WriteLine($"{divideResult} with a remainder of {remainder}");

            // Example 2
            Console.WriteLine("Give me a number");
            var input = Console.ReadLine();
            if(int.TryParse(input, out int value))
            {
                var message = value % 2 == 0 ? "even" : "odd";
                Console.WriteLine($"The number is {message}");
            }
            else
            {
                Console.WriteLine("Hey, I said give me a number!");
            }
        }

        private static int DivideNumbers(int first, int second, out int remainder)
        {
            var result = first / second;
            remainder = first - (second * result);
            return result;
        }

        #endregion

        #region Tuples

        private static void Tuples()
        {
            // Make sure to add the System.ValueTuple nuget package to use this 

            var unnamed = ("Joe", "has", 3, "apples");
            unnamed.Item3 = 6;

            (string FirstName, string LastName) fullName = ("Doe", "John");
            Console.WriteLine($"Hi, I'm {fullName.FirstName} {fullName.LastName}");

            var car = (Model: "i3", Make: "BMW");
            car.Model = "i8"; // I just won the lottery so I can upgrade it

            var result = DivideNumbers(5, 2);
            Console.WriteLine($"{result.Result} {result.Remainder}");

            // Deconstructing
            (int c, int r) = DivideNumbers(17, 5);

            var rectangle = new Rectangle(2, 4);
            (int length, int height) = rectangle;
        }

        private static (int Result, int Remainder) DivideNumbers(int first, int second)
        {
            var result = first / second;
            var remainder = first - (second * result);
            return (result, remainder);
        }

        internal class Rectangle
        {
            public int L { get; }
            public int H { get; }

            public Rectangle(int l, int h)
            {
                L = l;
                H = h;
            }

            public void Deconstruct(out int l, out int h)
            {
                h = H;
                l = L;
            }
        }

        #endregion
    }
}