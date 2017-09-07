using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabFunctions;

namespace Task_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int peaksCount = ConsoleFuncs.CheckedIntegerInput("Введите количество вершин графа: ", ">0");
            List<GraphPeak> peaks = new List<GraphPeak>();
            List<GraphPeak[]> ribs = new List<GraphPeak[]>();
            for (int i = 0; i < peaksCount; i++)
            {
                Console.WriteLine($"Введите название вершины номер {i + 1}: ");
                string name = Console.ReadLine();
                Console.WriteLine($"Введите данные вершины номер {i + 1}: ");
                peaks.Add(new GraphPeak(name, Console.ReadLine()));
            }
            for (int i = 0; i < peaksCount; i++)
            {
                int ribsCount = ConsoleFuncs.EnterNumberInRange($"Введите количество ребер вершины {peaks[i].Name}: ", 1, peaksCount + 1);
                for (int j = 0; j < ribsCount; j++)
                {
                    int rib = ConsoleFuncs.EnterNumberInRange($"Введите номер вершины с которой нужно соединить вершину {peaks[i].Name}: "
                        , 1, peaksCount + 1);
                    if (rib == i) continue;
                    ribs.Add(new GraphPeak[] { peaks[i], peaks[rib - 1] });
                }
            }

            Graph g = new Graph(peaks, ribs);

            Console.WriteLine("Список вершин: ");
            foreach (GraphPeak gp in peaks)
            {
                Console.Write(gp + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Список ребер: ");
            for (int i = 0; i < ribs.Count; i++)
            {
                if (i != ribs.Count - 1)
                    Console.Write("" + ribs[i][0] + " - " + ribs[i][1] + ", ");
                else
                    Console.WriteLine("" + ribs[i][0] + " - " + ribs[i][1]);
            }

            Console.WriteLine($"Введите значение информационного поля для удаления: ");
            string data = Console.ReadLine();

            g.DeletePeak(g.Peaks.Find(new Predicate<GraphPeak>((peak)=> { return peak.Data == data; })));

            peaks = g.Peaks;

            Console.WriteLine("Список вершин: ");
            foreach (GraphPeak gp in peaks)
            {
                Console.Write(gp + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }

    class GraphPeak
    {
        public List<GraphPeak> Ribs { get; private set; }

        public string Name { get; set; }

        public string Data { get; set; }

        public GraphPeak(string name, string data, List<GraphPeak> ribs = null)
        {
            Name = name;
            if (ribs != null)
                Ribs = ribs;
            else Ribs = new List<GraphPeak>();
            Data = data;
        }

        public void AddRib(GraphPeak rib)
        {
            Ribs.Add(rib);
            rib.Ribs.Add(this);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    class Graph
    {
        public List<GraphPeak> Peaks { get; set; }
        
        public Graph(List<GraphPeak> peaksWithRibs)
        {
            Peaks = peaksWithRibs;
        }

        public Graph(List<GraphPeak> peaks, List<GraphPeak[]> Ribs)
        {
            for (int i = 0; i < Ribs.Count; i++)
            {
                int peak1, peak2;
                if (Ribs[i].Length == 2)
                {
                    peak1 = peaks.FindIndex(new Predicate<GraphPeak>((peak) => { return peak == Ribs[i][0]; }));
                    peak2 = peaks.FindIndex(new Predicate<GraphPeak>((peak) => { return peak == Ribs[i][1]; }));
                    if (peak1 != -1 && peak2 != -1)
                    {
                        peaks[peak1].AddRib(peaks[peak2]);
                    }
                    else throw new Exception();
                }
                else throw new Exception();

            }
            Peaks = peaks;
        }

        public void DeletePeak(GraphPeak peak)
        {
            int index;
            do
            {
                index = Peaks.FindIndex(new Predicate<GraphPeak>((peak1) => { return peak1 == peak; }));
                if (index != -1)
                {
                    for (int i = 0; i < Peaks.Count; i++)
                    {
                        if (i != index)
                        {
                            Peaks[i].Ribs.Remove(Peaks[index]);
                        }
                    }
                    Peaks.RemoveAt(index);
                }
            } while (index != -1);
        }
    }
}
