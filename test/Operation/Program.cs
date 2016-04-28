using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation
{
    class Operation
    {
        private int x;
        private int y;
        private int result;

        public Operation()
        {

        }
        public Operation(int a, int b)
        {
            x = a;
            y = b;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Result
        {
            get { return result; }
            set { result = value; }
        }
        public virtual void op() { }
    }
    class Add:Operation
    {
        public Add() { }
        public Add(int a, int b):base(a,b)
        {
        }
        public override void op()
        {
            Result = X + Y;
        }
    }

    class Miner : Operation
    {
        public Miner() { }
        public Miner(int a, int b):base(a, b)
        {

        }
        public override void op()
        {
            Result = X - Y;
        }
    }

    class OperationFactory
    {
        public static Operation CreatOperation(string s)
        {
            switch(s)
            {
                case "+":
                    return new Add();
                case "-":
                    return new Miner();
                default:
                    return new Add();
            }
        }
    }

    interface IOperationFactory
    {
        Operation CreatOperation();
    }

    class AddFactory:IOperationFactory
    {
        public Operation CreatOperation()
        {
            return new Add();
        }
    }

    class MinerFactory : IOperationFactory
    {
        public Operation CreatOperation()
        {
            return new Miner();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Operation oper = OperationFactory.CreatOperation("+");
            //oper.X = 10;
            //oper.Y = 20;
            //oper.op();
            //Console.WriteLine(oper.Result);

            IOperationFactory opCreator = new MinerFactory();
            Operation op = opCreator.CreatOperation();
            op.X = 10;
            op.Y = 20;
            op.op();
            Console.WriteLine(op.Result);
        }
    }
}
