using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpP2_Homework_1
{
    /// <summary>
    /// Класс, реализующий игровой интерфейс
    /// </summary>
    class GameUI
    {
        /// <summary>
        /// Ссылка на объект "Игра"
        /// </summary>
        public Game GameForm { get => Program.Game; }

        /// <summary>
        /// Ссылка на сущность "Игрок
        /// </summary>
        public Ship Player { get => Program.Game.player; }

        /// <summary>
        /// Визуальный Объект-надпись "Счет"
        /// </summary>
        Label scoreLabel;
        /// <summary>
        /// Визуальный Объект-бар "энергия"
        /// </summary>
        Bar energyBar;

        /// <summary>
        /// Массив элементов UI
        /// </summary>
        List<UIObject> objects = new List<UIObject>();
        public List<UIObject> Objects { get => objects; }


        /// <summary>
        /// Инициализирует новый экземпляр GameUI класса
        /// </summary>
        public GameUI()
        {            
            energyBar = new Bar(new Point(50, GameForm.Height - 100), new Size(200, 10));
            scoreLabel = new Label(new Point(100, 50), Size.Empty);
        }
        /// <summary>
        /// Инициализирует UI
        /// </summary>
        public void Init()
        {
            Player.EnergyChanged += Update;
            GameForm.ScoreChanged += Update;
            objects.Add(energyBar);
            objects.Add(scoreLabel);
            energyBar.Value = Player.Energy;
            scoreLabel.Value = GameForm.Score.ToString();
        }

        /// <summary>
        /// Отрисовывает элементы UI
        /// </summary>
        public void Draw()
        {
            foreach (UIObject obj in objects)
            {
                obj.Draw();
            }
        }

        /// <summary>
        /// Обновляет значения элементов UI
        /// </summary>
        private void Update()
        {
            energyBar.Value = Player.Energy;
            scoreLabel.Value = GameForm.Score.ToString();
        }
    }

    /// <summary>
    /// Класс, реализующий визуальный элемент UI
    /// </summary>
    class UIObject
    {
        
        public Point Pos { get; private set; }
        public Size Size { get; private set; }

        public Game GameForm { get => Program.Game; }

        public UIObject (Point pos, Size size)
        {
            Pos = pos;
            Size = size;
        }

        public virtual void Draw() {}

        void Update() { }
    }


    /// <summary>
    /// Класс, реализующий элемент бар
    /// </summary>
    class Bar : UIObject
    {
        public int Value { get; set; }
        public Bar(Point pos, Size size) : base(pos , size) { }

        public override void Draw () 
        {
            GameForm.Buffer.Graphics.DrawLine(new Pen(Color.White, Size.Height), Pos, new Point(Pos.X + Value, Pos.Y));
        }
    }

    /// <summary>
    /// Класс, реализующий элемент надпись
    /// </summary>
    class Label : UIObject
    {
        public string Value { get; set; }
        public Label(Point pos, Size size) : base(pos, size)
        {
            
        }

        public override void Draw()
        {
            GameForm.Buffer.Graphics.DrawString($"Счет: {Value}", new Font(FontFamily.GenericSansSerif, 12.0f, FontStyle.Bold), Brushes.AliceBlue, Pos);
        }
    }

}
