using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabFunctions;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double a1 = ConsoleFuncs.CheckedDoubleInput("Введите а1: "),
                a2 = ConsoleFuncs.CheckedDoubleInput("Введите а2: "),
                a3 = ConsoleFuncs.CheckedDoubleInput("Введите а3: ");
            int M = ConsoleFuncs.CheckedIntegerInput("Введите M: ", "=>0"),
                N = ConsoleFuncs.CheckedIntegerInput("Введите N: ", "=>0");
            double L = ConsoleFuncs.CheckedDoubleInput("Введите L: ");

            Sequence seq = new Sequence(a1, a2, a3);

            int moreThanL = 0;
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(seq[i]);
                if (seq[i] > L) moreThanL++;
                if (moreThanL >= M)
                {
                    Console.WriteLine("Найдены первые M элементов, большие числа L.");
                    Console.WriteLine("Нажмите любую клавишу для выхода...");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("Найдены первые N элементов.");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
