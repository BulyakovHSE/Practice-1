using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabFunctions;

namespace Task_12
{
    class Program
    {
        delegate int Distributor(int num, int min, int max);

        static void Main(string[] args)
        {
            int BlockCount = ConsoleFuncs.CheckedIntegerInput("Введите количество блоков для блочной сортировки: ", ">0");

            int[] down = new int[100], up = new int[100], not = new int[100];

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                down[i] = 100 - i;
                up[i] = i;
                not[i] = rand.Next(0, 100);
            }

            int refs = 0, comparisons = 0;

            Console.WriteLine("Сортировка массива упорядоченного по возростанию: ");
            //foreach (int item in up) Console.Write(item+" ");
            Console.WriteLine("Результат сортировки вставками: ");

            foreach (int a in (InsertSort((int[])up.Clone(), ref refs, ref comparisons)))
            {
                //Console.Write(a + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сравнений: {comparisons}\nПересылок: {refs}");

            refs = 0; comparisons = 0;

            Console.WriteLine("Результат блочной сортировки: ");
            foreach (int a in (BucketSort(up, 0, 100, ref refs, ref comparisons, BlockCount)))
            {
                //Console.Write(a + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сравнений: {comparisons}\nПересылок: {refs}");

            refs = 0; comparisons = 0;

            Console.WriteLine("Сортировка массива упорядоченного по убыванию: ");
            //foreach (int item in down) Console.Write(item + " ");
            Console.WriteLine("Результат сортировки вставками: ");

            foreach (int a in (InsertSort((int[])down.Clone(), ref refs, ref comparisons)))
            {
                //Console.Write(a + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сравнений: {comparisons}\nПересылок: {refs}");

            refs = 0; comparisons = 0;

            Console.WriteLine("Результат блочной сортировки: ");
            foreach (int a in (BucketSort(down, 0, 100, ref refs, ref comparisons, BlockCount)))
            {
                //Console.Write(a + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сравнений: {comparisons}\nПересылок: {refs}");

            refs = 0; comparisons = 0;

            Console.WriteLine("Сортировка неупорядоченного массива: ");
            //foreach (int item in not) Console.Write(item + " ");
            Console.WriteLine("Результат сортировки вставками: ");

            foreach (int a in (InsertSort((int[])not.Clone(), ref refs, ref comparisons)))
            {
                //Console.Write(a + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сравнений: {comparisons}\nПересылок: {refs}");

            refs = 0; comparisons = 0;

            Console.WriteLine("Результат блочной сортировки: ");
            foreach (int a in (BucketSort(not, 0, 100, ref refs, ref comparisons, BlockCount)))
            {
                //Console.Write(a + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сравнений: {comparisons}\nПересылок: {refs}");

            refs = 0; comparisons = 0;

            Console.ReadKey();
        }

        static int[] InsertSort(int[] arr, ref int refs, ref int comparisons)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j > -1 && arr[j] > key)
                {
                    comparisons += 2;
                    arr[j + 1] = arr[j];
                    refs += 1;
                    j -= 1;
                }
                arr[j + 1] = key;
            }
            return arr;
        }

        static int[] BucketSort(int[] arr, int min, int max, ref int refs, ref int comparisons, int bucketCount = -1)
        {
            if (bucketCount == -1)
                bucketCount = arr.Length;
            
            List<int>[] buckets = new List<int>[bucketCount];
            int[][] bucketsArr = new int[bucketCount][];

            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i] = new List<int>();
            }

            Distributor distributor = (num, a, b) => { return ((bucketCount - 1) * (num - a) / (b - a)); };

            for (int i = 0; i < arr.Length; i++)
            {
                buckets[distributor(arr[i], min, max)].Add(arr[i]);
                refs++;
            }
            for (int i = 0; i < bucketCount; i++)
            {
                bucketsArr[i] = new int[buckets[i].Count];
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    bucketsArr[i][j] = buckets[i][j];
                }
            }

            for (int i = 0; i < bucketCount; i++)
                bucketsArr[i] = InsertSort(bucketsArr[i], ref refs, ref comparisons);

            int[] result = new int[arr.Length];

            int index = 0;

            for (int i = 0; i < bucketCount; i++)
            {
                for (int k = 0; k < buckets[i].Count; k++)
                {
                    result[index++] = bucketsArr[i][k];
                }
            }

            return result;
        }
    }
}
