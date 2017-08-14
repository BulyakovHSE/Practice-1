namespace Task_6
{
    public class Sequence
    {
        double a1 { get; set; }

        double a2 { get; set; }

        double a3 { get; set; }

        public Sequence(double a1, double a2, double a3)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.a3 = a3;
        }

        public double this[int i]
        {
            get
            {
                if (i < 0) return 0;
                if (i <= 2)
                {
                    switch (i)
                    {
                        case 0: return a1;
                        case 1: return a2;
                        case 2: return a3;
                    }
                    return 0;
                }
                else
                {
                    return Ak(this[i - 1], this[i - 2], this[i - 3]);
                }
            }
        }

        private double Ak(double a1, double a2, double a3)
        {
            return (7 / 3.0 * a1 + a2) / 2 * a3;
        }
    }
    
}
