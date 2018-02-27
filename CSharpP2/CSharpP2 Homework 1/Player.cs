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

        public Point WeaponSlot {
            get
            {
                return new Point(Pos.X + Size.Width, Pos.Y + Size.Height / 2);
            }
        }


        public Weapon Weapon { get; private set; }

        public Action Shoot { private get; set; }
        public int Energy { get; private set; }

        public void EnergyLow(int n) => Energy += n;
        public void EnergyAdd(int n) => Energy += n;

        public Armory Armory { get; private set; }

        public Player()
        { 
            Pos = new Point(100, 100);
            Size = new Size(96, 58);
            MoveSpeed = 10;
            Image = Resources.PlayerSkins[Game.rnd.Next(0, Resources.PlayerSkins.Count)];
            Armory = new Armory();
            Weapon = Armory.Weapons[WeaponTypes.Laser];
            Weapon.WeaponHolder = this;
            ChangeWeapon();

        }

        public void ChangeWeapon()
        {
            Shoot += Weapon.Shoot;
        }

        public void AttachWeaponToSlot()
        {

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

        public void ShootCurrentWeapon (object sender, MouseEventArgs e)
        {
            Shoot();
        }
    }
}
