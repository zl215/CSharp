using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static double calcRateRight = 1;
        static double calcRateLeft = 0;
        static double calc(int months, double monthMoney, double ben)
        {
            double prof = months * monthMoney - ben;
            while (true)
            {
                double tmpProfit = CalcProfit(months, (calcRateLeft + calcRateRight) / 2, ben, monthMoney);
                if (tmpProfit > 0)
                {
                    calcRateRight = (calcRateLeft + calcRateRight) / 2;
                }
                else
                {
                    calcRateLeft = (calcRateLeft + calcRateRight) / 2;
                }
                if (tmpProfit < 0.000000001 &&
                    tmpProfit > 0)
                {
                    return (calcRateLeft + calcRateRight) / 2;
                }
            }
        }

        static double CalcProfit(int months, double rate, double ben, double monthGet)
        {
            double totalProfit = 0;
            double left = ben;
            for (int i = months; i > 0; i--)
            {
                totalProfit += left * rate;
                left = left-( monthGet - left * rate);
            }
            return left;
        }

        static void printDetail(double rate, double ben, double monthGet, int months)
        {
            double left = ben;
            for (int i = 0; i < months; i++)
            {
                double monthProfit = left * rate;
                left = left - (monthGet - monthProfit);
                Console.WriteLine("{0}month:{1}, profit:{2},left ben:{3}",
                    i, monthGet - monthProfit, monthProfit, left);
           }
        }

        static void Main(string[] args)
        {
            int months = 360;
            double monthGet = 6800;
            double ben = 1400000;
            double i = calc(months, monthGet, ben);

            printDetail(i, ben, monthGet, months);
            Console.WriteLine(i*12);
            Console.ReadKey();
        }
    }
}
