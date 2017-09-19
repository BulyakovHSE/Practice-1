using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_2
{
    class Program
    { 
        static void Main(string[] args)
        {
            StreamReader inp = new StreamReader("input.txt");
            StreamWriter outp;

            State start = new State(), finish = new State();
            start.Read(inp);
            finish.Read(inp);
            inp.Close();

            Dictionary<State, int> len = new Dictionary<State, int>();
            len.Add(start, 0);
            Queue<State> q = new Queue<State>();
            q.Enqueue(start);
            while (q.Count != 0)
            {
                State current = q.Dequeue();
                if (current == finish)
                {
                    outp = new StreamWriter("OUTPUT.TXT");
                    outp.Write(len[current]);
                    Console.WriteLine(len[current]);
                    outp.Close();
                    Console.ReadKey();
                    return;
                }
                for (int di = -1; di <= 1; di++)
                {
                    for (int dj = -1; dj <= 1; dj++)
                    {
                        if (di * di + dj * dj == 1)
                        {
                            State next = current.Shift(di, dj);
                            if (!len.Keys.Contains(next))
                            {
                                len.Add(next, (len[current] + 1));
                                q.Enqueue(next);
                            }
                        }
                    }
                }
                len.Remove(current);
            }
            //output = new FileStream("OUTPUT.TXT", FileMode.Create, FileAccess.Write);
            outp = new StreamWriter("OUTPUT.TXT");
            outp.Write(-1);
            outp.Close();
            //output.Close();
        }

        struct State
        {
            unsafe fixed byte field[8];

            public unsafe void Read(StreamReader inp)
            {
                for (int i = 0; i < 2; i++)
                {
                    string str = inp.ReadLine();
                    for (int j = 0; j < 4; j++)
                    {
                        fixed (byte* f = field)
                        {
                            f[4 * i + j] = (byte)Char.ConvertToUtf32(str, j);
                        }
                    }
                }
            }

            public unsafe State Shift(int di, int dj)
            {
                State next = (State)MemberwiseClone();
                int ni;
                int nj;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (next.field[4 * i + j] == 35)
                        {
                            ni = i + di;
                            nj = j + dj;
                            if (0 <= ni && ni <= 1 && 0 <= nj && nj <= 3)
                            {
                                next.field[4 * i + j] = next.field[4 * ni + nj];
                                next.field[4 * ni + nj] = 35;

                                return next;
                            }
                        }
                    }
                }
                return this;
            }

            public unsafe static int Compare(State left, State right)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (left.field[4 * i + j] != right.field[4 * i + j])
                        {
                            return left.field[4 * i + j] - right.field[4 * i + j];
                        }
                    }
                }
                return 0;
            }

            public override bool Equals(object obj)
            {
                return Compare(this, (State)obj) == 0;
            }

            public unsafe override int GetHashCode()
            {
                fixed (byte* f = field)
                {
                    return 1 * f[0] + 2 * f[1] + 3 * f[2] + 4 * f[3] + 5 * f[4] + 6 * f[5] + 7 * f[6] + 8 * f[7];
                }
            }

            public static bool operator <(State left, State right)
            {
                return Compare(left, right) < 0;
            }

            public static bool operator >(State left, State right)
            {
                return Compare(left, right) > 0;
            }

            public static bool operator ==(State left, State right)
            {
                return Compare(left, right) == 0;
            }

            public static bool operator !=(State left, State right)
            {
                return Compare(left, right) < 0 || Compare(left, right) > 0;
            }
        }
        
    }
}
