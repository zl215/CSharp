using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    interface Behaviour
    {
        void DoSth();
    }

    class Actual: Behaviour
    {
        private string s;
        public Actual(string ss)
        {
            s = ss;
        }
        public void DoSth()
        {
            Console.WriteLine("Actual do something");
        }
    }

    class Proxyer : Behaviour
    {
        private Behaviour proxyee;
        public Proxyer(string ss)
        {
            proxyee = new Actual(ss);
        }
        public void DoSth()
        {
            if (proxyee != null)
                proxyee.DoSth();
            Console.WriteLine("Proxyer do something");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Behaviour b = new Proxyer("lala");
            b.DoSth();
        }
    }
}
