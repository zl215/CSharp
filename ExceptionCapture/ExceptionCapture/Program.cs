using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

public delegate void Print();
namespace ExceptionCapture
{
    class Program
    {
        public void PrintInt()
        {
            Console.WriteLine("zhou");
        }
        public static void PrintString()
        {
            Console.WriteLine("liang");
        }

        private int _i;
        private string[] _names = new string[size];
        static public int size = 10;

        public string this[int idx]
        {
            get { return _names[idx]; }
            set { _names[idx] = value; }
        }
        public int III
        {
            get { return _i; }
            set { _i = value; }
        }

        static void Main(string[] args)
        {
            Program prj = new Program();
            prj[1] = "zhouliang";
            prj[2] = "haha";
            for (int i = 0;i<10;i++)
            {
                Console.WriteLine(prj[i]);
            }

        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception error = (Exception)e.ExceptionObject;
                Console.WriteLine("MyHandler caught : " + error.Message);
            }
            catch
            {
                Console.WriteLine("liang");
            }
        }
    }
}
