using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вектора самодвойственных булевых функций от трех аргументов: ");
            for (byte i1 = 0; i1 < 2; i1++)
            {
                for (byte i2 = 0; i2 < 2; i2++)
                {
                    for (byte i3 = 0; i3 < 2; i3++)
                    {
                        for (byte i4 = 0; i4 < 2; i4++)
                        {
                            for (byte i5 = 0; i5 < 2; i5++)
                            {
                                for (byte i6 = 0; i6 < 2; i6++)
                                {
                                    for (byte i7 = 0; i7 < 2; i7++)
                                    {
                                        for (byte i8 = 0; i8 < 2; i8++)
                                        {
                                            if (i1 != i8 && i2 != i7 && i3 != i6 && i4 != i5)
                                            {
                                                Console.WriteLine(""+i1+i2+i3+i4+i5+i6+i7+i8);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
