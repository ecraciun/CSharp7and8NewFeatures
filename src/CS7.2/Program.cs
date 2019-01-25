using System;

namespace CS7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[3] { 1, 2, 3 };
            int[] otherArr = null;
            ref var r = ref (arr != null ? ref arr[0] : ref otherArr[0]);
        }

        int binaryValue = 0b_0101_0101;

        private protected class Test
        {
            protected int a;
        }

        private protected class SimpleTest : Test
        {
            public void DoSomething()
            {
                a = 10;
            }
        }
    }
}