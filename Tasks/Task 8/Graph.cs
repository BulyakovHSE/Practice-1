using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_8
{
    class Graph
    {
        public List<GraphPeak> Peaks { get; set; }

        public bool IsBilobed { get { return Bilobed(); } }

        // Определение двудольности графа путем расскраски его двумя цветами
        private bool Bilobed()
        {
            int color = 1;
            for (int i = 0; i < Peaks.Count; i++)
            {
                // Если вершина не закрашена
                if (Peaks[i].Color == 0)
                {
                    // Проверка соседних вершин
                    int c1 = 0, c2 = 0;
                    for (int j = 0; j < Peaks[i].Ribs.Count; j++)
                    {
                        if (Peaks[i].Ribs[j].Color == color) c1++;
                        else if (Peaks[i].Ribs[j].Color == ((color % 2) + 1)) c2++;
                    }

                    // Если на соседних вершинах есть оба цвета - граф не двудолен
                    if (c1 > 0 && c2 > 0) return false;

                    // Иначе, если вершины закрашены этим же цветом, смена цвета
                    if (c1 > 0) color = (color % 2) + 1;

                    // Закрасска вершины новым цветом, смена цвета
                    Peaks[i].Color = color;
                    color = (color % 2) + 1;

                    // Закрасска оставшихся нераскрашенными соседних вершин
                    for (int j = 0; j < Peaks[i].Ribs.Count; j++)
                    {
                        if (Peaks[i].Ribs[j].Color == 0)
                            Peaks[i].Ribs[j].Color = color;
                    }
                }
                // Если вершина закрашена
                else
                {
                    // Проверка соседних вершин
                    int c1 = 0, c2 = 0;
                    for (int j = 0; j < Peaks[i].Ribs.Count; j++)
                    {
                        if (Peaks[i].Ribs[j].Color == color) c1++;
                        else if (Peaks[i].Ribs[j].Color == ((color % 2) + 1)) c2++;
                    }
                    if (c1 > 0 && c2 > 0) return false;
                    if (c1 > 0 && color == Peaks[i].Color) return false;
                    if (c2 > 0 && ((color % 2) + 1) == Peaks[i].Color) return false;
                }
            }

            return true;
        }

        public Graph(List<GraphPeak> peaksWithRibs)
        {
            Peaks = peaksWithRibs;
        }

        public Graph(List<GraphPeak> peaks, List<GraphPeak[]> Ribs)
        {
            // Добавление ребер в граф
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
    }
}
