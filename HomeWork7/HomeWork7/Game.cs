using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
/*  Торочков Илья
     5. **Существует алгоритмическая игра “Удвоитель”. В этой игре человеку предлагается какое-то число, а человек должен, управляя роботом “Удвоитель”, достичь этого числа за минимальное число шагов.
     Робот умеет выполнять несколько команд: увеличить число на 1, умножить число на 2 и сбросить число до 1. Начальное значение удвоителя равно 1.

    Реализовать класс “Удвоитель”. Класс хранит в себе поле current - текущее значение, finish - число, которого нужно достичь, конструктор, в котором задается конечное число.
    Методы: увеличить число на 1, увеличить число в два раза, сброс текущего до 1, свойство Current, которое возвращает текущее значение, свойство Finish,которое возвращает конечное значение.
    Создать с помощью этого класса игру, в которой компьютер загадывает число, а человек. выбирая из меню на экране, отдает команды удвоителю и старается получить это число за наименьшее число ходов.
    Если человек получает число больше положенного, игра прекращается.
*/
{
    class Game
    {
        const string FOREWORD = "Существует алгоритмическая игра “Удвоитель”.\n" +
                                "В этой игре человеку предлагается какое-то число, а человек должен, управляя роботом “Удвоитель”,\n" +
                                "достичь этого числа за минимальное число шагов.\n" +
                                "Робот умеет выполнять несколько команд:\n" +
                                "увеличить число на 1, умножить число на 2 и сбросить число до 1. Начальное значение удвоителя равно 1.\n" +
                                "Команды: \n" +
                                "  + - увеличить число на 1\n" +
                                "  x - умножить число на 2\n" +
                                "  r - сбросить число до 1\n" +
                                "  q - выход из игры";


        static void Main(string[] args)
        {
            bool endgame = false;

            int step = 0;

            Console.WriteLine(FOREWORD);

            Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            Multiplier mult = new Multiplier(rnd.Next(1, 50));

            while (!endgame)
            {
                Console.WriteLine($"Текущее число: {mult.Current}");
                Console.WriteLine($"Цель - число {mult.Finish}");
                Console.WriteLine("Жду команды...");
                switch (Console.ReadLine().ToUpper())
                {
                    case ("+"):
                        mult.Inc();
                        break;
                    case ("X"):
                        mult.IncX2();
                        break;
                    case ("R"):
                        mult.Reset();
                        break;
                    case ("Q"):
                        endgame = true;
                        break;
                    default:
                        Console.WriteLine("Я не знаю такой команды =(\n" +
                                          "Попробруй еще");
                        break;
                }

                step++;

                if (mult.Current > mult.Finish)
                {
                    Console.WriteLine("Упс... Перебор. Ты проиграл");
                    endgame = true;
                }

                if (mult.Current == mult.Finish)
                {
                    Console.WriteLine($"У тебя получилось! Ты достиг цели за {step} шагов");
                    endgame = true;
                }
                
            }
            Console.WriteLine("Игра окончена. Пока - пока");
            Console.ReadLine();
        }


    }

    class Multiplier
    {
        int current = 1;
        int finish;

        public int Current {
            get
            {
                return current;
            }
        }

        public int Finish
        {
            get
            {
                return finish;
            }
        }


        public Multiplier(int finish) { this.finish = finish; }

        public void Inc() {  current++; }
        public void IncX2() { current *= 2; }
        public void Reset() { current = 1; }

    }
}
