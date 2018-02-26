using CSharpP2_Homework_1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpP2_Homework_1
{
    class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static List<SplashScreenObjects> _objs;
        static Timer timer;
        static Random rnd = new Random((int)DateTime.Now.Ticks);

        public static int Width { get; set; }
        public static int Height { get; set; }

        static SplashScreen() { }

        /// <summary>
        /// Инициализирует экранную форму
        /// </summary>
        /// <param name="form">Инициализируемая форма</param>
        public static void Init(Form form)
        {
            List<Button> buttons = CreateControls();

            foreach( Button btn in buttons)
                form.Controls.Add(btn);

            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        /// <summary>
        /// Останавливает отрисовку главного меню
        /// </summary>
        /// <param name="form"></param>
        public static void Stop(Form form)
        {
            Buffer.Graphics.Clear(Color.Black);
            timer.Stop();
        }

        /// <summary>
        /// Отрисовывает объекты
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (SplashScreenObjects obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Загружает объекты меню
        /// </summary>
        public static void Update()
        {
            foreach (SplashScreenObjects obj in _objs)
                obj.Update();
        }

        public static void Load()
        {
            _objs = new List<SplashScreenObjects>();
            for (int i = 0; i < 30; i++)
            {
                int size = rnd.Next(1, 10);
                _objs.Add(new SPStar(
                    new Point(rnd.Next(0, 800), rnd.Next(0, 600)),
                    new Point(1, 0),
                    new Size(size, size),
                    "star.png"
                ));
            }
            for (int i = 0; i < 1; i++)
            {
                int size = rnd.Next(800, 800);
                _objs.Add(new SPPlanet(
                    new Point(300,200),
                    new Point(0, 0),
                    new Size(800, 800),
                    "planet.png"
                ));
            }

        }
        /// <summary>
        /// Обработчик таймера
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public static void Timer_Tick(object Sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Создает кнопки главного меню
        /// </summary>
        /// <returns></returns>
        static List<Button> CreateControls()
        {
            List<Button> buttons = new List<Button>();

            //btnPlay
            Button btnPlay = new Button();
            btnPlay.Location = new Point(200,150);
            btnPlay.Size = new Size(100, 30);
            btnPlay.BackColor = Color.Black;
            btnPlay.ForeColor = Color.White;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.Text = "Играть";
            btnPlay.Font = new Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.MouseClick += new System.Windows.Forms.MouseEventHandler(Program.BtnPlay_Click);

            //btnRecords
            Button btnRecords = new Button();
            btnRecords.Location = new Point(200, 200);
            btnRecords.Size = new Size(100, 30);
            btnRecords.BackColor = Color.Black;
            btnRecords.ForeColor = Color.White;
            btnRecords.FlatStyle = FlatStyle.Flat;
            btnRecords.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnRecords.FlatAppearance.BorderSize = 0;
            btnRecords.Text = "Рекорды";
            btnRecords.Font = new Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            btnRecords.UseVisualStyleBackColor = false;
            btnRecords.MouseClick += new System.Windows.Forms.MouseEventHandler(Program.btnRecord_Click);

            //btnQuit
            Button btnQuit = new Button();
            btnQuit.Location = new Point(200, 250);
            btnQuit.Size = new Size(100, 30);
            btnQuit.BackColor = Color.Black;
            btnQuit.ForeColor = Color.White;
            btnQuit.FlatStyle = FlatStyle.Flat;
            btnQuit.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnQuit.FlatAppearance.BorderSize = 0;
            btnQuit.Text = "Выйти";
            btnQuit.Font = new Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            btnQuit.UseVisualStyleBackColor = false;
            btnQuit.MouseClick += new System.Windows.Forms.MouseEventHandler(Program.BtnQuit_Click);

            buttons.Add(btnPlay);
            buttons.Add(btnQuit);
            buttons.Add(btnRecords);
            return buttons;
        }
    }

}
