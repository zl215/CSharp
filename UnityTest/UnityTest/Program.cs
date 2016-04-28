using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UnityTest
{
    class Program
    {
        static void Add(String x)
        {
            while (true)
            {
                lock (x)
                {
                     x = "b";
                    Console.Write(x);
                    Thread.Sleep(500);
                }
            }
        }

        public static void Minus(object x)
        {
            while (true)
            {
                lock(x)
                {
                    x = "a";
                    Console.Write(x);
                    Thread.Sleep(500);
                }
            }

        }
        static void Main(string[] args)
        {
            String a = "z";
            
            Thread t = new Thread(new ParameterizedThreadStart(Minus));
            t.Start(a);
            Add(a);
            Console.WriteLine(a);
        }
    }
}
