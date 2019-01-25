using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CS8._0
{
    class Program
    {
        //#nullable enable
        static async Task Main(string[] args)
        {
            string s = null;
            // Console.WriteLine($"This will generate a warning {s[0]}");

            string? s2 = null; // this is ok

            // RangesAndIndices();

            // await AsyncStreams();

            // RecursivePatterns();

            SwitchExpressions();
        }

        #region Ranges and indices

        private static void RangesAndIndices()
        {
            foreach (var name in GetNames())
            {
                Console.WriteLine(name);
            }
        }

        static IEnumerable<string> GetNames()
        {
            string[] names =
            {
                "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato"
            };

            //Range range = 1..4;
            //foreach (var name in names[range])

            //foreach (var name in names[1..^1])

            foreach (var name in names[1..4])
            {
                yield return name;
            }
        }

        #endregion

        #region Asynchronous streams

        //private static async Task AsyncStreams()
        //{
        //    await foreach(var name in GetNamesAsync())
        //    {
        //        Console.WriteLine($"Async name: {name}");
        //    }
        //}

        // Must wait for .NET Core 3.0 Preview 2 to get the compiler in sync with the interface in the framework
        //private async static IAsyncEnumerable<string> GetNamesAsync()
        //{
        //    string[] names =
        //    {
        //        "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato"
        //    };

        //    foreach(var name in names[0..^0])
        //    {
        //        await Task.Delay(500);
        //        yield return name;
        //    }
        //} 

        #endregion 

        #region Default implementations of interface members

        //interface ILogger
        //{
        //    void Log(int level, string message);
        //    void Log(Exception ex) => Log(0, ex.ToString()); // New overload
        //}

        #endregion

        #region Recursive patterns

        private static void RecursivePatterns()
        {
            var people = new List<Student>
            {
                new Student
                {
                    Graduated = true,
                    Name = "Jane"
                },
                new Student
                {
                    Graduated = false,
                    Name = "Jon"
                }
            };

            var names = GetEnrollees(people).ToList();
            Console.WriteLine(names.Count);
            Console.WriteLine(names[0]);
        }

        internal class Student
        {
            public bool Graduated { get; set; }
            public string Name { get; set; }
        }

        private static IEnumerable<string> GetEnrollees(List<Student> people)
        {
            foreach (var p in people)
            {
                if (p is Student { Graduated: false, Name: string name }) yield return name;
            }
        }

        #endregion

        #region Switch expressions

        private static void SwitchExpressions()
        {
            Console.WriteLine(GetArea(new Line { Length = 3.0 }));
            Console.WriteLine(GetArea(new Circle { Radius = 4.20 }));
            Console.WriteLine(GetArea(new Rectangle { Height = 2, Width = 2.5 }));
            Console.WriteLine(GetArea(new object()));
        }

        private static double GetArea(object figure)
        {
            var area = figure switch
            {
                Line _ => 0,
                Rectangle r => r.Width * r.Height,
                Circle c => Math.PI * c.Radius * c.Radius,
                _ => -1
            };

            return area;
        }

        internal class Line
        {
            public double Length { get; set; }
        }

        internal class Rectangle
        {
            public Rectangle()
            {

            }

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public double Width { get; set; }
            public double Height { get; set; }
        }

        internal class Circle
        {
            public double Radius { get; set; }
        }

        #endregion

        #region Target-typed new-expressions

        //Rectangle[] rectangles = { new (1, 2) };

        #endregion

        #region More patterns in more places

        static string Display(object o)
        {
            return o switch
            {
                Point p when p.X == 0 && p.Y == 0 => "origin",
                Point p => $"({p.X}, {p.Y})",
                _ => "unknown"
            };
        }

        static string Display2(object o) => o switch
        {
            Point p when p.X == 0 && p.Y == 0 => "origin",
            Point p => $"({p.X}, {p.Y})",
            _ => "unknown"
        };

        #endregion

        #region Property patterns

        static string Display3(object o) => o switch
        {
            Point { X: 0, Y: 0 } p => "origin",
            Point { X: var x, Y: var y } p => $"({x}, {y})",
            _ => "unknown"
        };

        static string Display4(object o) => o switch
        {
            Point { X: 0, Y: 0 } => "origin",
            Point { X: var x, Y: var y } => $"({x}, {y})",
            { } => o.ToString(), // not null
            null => "null"
        };

        #endregion

        #region Positional patterns

        static string Display5(object o) => o switch
        {
            MyPoint (0, 0) => "origin",
            MyPoint (var x, var y) => $"({x}, {y})",
            _ => "unknown"
        };

        internal class MyPoint
        {
            public int X { get; set; }
            public int Y { get; set; }

            public void Deconstruct(out int x, out int y)
            {
                x = X;
                y = Y;
            }
        }

        #endregion

        #region Tuple patterns

        static State ChangeState(State current, Transition transition, bool hasKey) =>
            (current, transition, hasKey) switch
            {
                (State.Opened, Transition.Close, _) => State.Closed,
                (State.Closed, Transition.Open, _) => State.Opened,
                (State.Closed, Transition.Lock, true) => State.Locked,
                (State.Locked, Transition.Unlock, true) => State.Closed,
                _ => throw new InvalidOperationException($"Invalid transition")
            };

        internal enum State
        {
            Opened,
            Closed,
            Locked
        }

        internal enum Transition
        {
            Lock,
            Unlock,
            Open,
            Close
        }

        #endregion

        #region Using declarations

        private static void WriteToAFile()
        {
            using var sw = new StreamWriter(File.OpenWrite("bla.txt"));
            sw.WriteLine("Hellooo!");
        } // disposed

        #endregion


        //#nullable disable
    }
}
