using System;

using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Массив, содержащий сообщения при неверном вводе
        /// </summary>
        string[] messages = { "Не угадал", "Неверно", "Не то", "Опять нет" };

        Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        /// <summary>
        /// Искомое число
        /// </summary>
        int finish;
        /// <summary>
        /// Текущее число
        /// </summary>
        int current;
        /// <summary>
        /// Число шагов
        /// </summary>
        int stepsCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработывает загрузку формы
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            
            finish = rnd.Next(0, 100);
            lbStepsCount.Text = String.Empty;

            MessageBox.Show("Я загадал число от 0 до 100. Попробуй угадать его за наименьшее число попыток.", "Угадай число");
        }


        /// <summary>
        /// Обработывает ввод по клавише Enter
        /// </summary>
        private void tbEnter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Int32.TryParse(tbEnter.Text, out current))
                    Check();
                else
                    lbMessage.Text = "Ты ввел что-то не то";
            }
                
        }

        /// <summary>
        /// Проверяет результат игры
        /// </summary>
        private void Check()
        {
            if (finish == current)
            {
                lbMessage.Text = "Ты угадал";
                if (MessageBox.Show($"Верно. Это число {current}. Ты молодец. Число шагов - {stepsCount} ", "Угадал", MessageBoxButtons.OK) == DialogResult.OK)
                    Application.Exit();
            }
            else
            {
                if (finish > current)
                    lbMessage.Text = messages[rnd.Next(0, messages.Length)] + ". Мое число больше";

                if (finish < current)
                    lbMessage.Text = messages[rnd.Next(0, messages.Length)] + ". Мое число меньше";

                if (current < 0 || current > 100)
                    lbMessage.Text = "Я загадал число от 0 до 100";

                tbEnter.Text = String.Empty;
                lbStepsCount.Text = "Шаг: "+ (++stepsCount).ToString();
            }
                
        }
    }


}
