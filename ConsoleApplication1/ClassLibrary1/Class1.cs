using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Class1:IItf1,IItf2
    {
        void IItf1.Abc()
        {
            
        }
        void IItf2.Abc()
        {

        }

        private int aaa1;
    }

    class MyClasssub :Class1
    {
        private int a;
    }

    class MyClassSubSub : MyClasssub
    {
        private int c;
    }

    class MyClassSubSubSub : MyClassSubSub
    {
        private int b;
    }

    public interface IItf1
    {
        void Abc();
    }
    public interface IItf2
    {
        void Abc();
    }
}
