using System;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace game1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            int max = 0;
            int count = 0;
            int countGame = 0;
            char answer = 'y';
            do
            {
                int counter = 0;
                int number = 0;
                Random(ref number);
                //Console.WriteLine(number); // для отладки

                while (true)
                {
                    counter++;
                    int userNumber;
                    if (!Check(out userNumber))
                    {
                        Console.WriteLine("ТЫ ТУПОЙ");
                        return;
                    }
                    if (Game(userNumber, number))
                    {
                        Win(ref min, ref max, ref counter, ref count, ref countGame);
                        break;
                    }
                }
                Console.WriteLine("Ещё раз?");
                answer = Convert.ToChar(Console.Read());
            } while (answer == 'y');

            Console.WriteLine($"min = {min} max= {max} avg = {(double)count / countGame}");
        }

        static bool Check(out int userNumber)//проверяет правильность ввода числа
        {
            userNumber = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Выбери число [1,100]");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userNumber) && userNumber >= 1 && userNumber <= 100)
                {
                    return true;
                }
            }
            return false;
        }

        static bool Game(int userNumber, int secretNumber)//смотрит введенное число больше или меньше загаданого, если число равно, то победа
        {
            if (userNumber < secretNumber)
            {
                Console.WriteLine("Больше");
                return false;
            }
            else if (userNumber > secretNumber)
            {
                Console.WriteLine("Меньше");
                return false;
            }
            else
            {
                return true;
            }
        }

        static void Random(ref int number)//Рандомно выбирает число от 1 до 100 и записывает 
        {
            Random rnd = new Random();
            number = rnd.Next(1, 101);
        }

        static void Win(ref int min, ref int max, ref int counter, ref int count, ref int countGame)//подсчет статистики в конце игры
        {
            Console.WriteLine("Ты победил!");
            if (min == 0 || counter < min) min = counter;
            if (counter > max) max = counter;
            count += counter;
            countGame++;
        }
    }
}
