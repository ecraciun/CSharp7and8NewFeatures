using System;

namespace CS7._3
{
    class Program
    {
        static void Main(string[] args)
        {
            new D(1);

            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            Console.WriteLine(left == right); // displays 'true'

            left = (a: 5, b: 10);
            right = (a: 5, b: 10);
            (int a, int b)? nullableTuple = right;
            Console.WriteLine(left == nullableTuple); // Also true

            // lifted conversions
            left = (a: 5, b: 10);
            (int? a, int? b) nullableMembers = (5, 10);
            Console.WriteLine(left == nullableMembers); // Also true

            // converted type of left is (long, long)
            (long a, long b) longTuple = (5, 10);
            Console.WriteLine(left == longTuple); // Also true

            // comparisons performed on (long, long) tuples
            (long a, int b) longFirst = (5, 10);
            (int a, long b) longSecond = (5, 10);
            Console.WriteLine(longFirst == longSecond); // Also true

            (int a, string b) pair = (1, "Hello");
            (int z, string y) another = (1, "Hello");
            Console.WriteLine(pair == another); // true. Member names don't participate.
            Console.WriteLine(pair == (z: 1, y: "Hello")); // warning: literal contains different member names

            (int, (int, int)) nestedTuple = (1, (2, 3));
            Console.WriteLine(nestedTuple == (1, (2, 3)));
        }

        public class B
        {
            public B(int i, out int j)
            {
                j = i;
            }
        }

        public class D : B
        {
            public D(int i) : base(i, out var j)
            {
                Console.WriteLine($"The value of 'j' is {j}");
            }
        }

        static void Bla(int arg)
        {

        }
        static void Bla(in int arg)
        {

        }
    }
}