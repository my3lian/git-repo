using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        Game gameForm;
        protected static Random Rnd { get => new Random((int)DateTime.Now.Ticks & 0x0000FFFF); }
        public Game GameForm
        {
            get
            {
                return gameForm;
            }
            private set
            {
                gameForm = value;
            }
        }

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
            GameForm = Program.Game;
            Pos = new Point(0, Rnd.Next(0, GameForm.FieldConstraint.Top));
        }

        public GameObject(Point pos)
        {
            GameForm = Program.Game;
            Pos = pos;
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
            GameForm.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление позиции объекта
        /// </summary>
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = GameForm.Width + Size.Width;
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
            
            int X = Rnd.Next(0, GameForm.FieldConstraint.Right);
            Thread.Sleep(1);
            int Y = Rnd.Next(0, GameForm.FieldConstraint.Bottom);
            Pos = new Point(X, Y);

            int size = Rnd.Next(1, 15);
            Size = new Size(size, size);
            Dir = new Point(size, 0);
            Image = Resources.StarsSkins[Rnd.Next(0, Resources.StarsSkins.Count)];
        }

        public override void Draw()
        {
            GameForm.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y , Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos = new Point(GameForm.FieldConstraint.Right, Rnd.Next(0, GameForm.FieldConstraint.Bottom)); 
        }

    }

    /// <summary>
    /// Класс реализующий объект "Планета"
    /// </summary>
    class Planet : GameObject
    {
        public Planet() : base()
        {
            int size = Rnd.Next(300, 400);
            Size = new Size(size, size);
            Pos = new Point(Rnd.Next(0, GameForm.FieldConstraint.Right), Rnd.Next(0, GameForm.FieldConstraint.Bottom));
            Dir = new Point(size/200, 0);
            
            Image = Resources.PlanetsSkins[Rnd.Next(0, Resources.PlanetsSkins.Count)];
        }

        public override void Draw()
        {
            GameForm.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < -Size.Width) Pos.X = GameForm.Width + Size.Width;
        }
    }

    /// <summary>
    /// Класс реализующий объект "Снаряд"
    /// </summary>
    class Projectile : GameObject, ICloneable
    {
        public int Speed { get; set; }

        public int Damage { get; private set; }
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

        public Projectile(int damage, int speed, Size size, Image image)
        {
            Damage = damage;
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
            GameForm.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Speed;
            if (Pos.X > GameForm.Width) destroyed = true;
        }

        public object Clone()
        {
            return new Projectile(this.Damage, this.Speed, this.Size, this.Image);
        }

        public void SetPos(Point pos)
        {
            Pos = pos;
        }
    }

    class Asteroid : GameObject, IEnemy, IDroper
    {
        int hp;
        int damage;
        public GameObject item;
        int points;

        public Asteroid() : base()
        {
            Pos = new Point(GameForm.FieldConstraint.Right + Size.Width, Rnd.Next(0, GameForm.FieldConstraint.Bottom));
            int size = Rnd.Next(30, 100);
            Size = new Size(size, size);
            Dir = new Point(size / 10, 0);
            Image = Resources.AsteroidsSkins[Rnd.Next(0, Resources.AsteroidsSkins.Count)];
            hp = 2 * size;
            damage =  size / 2;
            points = size * 2;

        }

        public int Hp { get => hp; }
        public int Damage { get => damage; }
        public GameObject Item { get => item; set => item = value; }

        public int Points { get => points; }

        public override void Draw()
        {
            
            foreach (GameObject go in GameForm.gameObjects)
            {
                if(go.GetType() == typeof(Projectile))
                {
                    if (Collision(go))
                    {
                        System.Media.SystemSounds.Asterisk.Play();

                        Hurt((go as Projectile).Damage);
                        go.Destroyed = true;
                    }
                }    
            }
            if (Collision(GameForm.player)) GameForm.player.Hurt(damage);
            if (hp < 0)
            {
                Drop();
                Destroyed = true;
                GameForm.SetScore(points);
            }

            GameForm.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        

        public void Hurt(int n) => hp -= n;


        public void SetDrop()
        {
            if (Rnd.Next(0, 100) < 20)
                item = new Battery(Pos);
        }

        public void Drop()
        {
            SetDrop();
            if (Item != null)
                GameForm.AddObjects(Item);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < -Size.Width) destroyed = true;
        }
    }


    class Battery : GameObject
    {
        int energy = 50;

        public Battery (Point pos) : base(pos)
        {
            Size = new Size(30, 30);
            Dir = new Point(10, 0);
            Image = Resources.BatterySkins.First();
        }


        public override void Draw()
        {

            if (Collision(GameForm.player))
            {
                GameForm.player.Heal(energy);
                destroyed = true;
            }

            GameForm.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < -Size.Width) destroyed = true;
        }

    }
}
