using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallCash
{
    abstract class Cash
    {
        public abstract double finalCash(double c);
    }

    class NormalCash : Cash
    {
        public override double finalCash(double c)
        {
            return c;
        }
    }

    class DiscountCash:Cash
    {
        private double discount;
        public DiscountCash(double dis)
        {
            discount = dis;
        }
        public override double finalCash(double c)
        {
            return c* discount;
        }
    }

    class ReturnCash:Cash
    {
        private double condition;
        private double ret;
        public ReturnCash(double cond, double ret)
        {
            condition = cond;
            this.ret = ret;
        }
        public override double finalCash(double c)
        {
            int tmp = (int)c / (int)condition;
            if(tmp > 0)
            {
                return c - tmp*ret;
            }
            else
            {
                return c;
            }
        }
    }

    class CashFactory
    {
        public static Cash CreatCash(int type)
        {
            Cash c = null;
            switch(type)
            {
                case 0:
                    c = new NormalCash();
                    break;
                case 1:
                    c = new DiscountCash(0.8);
                    break;
                case 2:
                    c = new ReturnCash(300, 100);
                    break;
            }
            return c;
        }
    }
}
