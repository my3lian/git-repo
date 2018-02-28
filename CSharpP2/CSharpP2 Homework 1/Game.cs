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
        

        private BufferedGraphicsContext _context;
        public BufferedGraphics Buffer { get; private set; }
        public List<GameObject> gameObjects;
        public Player player;
        public Form f;
        static Timer renderer;
        public Random Rnd { get => new Random((int)DateTime.Now.Ticks & 0x0000FFFF); }

        

        int asteroidsRespawnTime;
        int maxAsteroidCount;
        int asteroidsCount;

        public Constraint FieldConstraint { get; private set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Game() { }
        public void Init(Form form) {
            f = form;
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.Width;
            Height = form.Height;
            FieldConstraint = new Constraint(0, Width, 0, Height);

            asteroidsRespawnTime = 0;
            maxAsteroidCount = 10;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            renderer = new Timer { Interval = 10 };
            renderer.Start();
            renderer.Tick += OnFrameUpdate;
        }

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


        /// <summary>
        /// Отрисовывает игровые объекты
        /// </summary>
        public void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            for (int i = 0; i < gameObjects.Count; i++) gameObjects[i].Draw();
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
            this.asteroidsCount = gameObjects.FindAll(delegate (GameObject obj)
           {
               return obj.GetType() == typeof(Asteroid);
           }).Count;

            foreach (GameObject go in gameObjects)
                go.Update();
            player.Move(GetCursorPos());

            SpawnAsteroids();

        }

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

            player = new Player();

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
        private void OnFrameUpdate(object sender, EventArgs e)
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

    }
}
