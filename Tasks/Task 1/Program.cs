using System;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader inp = new StreamReader("INPUT.TXT");

            string toParse = inp.ReadLine();
            inp.Close();
            toParse = toParse.Replace("  ", " ");

            string[] nums = toParse.Split();

            int N = Int32.Parse(nums[0]);

            int[] money = new int[N ];

            for (int i = 0; i < N; i++)
            {
                money[i] = Int32.Parse(nums[i]);
            }

            int K = Int32.Parse(nums[N + 1]);
            Console.WriteLine($"N = {N}, K = {K}.");

            int[] Summ = new int[N + 1];   // Массив для хранения суммарного количества монет в стопках
            for (int i = 1; i <= N; i++)
            {
                Summ[i] = 0;
                for (int j = i; j <= N; j++)
                {
                    Summ[i] += money[j - 1];
                }
            }

            int[,] G = new int[N + 1, K + 1];  // Массив для хранения монет, которые можно получить.
            // Первое пространство - номер первой оставшейся стопки.
            // Второе - количество стопок которое можно взять.


            // Заполнение при условии что можно взять все оставшиеся стопки.
            for (int R = 1; R <= N; R++)
            {
                for (int M = 1; M <= K; M++)
                {
                    if (M >= N - R + 1) G[R, M] = Summ[R];
                }
            }

            // Заполнение оставшихся значений перебором с выбором максимального значения.
            for (int R = N; R > 0; R--)
            {
                for (int M = 1; M <= K; M++)
                {
                    if (M < N - R + 1)
                    {
                        int[] Wins = new int[M + 1];
                        for (int i = 1; i <= M; i++)
                        {
                            Wins[i] = Summ[R] - G[R + i, i];
                        }
                        Array.Sort(Wins);  // Взятие
                        G[R, M] = Wins[M]; // максимального значения
                    }
                }
            }

            StreamWriter outp = new StreamWriter("OUTPUT.TXT");
            outp.Write(G[1, K]);
            outp.Close();
        }
    }
}
