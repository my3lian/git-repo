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
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static List<GameObject> gameObjects;
        public static Player player;
        public static Form f;
        static Timer timer;
        public static Random rnd = new Random((int)DateTime.Now.Ticks);

        static int asteroidsRespawnTime;
        static int maxAsteroidCount;
        static int asteroidsCount;

        public static Constraint FieldConstraint { get; private set; }

        public static int Width { get; set; }
        public static int Height { get; set; }


        static Game() { }

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
        /// Инициализирует экранную форму
        /// </summary>
        /// <param name="form">Инициализируемая форма</param>
        public static void Init(Form form)
        {
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



            form.MouseDown += player.Shoot;

            timer = new Timer { Interval = 10 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        /// <summary>
        /// Отрисовывает игровые объекты
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (GameObject go in gameObjects)
                go.Draw();
            player.Draw();
            Buffer.Render();

        }

        /// <summary>
        /// Получает позицию курсора и приводит ее к клиентским координатам
        /// </summary>
        /// <returns>Позиция курсора в клиентских координатах</returns>
        static Point GetCursorPos()
        {
            Point cursorPos = Cursor.Position;
            cursorPos = (f as Control).PointToClient(cursorPos);
            return cursorPos;
        }

        /// <summary>
        /// Обновляет позиции объектов
        /// </summary>
        public static void Update()
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

        private static void SpawnAsteroids()
        {
            if (asteroidsRespawnTime <= 0 && asteroidsCount < maxAsteroidCount)
            {
                gameObjects.Add(new Asteroid());
                asteroidsRespawnTime = rnd.Next(0, 3);
            }
            else --asteroidsRespawnTime;

        }

        /// <summary>
        /// Загружает игровые объекты
        /// </summary>
        public static void Load()
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
        private static void Timer_Tick(object sender, EventArgs e)
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
        static void ClearObjects()
        {
            for(int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].Destroyed)
                {
                    gameObjects[i].Dispose();
                    gameObjects.Remove(gameObjects[i]);
                    
                }    
            }
        }

        /// <summary>
        /// Добавляет объект в игру
        /// </summary>
        /// <param name="obj"></param>
        public static void AddObjects(GameObject obj)
        {
            gameObjects.Add(obj);
        }

        /// <summary>
        /// Добавляет коллекцию объектов в игру
        /// </summary>
        /// <param name="objs"></param>
        public static void AddObjects(List<GameObject> objs)
        {
            Game.gameObjects.AddRange(objs);
        }

    }
}
