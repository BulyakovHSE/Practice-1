using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFunctions
{
    public class ConsoleFuncs
    {
        public static int EnterNumberInRange(string outputMessage, int low, int hight)
        {
            int num;
            do
            {
                num = CheckedIntegerInput(outputMessage);
                if (!(num >= low && num < hight))
                    Console.WriteLine("Введите число из диапозона от " + low + " до " + hight + "!");
            } while (!(num >= low && num < hight));
            return num;
        }

        public static void DeleteRows(int StartPosition)
        {
            string Space = "";
            for (int i = 0; i < Console.BufferWidth; i++)
                Space += " ";

            int StringQuantity = Console.CursorTop - StartPosition;
            if (StringQuantity <= 0) return;
            Console.CursorTop = StartPosition;
            // Удаление строк
            for (int j = 0; j < StringQuantity; j++)
                Console.Write(Space);
            Console.CursorTop = StartPosition;
        }

        public static string ReplaceDots(string Expression)
        { // Замена точек в выражении на запятые, т.к. Double.TryParse() принимает только их.
            String str = "";
            foreach (Char ch in Expression)
            {
                if (ch != '.') str += ch;
                else str += ',';
            }
            Expression = str;
            return Expression;
        }

        public static int HorizontalMenu(params string[] items)
        {
            // Инициализация переменных
            int previousLenght = 0, currentLenght = 0;
            int currentIndex = 0, previousIndex = 0;
            int positionX = 5, positionY = Console.CursorTop + 1;
            bool itemSelected = false;

            if (items.Length == 0) return 0;

            // Начальная печать пунктов меню
            for (int i = 0; i < items.Length; i++)
            {
                Console.CursorLeft = positionX + previousLenght;
                Console.CursorTop = positionY;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[i]);
                previousLenght += items[i].Length + 1;
            }
            previousLenght = 0;
            do
            {
                // Печать предыдущего активного пункта основным                
                Console.CursorLeft = positionX + previousLenght;
                Console.CursorTop = positionY;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[previousIndex]);
                if (previousIndex < currentIndex)
                {
                    previousLenght += items[previousIndex].Length + 1;
                }
                else if (previousIndex > currentIndex)
                {
                    previousLenght -= items[currentIndex].Length + 1;
                }

                //Печать активного пункта
                if (previousIndex < currentIndex)
                {
                    currentLenght += items[previousIndex].Length + 1;
                }
                else if (previousIndex > currentIndex)
                {
                    currentLenght -= items[currentIndex].Length + 1;
                }
                Console.CursorLeft = positionX + currentLenght;
                Console.CursorTop = positionY;
                Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(items[currentIndex]);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                previousIndex = currentIndex;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        currentIndex++;
                        break;
                    case ConsoleKey.LeftArrow:
                        currentIndex--;
                        break;
                    case ConsoleKey.Enter:
                        itemSelected = true;
                        break;
                }
                // Избегание выхода за границы 
                if (currentIndex == items.Length)
                    currentIndex = items.Length - 1;
                else if (currentIndex < 0)
                    currentIndex = 0;
            }
            while (!itemSelected);

            Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorLeft = 0;
            Console.CursorTop += 2;

            return currentIndex;
        }

        public static int VerticalMenu(params string[] items)
        {
            // Инициализация переменных
            int currentIndex = 0, previousIndex = 0;
            int positionX = 5, positionY = Console.CursorTop + 1;
            bool itemSelected = false;

            //Начальный вывод пунктов меню.
            for (int i = 0; i < items.Length; i++)
            {
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + i;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[i]);
            }

            do
            {
                // Вывод предыдущего активного пункта основным цветом.
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + previousIndex;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[previousIndex]);


                //Вывод активного пункта.
                Console.CursorLeft = positionX;
                Console.CursorTop = positionY + currentIndex;
                Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(items[currentIndex]);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                previousIndex = currentIndex;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        currentIndex++;
                        break;
                    case ConsoleKey.UpArrow:
                        currentIndex--;
                        break;
                    case ConsoleKey.Enter:
                        itemSelected = true;
                        break;
                }

                if (currentIndex == items.Length)
                    currentIndex = items.Length - 1;
                else if (currentIndex < 0)
                    currentIndex = 0;
            }
            while (!itemSelected);

            Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorLeft = 0;
            Console.CursorTop += 1 + items.Length - currentIndex;

            return currentIndex;
        }

        public static int CheckedIntegerInput(string OutputMessage, string type = "<=>0")
        {
            bool input = false;
            int Number = 0, StartPosition = Console.CursorTop;
            if (type == "<=>0")
            {
                do
                {
                    Console.Write(OutputMessage);
                    input = Int32.TryParse(Console.ReadLine(), out Number);
                    if (!input)
                        Console.WriteLine("Введите целое число!");
                } while (!input);
            }
            else if (type == "=>0" || type == ">=0")
            {
                do
                {
                    Console.Write(OutputMessage);
                    input = Int32.TryParse(Console.ReadLine(), out Number);
                    if (!input || Number < 0)
                    {
                        Console.WriteLine("Введите целое положительное число!");
                        input = false;
                    }
                } while (!input);
            }
            DeleteRows(StartPosition);
            return Number;
        }

        public static double CheckedDoubleInput(string OutputMessage, string type = "<=>0")
        {
            bool input = false;
            int StartPosition = Console.CursorTop;
            double Number = 0;
            if (type == "<=>0")
            {
                do
                {
                    Console.Write(OutputMessage);
                    input = Double.TryParse(ReplaceDots(Console.ReadLine()), out Number);
                    if (!input)
                        Console.WriteLine("Введите действительное число!");
                } while (!input);
            }
            else if (type == "=>0" || type == ">=0")
            {
                do
                {
                    Console.Write(OutputMessage);
                    input = Double.TryParse(ReplaceDots(Console.ReadLine()), out Number);
                    if (!input || Number < 0)
                    {
                        Console.WriteLine("Введите действительное положительное число!");
                        input = false;
                    }
                } while (!input);
            }
            DeleteRows(StartPosition);
            return Number;
        }

        public static int CheckedIntegerInput(string OutputMessage, int MinValue, int MaxValue)
        {
            bool input = false;
            int Number = 0, StartPosition = Console.CursorTop;
            do
            {
                Console.Write(OutputMessage);
                input = Int32.TryParse(Console.ReadLine(), out Number);
                if (!(input && Number <= MaxValue && Number >= MinValue))
                {
                    Console.WriteLine("Введите целое число!");
                    input = false;
                }
            } while (!input);

            DeleteRows(StartPosition);
            return Number;
        }
    }
}
