using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSharpP2_Homework_1
{
    class Game
    {
        int asteroidsRespawnTime;
        int maxAsteroidCount;
        int asteroidsCount;
        int score;

        GameUI UI;
        BufferedGraphicsContext _context;
        Timer renderer;

        public event Action ScoreChanged;

        public List<GameObject> gameObjects;
        public Ship player;
        public Form f;

        public Random Rnd { get => new Random((int)DateTime.Now.Ticks & 0x0000FFFF); }
        public BufferedGraphics Buffer { get; private set; }
        public int Score { get => score; }
        public Constraint FieldConstraint { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public bool IsEnd { get; private set; }


        /// <summary>
        /// Ограничение игрового поля
        /// </summary>
        public struct Constraint
        {
            public int Top { get; set; }
            public int Left { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }

            public Constraint(int left, int right, int top, int bottom)
            {
                Left = left;
                Right = right;
                Top = top;
                Bottom = bottom;
            }
        }

        public Game() { }

        /// <summary>
        /// Инициализация игры
        /// </summary>
        /// <param name="form"></param>
        public void Init(Form form) {
            Graphics g = form.CreateGraphics();
            f = form;
            _context = BufferedGraphicsManager.Current;
            

            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            FieldConstraint = new Constraint(0, Width, 0, Height);

            renderer = new Timer { Interval = 1 };
            renderer.Start();
            renderer.Tick += OnUpdate;


            asteroidsRespawnTime = 0;
            maxAsteroidCount = 10;

            score = 0;
            UI = new GameUI();
            Load();
            UI.Init();

            player.OnDie += GameOver;
        }

        /// <summary>
        /// Завершает игру
        /// </summary>
        private void GameOver()
        {
            renderer.Stop();
            Buffer.Graphics.DrawString("Игра окончена", new Font(FontFamily.GenericSansSerif, 24.0f, FontStyle.Bold), Brushes.AliceBlue, new Point(Width/2-50, Height/2));
            Timer gameOver = new Timer { Interval = 5000 };
            gameOver.Tick += CloseApplication;
            gameOver.Start();
        }

        private void CloseApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }



        /// <summary>
        /// Отрисовывает игровые объекты
        /// </summary>
        public void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            for (int i = 0; i < gameObjects.Count; i++) gameObjects[i].Draw();
            UI.Draw();
            player.Draw();
            Buffer.Render();            
        }

        /// <summary>
        /// Получает позицию курсора и приводит ее к клиентским координатам
        /// </summary>
        /// <returns>Позиция курсора в клиентских координатах</returns>
        Point GetCursorPos()
        {
            Point cursorPos = Cursor.Position;
            cursorPos = (f as Control).PointToClient(cursorPos);
            return cursorPos;
        }

        /// <summary>
        /// Обновляет позиции объектов
        /// </summary>
        public void Update()
        {
            asteroidsCount = gameObjects.FindAll(delegate (GameObject obj)
            {
                   return obj.GetType() == typeof(Asteroid);
            }).Count;

            foreach (GameObject go in gameObjects)
                go.Update();
            player.Move(GetCursorPos());
            SpawnAsteroids();
        }

        /// <summary>
        /// Спавнит астероиды если их меньше максимального количества
        /// </summary>
        private void SpawnAsteroids()
        {
            if (asteroidsRespawnTime <= 0 && asteroidsCount < maxAsteroidCount)
            {
                gameObjects.Add(new Asteroid());
                asteroidsRespawnTime = Rnd.Next(0, 3);
            }
            else --asteroidsRespawnTime;
        }

        /// <summary>
        /// Загружает игровые объекты
        /// </summary>
        public void Load()
        {

            player = new Ship();

            gameObjects = new List<GameObject>();

            for (int i = 0; i < 20; i++)
            {
                gameObjects.Add(new Star());
            }
            for (int i = 0; i < 1; i++)
            {
                gameObjects.Add(new Planet());
            }
        }



        /// <summary>
        /// Обработчик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUpdate(object sender, EventArgs e)
        {
            if (Buffer != null)
            {
                Update();
                Draw();
                ClearObjects();
            }
        }

        /// <summary>
        /// Удаляет все объекты помеченные к удалению
        /// </summary>
        void ClearObjects()
        {
            gameObjects.RemoveAll(x=>x.Destroyed);
        }

        /// <summary>
        /// Добавляет объект в игру
        /// </summary>
        /// <param name="obj"></param>
        public void AddObjects(GameObject obj)
        {
            gameObjects.Add(obj);
        }

        /// <summary>
        /// Добавляет коллекцию объектов в игру
        /// </summary>
        /// <param name="objs"></param>
        public void AddObjects(List<GameObject> objs)
        {
            gameObjects.AddRange(objs);
        }

        /// <summary>
        /// Увеличивает счет
        /// </summary>
        /// <param name="value">Значение</param>
        public void SetScore(int value)
        {
            score += value;
            ScoreChanged();
        }

    }
}
