using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpP2_Homework_1
{
    /// <summary>
    /// Класс реализующий базовый объект
    /// </summary>
    class GameObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        private Size size;
        protected Image Image;
        protected bool destroyed = false;
        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Destroyed
        {
            get
            {
                return destroyed;
            }
            set
            {
                destroyed = value;
            }
        }

        public Size Size { get => size; set => size = value; }

        public GameObject()
        {
            Pos = new Point(0, Game.rnd.Next(0, Game.FieldConstraint.Top));
        }

        public GameObject(Point pos, Point dir, Size size, String fileName)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\" + fileName);
        }

        public GameObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public Point GetPosition()
        {
            return Pos;
        }
        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление позиции объекта
        /// </summary>
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }     

        public void Dispose()
        {
            this.Image = null;
        }


        public bool Collision(ICollision obj)
        {
            if (obj != null)
             return obj.Rect.IntersectsWith(this.Rect);
            return false;
        }

    }

    /// <summary>
    /// Класс реализующий объект "Звезда"
    /// </summary>
    class Star : GameObject
    {
        public Star() : base() {
            Pos = new Point(Game.rnd.Next(0, Game.FieldConstraint.Right), Game.rnd.Next(0, Game.FieldConstraint.Bottom));
            int size = Game.rnd.Next(1, 15);
            Size = new Size(size, size);
            Dir = new Point(size, 0);
            Image = Resources.StarsSkins[Game.rnd.Next(0, Resources.StarsSkins.Count)];
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y , Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

    }

    /// <summary>
    /// Класс реализующий объект "Планета"
    /// </summary>
    class Planet : GameObject
    {
        public Planet() : base()
        {
            int size = Game.rnd.Next(300, 400);
            Size = new Size(size, size);
            Pos = new Point(Game.rnd.Next(0, Game.FieldConstraint.Right), Game.rnd.Next(0, Game.FieldConstraint.Bottom));
            Dir = new Point(size/200, 0);
            
            Image = Resources.PlanetsSkins[Game.rnd.Next(0, Resources.PlanetsSkins.Count)];
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < -Size.Width) Pos.X = Game.Width + Size.Width;
        }
    }

    /// <summary>
    /// Класс реализующий объект "Снаряд"
    /// </summary>
    class Projectile : GameObject, ICloneable
    {
        public int Speed { get; set; }
        Weapon weapon;
        public Weapon Weapon
        {
            get
            {
                return weapon;
            }
            set
            {
                weapon = value;
                Pos = weapon.Pos;
            }
        }

        public Projectile(int speed, Size size, Image image)
        {
            Speed = speed;
            Size = new Size(50, 10);
            Image = image; //Resources.LaserSkins[Game.rnd.Next(0, Resources.LaserSkins.Count)];
        }

        public void AttachToWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawLine(new Pen(Color.White, 2), Pos, new Point(Pos.X + 10, Pos.Y));
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Speed;
            if (Pos.X > Game.Width) destroyed = true;
        }

        public object Clone()
        {
            return new Projectile(this.Speed, this.Size, this.Image);
        }

        public void SetPos(Point pos)
        {
            Pos = pos;
        }
    }

    class Asteroid : GameObject
    {
        int respawnTime = Game.rnd.Next(1, 5);
        public Asteroid() : base()
        {
            Pos = new Point(Game.FieldConstraint.Right + Size.Width, Game.rnd.Next(0, Game.FieldConstraint.Bottom));
            int size = Game.rnd.Next(30, 100);
            Size = new Size(size, size);
            Dir = new Point(size / 10, 0);
            Image = Resources.AsteroidsSkins[Game.rnd.Next(0, Resources.AsteroidsSkins.Count)];
        }

        public override void Draw()
        {
            foreach (GameObject go in Game.gameObjects)
            {
                if(go.GetType() == typeof(Projectile))
                {
                    if (Collision(go))
                    {
                        Destroyed = true;
                        go.Destroyed = true;
                    }
                }
                
            }
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < -Size.Width) destroyed = true;
            int o = 10;
            o--;
            o = o - 1;
        }
    }
}
