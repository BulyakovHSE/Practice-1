using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabFunctions;

namespace Task_11
{
    class Program
    {
        static string message, encrypted, decrypted;

        static void Main(string[] args)
        {

            message = "Технология секвенирования ДНК помогает ученым находить ответы на вопросы, которые мучили людей испокон веков. Картируя ге";
            Menu();
        }

        static void Menu()
        {
            switch (ConsoleFuncs.HorizontalMenu("Ввести текст", "Зашифровать текст", "Расшифровать текст", "Выход"))
            {
                case 0:
                    {
                        Console.WriteLine("Введите текст длиной 121 символ."
                            + " В случае нарушения этого условия длина текста будет исскуственно установлена равной 121: ");
                        string mes = Console.ReadLine();
                        if (mes.Length != 121)
                        {
                            if (mes.Length < 121)
                                while (mes.Length != 121) mes += ".";
                            else
                            {
                                string mes121 = "";
                                for (int i = 0; i < 121; i++)
                                {
                                    mes121 += mes[i];
                                }
                                mes = mes121;
                            }
                        }
                        message = mes;
                    }
                    break;
                case 1:
                    {
                        Console.WriteLine("Исходный текст: ");
                        Console.WriteLine(message);
                        encrypted = Encrypt(message);
                        Console.WriteLine("Закодированный текст: ");
                        Console.WriteLine(encrypted);
                    }break;
                case 2:
                    {
                        if (encrypted != null)
                        {
                            decrypted = Decrypt(encrypted);
                            Console.WriteLine("Расшифрованный текст");
                            Console.WriteLine(decrypted);
                        }
                        else
                        {
                            Console.WriteLine("Сначала необходимо зашифровать сообщение!");
                        }
                    }break;
                case 3:
                    {
                        return;
                    }
            }
            Menu();
        }

        static string Encrypt(string message)
        {
            string result = "";

            char[,] arr = new char[11, 11];

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    arr[i, j] = message[i * 11 + j];
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }

            int ii = 5, jj = 5, countTop = 1, countRight = 1, countBottom = 2, countLeft = 2;

            while (result.Length < 121)
            {
                for (int i = 0; i < countTop; i++)
                {
                    result += arr[ii, jj++];
                }
                if (result.Length == 121) break;
                countTop += 2;
                for (int i = 0; i < countRight; i++)
                {
                    result += arr[ii++, jj];
                }
                countRight += 2;
                for (int i = 0; i < countBottom; i++)
                {
                    result += arr[ii, jj--];
                }
                countBottom += 2;
                for (int i = 0; i < countLeft; i++)
                {
                    result += arr[ii--, jj];
                }
                countLeft += 2;
            }

            return result;
        }

        static string Decrypt(string message)
        {
            string result = "";

            char[,] arr = new char[11, 11];

            int index = message.Length - 1, ii = 0, jj = 10, countTop = 10, countRight = 10, countBottom = 10, countLeft = 9;
            bool costul = true;
            while (index != 0)
            {
                for (int i = 0; i < countTop; i++)
                {
                    arr[ii, jj--] = message[index--];
                }
                if (index == 0) break;
                if (costul)
                {
                    countTop -= 1;
                    costul = false;
                }
                else
                    countTop -= 2;
                for (int i = 0; i < countRight; i++)
                {
                    arr[ii++, jj] = message[index--];
                }
                countRight -= 2;
                for (int i = 0; i < countBottom; i++)
                {
                    arr[ii, jj++] = message[index--];
                }
                countBottom -= 2;
                for (int i = 0; i < countLeft; i++)
                {
                    arr[ii--, jj] = message[index--];
                }
                countLeft -= 2;
            }

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    result += arr[i, j];
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }

            return result;
        }
    }
}
