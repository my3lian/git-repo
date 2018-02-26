using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using CSharpP2_Homework_1;

/// <summary>
/// Торочков Илья
///2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
///3. Сделать так, чтобы при столкновениях пули с астероидом пуля и астероид регенерировались в разных концах экрана;
///4. Сделать проверку на задание размера экрана в классе Game.Если высота или ширина(Width, Height) больше 1000 или принимает отрицательное значение, то выбросить исключение ArgumentOutOfRangeException().
///5. * Создать собственное исключение GameObjectException, которое появляется при попытке создать объект с неправильными характеристиками(например, отрицательные размеры, слишком большая скорость или позиция).
/// </summary>

namespace CSharpP2_Homework_1
{
    public class Program
    {
        static Form form;

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            try
            {
                form = new Form();
                form.Size = new Size(800, 600);
                CSharpP2_Homework_1.SplashScreen.Init(form);

                form.Show();
                CSharpP2_Homework_1.SplashScreen.Draw();

                Application.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }

        }

        public static void BtnPlay_Click(object sender, EventArgs e)
        {
            CSharpP2_Homework_1.SplashScreen.Stop(form);
            form.Controls.Clear();
            Game.Init(form);
            Cursor.Hide();
        }

        internal static void BtnQuit_Click(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        internal static void btnRecord_Click(object sender, MouseEventArgs e)
        {
            
        }
    }
}
