using System;
using System.Collections.Generic;

namespace Task_8
{
    class TestGenerator
    {
        private Random rand;
        private byte peaksCount;

        public List<GraphPeak> Peaks { get; private set; }

        public List<GraphPeak[]> Ribs { get; private set; }

        public TestGenerator(Random random)
        {
            rand = random;
            peaksCount = (byte)rand.Next(1, 50);
            Ribs = new List<GraphPeak[]>();
            Peaks = new List<GraphPeak>(peaksCount);

            // Создание вершин
            for (int i = 0; i < peaksCount; i++)
            {
                Peaks.Add(new GraphPeak($"{i + 1}"));
            }

            // Создание случайного количества ребер для каждой вершины
            for (int i = 0; i < peaksCount; i++)
            {
                int ribsCount;
                if (peaksCount >= 10)
                {
                    ribsCount = rand.Next(1, 8) / 2;
                }
                else
                {
                    ribsCount = rand.Next(1, 3);
                }

                for (int j = 0; j < ribsCount; j++)
                {
                    int peak = rand.Next(0, peaksCount);
                    if (peak == i) continue;
                    Ribs.Add(new GraphPeak[] { Peaks[i], Peaks[peak] });
                }

            }
        }
    }
}
