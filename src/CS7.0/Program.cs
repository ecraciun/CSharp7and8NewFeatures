using System;
using System.Threading.Tasks;

namespace CS7._0
{
    class Program
    {
        static void Main(string[] args)
        {
            OutVariables();

            Tuples();

            Discards();

            PatternMatching();

            ThrowExpressions();

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
            public int Area
            {
                get
                {
                    return L * H;
                }
            }

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

            public (int Length, int Height, int Area) GetRectangleInfo1()
            {
                return (L, H, Area);
            }

            public void GetRectangleInfo2(out int Length, out int Height, out int RectangleArea)
            {
                Length = L;
                RectangleArea = Area;
                Height = H;
            }
        }

        #endregion

        #region Discards

        private static void Discards()
        {
            // Deconstruction
            var r = new Rectangle(5, 10);
            var (_, _, area) = r.GetRectangleInfo1();
            (int length, _) = r;

            // Out variables
            r.GetRectangleInfo2(out _, out _, out var a);

            // Standalone
            _ = Task.Run(() =>
           {
               Console.WriteLine("Hello from a task");
           });

            IsItARectangle(r);
            IsItARectangle(null);
            IsItARectangle(2);
        }

        private static void IsItARectangle(object obj)
        {
            if(obj is Rectangle)
            {
                Console.WriteLine("Yup");
            }
            else if (obj is null)
            {
                Console.WriteLine("It's null");
            }
            else
            {
                Console.WriteLine("Idk what it is, but it's not null");
            }
        }

        #endregion

        #region Pattern matching

        private static void PatternMatching()
        {

        }

        #endregion

        #region Ref locals and returns



        #endregion

        #region Local functions



        #endregion

        #region More expression-bodied members



        #endregion

        #region Throw expressions

        private static void ThrowExpressions()
        {
            var result = GiveMeSomethingRandom() ?? throw new ArgumentNullException("Well it's not exactly an argument, but you get it");
        }

        private static object GiveMeSomethingRandom()
        {
            Random r = new Random();
            var shouldReturnNull = r.Next(100) % 2 == 0 ? true : false;
            return shouldReturnNull ? null : new object();
        }

        #endregion

        #region Generalized async return types



        #endregion

        #region Numeric literal syntax improvements

        public const int One = 0b0001;

        public const int Sixteen = 0b0001_0000;

        public const long BillionsAndBillions = 100_000_000_000;

        public const double AvogadroConstant = 6.022_140_857_747_474e23;

        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;

        #endregion
    }
}