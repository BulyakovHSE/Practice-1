using System.Collections.Generic;

namespace Task_8
{
    class GraphPeak
    {
        public List<GraphPeak> Ribs { get; private set; }

        public string Name { get; set; }

        public int Color { get; set; }

        public GraphPeak(string name, List<GraphPeak> ribs = null)
        {
            Name = name;
            if (ribs != null)
                Ribs = ribs;
            else Ribs = new List<GraphPeak>();
            Color = 0;
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
}
