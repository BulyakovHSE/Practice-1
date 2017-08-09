using LabFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = ConsoleFuncs.CheckedIntegerInput("Введите N: ", ">=0");

            string num = "";

            for (int i = 0; i < N; i++)
            {
                num = ConsoleFuncs.EnterNumberInRange("Введите a" + i + ": ", 0, 2).ToString() + num;
            }
            num = 1 + num;

            int num1 = Convert.ToInt32(num, 2);

            num1 *= 3;

            Console.WriteLine("Ответ: "+Convert.ToString(num1, 2));

            Console.ReadKey();
        }
    }
}
