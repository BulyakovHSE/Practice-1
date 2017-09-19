using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LabFunctions;

namespace Task_8
{
    class Program
    {
        static TestGenerator[] tg;
        static string[] Bilobed;
        static void Main(string[] args)
        {
            Random rand = new Random();
            Menu(rand);
        }

        static void Menu(Random rand)
        {
            switch (ConsoleFuncs.HorizontalMenu("Сгенерировать графы", "Ввести граф", "Выход"))
            {
                case 0:
                    {
                        int graphCount = ConsoleFuncs.CheckedIntegerInput("Введите количество графов для генерации: ", ">0");
                        tg = new TestGenerator[graphCount];
                        Bilobed = new string[graphCount + 1];
                        for (int i = 0; i < graphCount; i++)
                        {
                            tg[i] = new TestGenerator(rand);
                            Graph g = new Graph(tg[i].Peaks, tg[i].Ribs);
                            Bilobed[i] = g.IsBilobed.ToString();
                        }
                        BilobedGraphs(rand);
                    }break;
                case 1:
                    {
                        int peaksCount = ConsoleFuncs.CheckedIntegerInput("Введите количество вершин графа: ", ">0");
                        List<GraphPeak> peaks = new List<GraphPeak>();
                        List<GraphPeak[]> ribs = new List<GraphPeak[]>();
                        for (int i = 0; i < peaksCount; i++)
                        {
                            Console.WriteLine($"Введите название вершины номер {i+1}: ");
                            peaks.Add(new GraphPeak(Console.ReadLine()));
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
                        Console.WriteLine("Двудольность графа: ");
                        Console.WriteLine(g.IsBilobed);

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

                        switch (ConsoleFuncs.HorizontalMenu("В главное меню", "Выход"))
                        {
                            case 0:
                                {
                                    ConsoleFuncs.DeleteRows(0);
                                    Menu(rand);
                                }break;
                            case 1:
                                {
                                    return;
                                }
                        }
                    }break;
            }
        }

        static void BilobedGraphs(Random rand)
        {
            Console.WriteLine("Двудольность сгенерированных графов. Для просмотра вершин и ребер выберите граф: ");
            Bilobed[Bilobed.Length - 1] = "Выход";
            int checkedGraph = ConsoleFuncs.VerticalMenu(Bilobed);
            if (checkedGraph == Bilobed.Length - 1) return;
            else
            {
                Console.WriteLine("Список вершин: ");
                foreach (GraphPeak gp in tg[checkedGraph].Peaks)
                {
                    Console.Write(gp + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Список ребер: ");
                for (int i = 0; i < tg[checkedGraph].Ribs.Count; i++)
                {
                    if (i != tg[checkedGraph].Ribs.Count - 1)
                        Console.Write("" + tg[checkedGraph].Ribs[i][0] + " - " + tg[checkedGraph].Ribs[i][1]+", ");
                    else
                        Console.WriteLine("" + tg[checkedGraph].Ribs[i][0] + " - " + tg[checkedGraph].Ribs[i][1]);
                }
                switch (ConsoleFuncs.HorizontalMenu("В главное меню", "Просмотреть еще один граф", "Выход"))
                {
                    case 0:
                        {
                            ConsoleFuncs.DeleteRows(0);
                            Menu(rand);
                        }break;
                    case 1:
                        {
                            ConsoleFuncs.DeleteRows(0);
                            BilobedGraphs(rand);
                        }
                        break;
                    case 2:
                        {
                            return;
                        }
                }
            }
        }
    }
}
