using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone
{
    abstract class Prototype
    {
        private string s;
        public string S
        {
            get { return s; }
            set { s = value; }
        }
        abstract public Prototype CloneObject();
    }

    class ConcretePrototype : Prototype
    {
        public override Prototype CloneObject()
        {
            return this.MemberwiseClone() as Prototype;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConcretePrototype pro = new ConcretePrototype();
            pro.S = "zhouliang";
            ConcretePrototype proClone = pro.CloneObject() as ConcretePrototype;

            Console.Read();
        }
    }
}
