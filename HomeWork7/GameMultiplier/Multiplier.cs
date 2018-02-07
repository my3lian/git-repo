using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMultiplier
/*  Торочков Илья
     5. **Существует алгоритмическая игра “Удвоитель”. В этой игре человеку предлагается какое-то число, а человек должен, управляя роботом “Удвоитель”, достичь этого числа за минимальное число шагов.
     Робот умеет выполнять несколько команд: увеличить число на 1, умножить число на 2 и сбросить число до 1. Начальное значение удвоителя равно 1.

    Реализовать класс “Удвоитель”. Класс хранит в себе поле current - текущее значение, finish - число, которого нужно достичь, конструктор, в котором задается конечное число.
    Методы: увеличить число на 1, увеличить число в два раза, сброс текущего до 1, свойство Current, которое возвращает текущее значение, свойство Finish,которое возвращает конечное значение.
    Создать с помощью этого класса игру, в которой компьютер загадывает число, а человек. выбирая из меню на экране, отдает команды удвоителю и старается получить это число за наименьшее число ходов.
    Если человек получает число больше положенного, игра прекращается.
*/
{

    /// <summary>
    /// Класс реализующий робота-удвоителя
    /// </summary>
    class Multiplier 
    {

        public StepsStack stepsStack;

        public const string FOREWORD = "Существует алгоритмическая игра “Удвоитель”.\n" +
                                "В этой игре человеку предлагается какое-то число,\n" +
                                " а человек должен, управляя роботом “Удвоитель”,\n" +
                                "достичь этого числа за минимальное число шагов.\n" +
                                "Робот умеет выполнять несколько команд:\n" +
                                "увеличить число на 1, умножить число на 2 и сбросить число до 1.\n" +
                                " Начальное значение удвоителя равно 1.\n";

        int current = 1;
        int finish;
        int stepsCount = 0;
        int maxStepsRollback;
        bool isWin = false;
        bool isLoose = false;

        /// <summary>
        /// Свойство определяющее результат как победу
        /// </summary>
        public bool IsWin
        {
            get
            {
                return isWin;
            }
            private set
            {
                isWin = value;
            }
        }

        /// <summary>
        /// Свойство определяющее результат как проигрыш
        /// </summary>
        public bool IsLoose
        {
            get
            {
                return isLoose;
            }
            private set
            {
                isLoose = value;
            }
        }

        /// <summary>
        /// Свойство количество шагов
        /// </summary>
        public int StepsCount {
            get
            {
                return stepsCount;
            }
        }

        /// <summary>
        /// Свойство определяющее текущий счет
        /// </summary>
        public int Current {
            get
            {
                return current;
            }
            private set
            {
                stepsStack.Add(current);
                
                current = value;
                stepsCount++;

                IsEnd();
            }
        }

        /// <summary>
        /// Свойство определяющее число, которое нужно достичь
        /// </summary>
        public int Finish
        {
            get
            {
                return finish;
            }
        }

        /// <summary>
        /// Конструктор инициализирует объект класса Multiplier с указанием конечного числа и количество возможных откатов шагов
        /// </summary>
        public Multiplier(int finish, int maxStepsRollback) {
            this.finish = finish;
            stepsStack = new StepsStack(maxStepsRollback);
        }

        /// <summary>
        /// Прибавляет к текущему счету 1
        /// </summary>
        public void Inc() { Current++; }
        /// <summary>
        /// Умножает счет на 2
        /// </summary>
        public void IncX2() { Current *= 2; }
        /// <summary>
        /// Сбрасывает счет до 1 (считается шагом)
        /// </summary>
        public void Reset() { Current = 1; }

        /// <summary>
        /// Откатывает на один шаг назад
        /// </summary>
        public void Endo()
        {
            if(stepsStack.Count > 0)
                current = stepsStack.Pop();
                
        }

        /// <summary>
        /// Определяет результат игры
        /// </summary>
        public void IsEnd()
        {
            if (Current == Finish) IsWin = true;
            if (Current > Finish) IsLoose = true;
        }
    }

    /// <summary>
    /// Класс на основе List для реализации стека отмены шагов
    /// </summary>
    class StepsStack
    {
        List<int> stack;

        /// <summary>
        /// Определяет возможное количество откатов шагов
        /// </summary>
        int capacity;

        /// <summary>
        /// Свойство определяющее количество шагов в стеке
        /// </summary>
        public int Count
        {
            get
            {
                return stack.Count;
            }
        }


        public StepsStack(int capacity)
        {
            this.capacity = capacity;
            stack = new List<int>();
        }

        /// <summary>
        /// Добавляет шаг в стек
        /// </summary>
        public void Add (int step)
        {
            if (stack.Count >= capacity)
            {
                stack.Remove(stack.First());
            }
            stack.Add(step);
        }

        /// <summary>
        /// Удаляет последний сделаный шаг из стека и возвращает его значение
        /// </summary>
        public int Pop()
        {
            int last = stack.Last();
            stack.Remove(last);
            return last;            
        }
    }
}
