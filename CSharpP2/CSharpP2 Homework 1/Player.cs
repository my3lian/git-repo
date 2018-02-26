using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpP2_Homework_1
{
    class Player : GameObject
    {
        const int MAXSPEED = 50;
        protected int MoveSpeed;
        static bool reloaded;
        Timer reloader;

        public Player()
        { 
            Pos = new Point(100, 100);
            Size = new Size(96, 58);
            MoveSpeed = 10;
            Image = Resources.PlayerSkins[Game.rnd.Next(0, Resources.PlayerSkins.Count)];

            reloader = new Timer { Interval = 1000 };
            reloader.Start();
            reloader.Tick += Reload;
        }

        private void Reload(object sender, EventArgs e)
        {
            reloaded = true;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public void Move(Point cursorPos)
        {
            Pos = cursorPos;
            /*if (cursorPos != Pos)
            {
                if(cursorPos.X < Pos.X)
                    Pos.X -= MoveSpeed;
                if (cursorPos.X > Pos.X)
                    Pos.X += MoveSpeed;
                if (cursorPos.Y < Pos.Y)
                    Pos.Y -= MoveSpeed;
                if (cursorPos.Y > Pos.Y)
                    Pos.Y += MoveSpeed;
            }*/
            if (Pos.X > Game.FieldConstraint.Right) Pos.X = Game.FieldConstraint.Right;
            if (Pos.X < Game.FieldConstraint.Left) Pos.X = Game.FieldConstraint.Left;
            if (Pos.Y > Game.FieldConstraint.Bottom) Pos.Y = Game.FieldConstraint.Bottom;
            if (Pos.Y < Game.FieldConstraint.Top) Pos.Y = Game.FieldConstraint.Top;

        }

        public void Shoot (object sender, MouseEventArgs e)
        {
            if (reloaded)
            {
               // Game.projectile = new Projectile(new Point(Pos.X, Pos.Y + Size.Height/2), Point.Empty, new Size(10, 10), "Laser_Red.png");
               Game.AddObjects(new Projectile(new Point(Pos.X, Pos.Y), Point.Empty, new Size(10, 10)));
               Game.AddObjects(new Projectile(new Point(Pos.X, Pos.Y+Size.Height), Point.Empty, new Size(10, 10)));
               reloaded = false;
            }
        }
    }
}
