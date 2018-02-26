using System;
using System.Drawing;

namespace CSharpP2_Homework_1
{
    /// <summary>
    /// Класс, реализующий объекты главного меню
    /// </summary>
    class SplashScreenObjects
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Image Image;

        public SplashScreenObjects(Point pos, Point dir, Size size, String fileName)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > SplashScreen.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > SplashScreen.Height) Dir.Y = -Dir.Y;
        }
    }

    class SPStar : SplashScreenObjects
    {
        public SPStar(Point pos, Point dir, Size size, string fileName) : base(pos, dir, size, fileName) {
            Image = Resources.StarsSkins[Game.rnd.Next(0, Resources.StarsSkins.Count)];
        }

        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y , Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = SplashScreen.Width + Size.Width;
        }

    }
    
    class SPPlanet : SplashScreenObjects
    {
        public SPPlanet(Point pos, Point dir, Size size, string fileName) : base(pos, dir, size, fileName) {
            Image = Resources.PlanetsSkins[Game.rnd.Next(0, Resources.PlanetsSkins.Count)];
        }

        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = SplashScreen.Width + Size.Width;
        }
    }
}
