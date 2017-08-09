using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream input = new FileStream("INPUT.TXT", FileMode.Open, FileAccess.Read);
            StreamReader inp = new StreamReader(input);
            FileStream output = new FileStream("OUTPUT.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter outp = new StreamWriter(output);

            string toParse = inp.ReadLine();

            toParse = toParse.Replace("  ", " ");

            string[] nums = toParse.Split();

            int N = Int32.Parse(nums[0]);

            int[] money = new int[N];

            for (int i = 1; i <= N; i++)
            {
                money[i - 1] = Int32.Parse(nums[i]);
            }

            int K = Int32.Parse(nums[N + 1]);
            
            Console.ReadKey();
        }
    }
}
