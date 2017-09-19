using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabFunctions;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = ConsoleFuncs.CheckedIntegerInput("Введите n: ", "=>0");

            // Инициализация и заполнение матрицы случайными значениями
            double[][] matr = new double[n][];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                matr[i] = new double[n];
                for (int j = 0; j < n; j++)
                {
                    matr[i][j] = rand.NextDouble();
                }
            }

            // Сохранение максимальных значений строк матрицы
            double[] maxValues = new double[n];

            for (int i = 0; i < n; i++)
            {
                maxValues[i] = matr[i].Max();
            }

            // Вычисление суммы
            double summ = 0;

            for (int i = 0, j = n - 1; i < n; i++, j--)
            {
                summ += maxValues[i] * maxValues[j];
            }

            // Вывод матрицы и результата
            Console.WriteLine("Матрица: ");
            foreach (double[] line in matr)
            {
                foreach (double item in line)
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Ответ: "+summ);
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();  
        }
    }
}
