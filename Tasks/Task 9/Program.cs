using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabFunctions;

namespace Task_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = ConsoleFuncs.CheckedIntegerInput("Введите N: ", ">0");
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = i + 1;
            }
            CicleList list = new CicleList(arr);

            Menu(list);
        }

        static void Menu(CicleList list)
        {
            switch (ConsoleFuncs.HorizontalMenu("Просмотр списка", "Поиск", "Удаление", "Выход"))
            {
                case 0:
                    {
                        CicleList first = list, next = first.Next;
                        Console.WriteLine(first.Num);
                        if (first.Equals(next))
                        {
                            Menu(list);
                        }
                        while (!first.Equals(next))
                        {
                            Console.WriteLine(next.Num);
                            next = next.Next;
                        }
                        Menu(list);
                    }
                    break;
                case 1:
                    {
                        int template = ConsoleFuncs.CheckedIntegerInput("Введите искомый элемент списка: ", ">0");
                        CicleList response = list.Find(template);
                        if (response != null)
                            Console.WriteLine($"Элемент найден! { response.Num }");
                        else Console.WriteLine("Элемент не найден!");
                        Menu(list);
                    }
                    break;
                case 2:
                    {
                        int template = ConsoleFuncs.CheckedIntegerInput("Введите элемент, который хотите удалить: ", ">0");
                        list = list.Delete(new CicleList(template));
                        Menu(list);
                    }
                    break;
                case 3:
                    {
                        return;
                    }
            }
        }
    }
}
