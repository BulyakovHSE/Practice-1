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

            string numstr = "";

            for (int i = 0; i < N; i++)
            {
                numstr = ConsoleFuncs.EnterNumberInRange("Введите a" + i + ": ", 0, 2).ToString() + numstr;
            }

            // an не вводится с клавиатуры так как он должен быть равен 1 всегда
            numstr = 1 + numstr;

            // Перевод из двоичной системы в десятичную
            int p = Convert.ToInt32(numstr, 2);

            p *= 3;

            Console.WriteLine("Ответ: "+Convert.ToString(p, 2));
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
