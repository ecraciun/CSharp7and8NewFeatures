using System;
using System.Threading.Tasks;

namespace CS7._1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await DoSomeAsyncStuff();
        }

        private static async Task DoSomeAsyncStuff()
        {
            await Task.Delay(1000);
            Console.WriteLine("Async stuff completed");
        }

        #region Default literal expressions

        // before
        Func<string, bool> whereClause = default(Func<string, bool>);

        // after
        Func<string, bool> whereClauseNew = default;

        #endregion

        #region Inferred tuple element names

        private static void InferredTupleElementNames()
        {
            int count = 5;
            string label = "Hello";
            var pair = (count: count, label: label);

            var newPair = (count, label); // element names are "count" and "label"
            newPair.count = 10;
        }


        #endregion
    }
}
