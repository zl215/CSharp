using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responsibility_Chain
{
    abstract class Response
    {
        protected Response nextResp;
        public void SetNextResp(Response rsp)
        {
            nextResp = rsp;
        }
        public abstract void Agree(int i);
    }
    class ResponseLevelLow:Response
    {
        public override void Agree(int i)
        {
            if (i < 50)
                Console.WriteLine("Level Low Agree {0}", i);
            else
            {
                Console.WriteLine("Level Low can not Agree {0}", i);
                if (nextResp != null)
                    nextResp.Agree(i);
                else
                    Console.WriteLine("no one can agree");
            }
        }
    }
    class ResponseLevelMid : Response
    {
        public override void Agree(int i)
        {
            if (i < 100)
                Console.WriteLine("Level Mid Agree {0}", i);
            else
            {
                Console.WriteLine("Level Mid can not Agree {0}", i);
                if (nextResp != null)
                    nextResp.Agree(i);
                else
                    Console.WriteLine("no one can agree");
            }
        }
    }
    class ResponseLevelHigh : Response
    {
        public override void Agree(int i)
        {
            if (i < 200)
                Console.WriteLine("Level Hig Agree {0}", i);
            else
            {
                Console.WriteLine("Level Hig can not Agree {0}", i);
                if (nextResp != null)
                    nextResp.Agree(i);
                else
                    Console.WriteLine("no one can agree");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Response r1 = new ResponseLevelLow();
            Response r2 = new ResponseLevelMid();
            Response r3 = new ResponseLevelHigh();

            r1.SetNextResp(r2);
            r2.SetNextResp(r3);
            r1.Agree(250);
        }
    }
}
