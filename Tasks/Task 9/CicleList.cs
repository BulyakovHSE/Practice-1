namespace Task_9
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    class CicleList
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public long Num { get; set; }

        public CicleList Next { get; set; }

        public CicleList(params int[] param)
        {
            CicleList first, next;
            if (param.Length > 0)
            {
                if (param.Length == 1)
                {
                    Num = param[0];
                    Next = this;
                    return;
                }

                first = new CicleList(param[0]);
                next = new CicleList(param[1]);
                first.Next = next;

                for (int i = 2; i < param.Length; i++)
                {
                    next.Next = new CicleList(param[i]);
                    next = next.Next;
                }

                // Зацикливание списка
                next.Next = first;
                Num = first.Num;
                Next = first.Next;
            }

        }

        public CicleList Find(int template)
        {
            if (Num == template) return this;

            CicleList first = this, next = first.Next;

            while (!first.Equals(next) && !next.Num.Equals(template))
            {
                next = next.Next;
            }
            if (next.Num.Equals(template)) return next;
            return null;
        }

        public CicleList Delete(CicleList template)
        {
            CicleList first = this, next = first.Next;

            if (first.Equals(template) && first.Next .Equals( first)) return null;
            if (first.Next.Equals(template)) first.Next = first.Next.Next;

            while (!first.Equals(next.Next) && !next.Next.Equals(template))
            {
                next = next.Next;
            }
            if (next.Next.Equals(template)) next.Next = next.Next.Next;

            return first;
        }

        public CicleList Delete()
        {
            CicleList first = this, next = first.Next;

            if (next.Equals(first)) return null;

            while (!next.Next.Equals(first))
            {
                next = next.Next;
            }
            if (next.Next.Equals(first)) next.Next = next.Next.Next;

            return next;
        }

        public override bool Equals(object obj)
        {
            CicleList list = obj as CicleList;
            return Num == list.Num;
        }
    }
}
