using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Илья Торочков
1. а) Добавить в программу “Удвоитель” подсчет количества отданных команд удвоителю.
б) Добавить меню и команду “Играть”. При нажатии появляется сообщение, какое число должен получить игрок. 
Игрок должен постараться получить это число за минимальное количество ходов.
в) * Добавить кнопку “Отменить”, которая отменяет последние ходы.
 */


namespace GameMultiplier
{
    static class Program
    {



        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        public static Multiplier multiplier;
        [STAThread]
        static void Main()
        {

            Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            multiplier = new Multiplier(rnd.Next(10, 30), 3);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
