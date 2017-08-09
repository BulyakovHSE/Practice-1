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
            while (true)
            {
                double a = ConsoleFuncs.CheckedDoubleInput("Введите число a: ");
                Console.WriteLine("F(a) = {0}", F(a));
                Console.WriteLine("Нажмите любую клавишу для нового ввода...");
                Console.ReadKey();
            }
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
