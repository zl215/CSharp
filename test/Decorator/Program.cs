using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    abstract class Component
    {
        public abstract void Operation();
    }

    class ConcreteComponent:Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent");
        }
    }
    abstract class Decorator:Component
    {
        private Component comp = null;
        public void SetComponent(Component c)
        {
            comp = c;
        }
        public override void Operation()
        {
            if(comp != null)
                comp.Operation();
        }
    }
    class ADecorator: Decorator
    {
        public void AddBehaviour()
        {
            Console.WriteLine("ADecorator AddBehavior");
        }
        public override void Operation()
        {
            base.Operation();
            AddBehaviour();
        }
    }
    class BDecorator : Decorator
    {
        private string addProperty = "zhouliang";

        public string AddProperty
        {
            get { return addProperty; }
            set { addProperty = value; }
        }
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine(addProperty);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteComponent conr = new ConcreteComponent();
            Component adec = new ADecorator();
            Component bdec = new BDecorator();
            (adec as ADecorator).SetComponent(conr);
            (bdec as BDecorator).SetComponent(adec);
            bdec.Operation();

            Console.Read();
        }
    }
}
