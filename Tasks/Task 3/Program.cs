using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabFunctions;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = ConsoleFuncs.CheckedDoubleInput("Введите число a: ");
            double result = F(a);
            Console.WriteLine("F(a) = {0}", result);
            Console.ReadKey();
        }

        static double F(double x)
        {
            if (x <= -1) return -x - 1;
            else if (x <= 0) return x + 1;
            else if (x <= 1) return -x + 1;
            else return x - 1;
        }
    }
}
