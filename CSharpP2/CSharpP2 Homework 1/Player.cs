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
        public event Action EnergyChanged;

        const int MAXSPEED = 50;
        protected int MoveSpeed;
        bool isImmortal = false;
        public int MaxEnergy { get; private set; }

        public bool isVisible = true;

        Timer visibility = new Timer { Interval = 100 };
        Timer immortal = new Timer { Interval = 3000 };

        public Point WeaponSlot {
            get
            {
                return new Point(Pos.X + Size.Width, Pos.Y + Size.Height / 2);
            }
        }

        public Weapon Weapon { get; private set; }

        public Action Shoot { private get; set; }
        public int Energy { get; private set; }

        public void Hurt(int n)
        {
            if (!isImmortal)
            {
                SetImmortality();
                Energy = Energy < 0 ? Energy - n : 0;
                EnergyChanged();
            }
        }

        public void Heal(int n)
        {
            Energy = Energy < MaxEnergy ? Energy + n : 0;
            EnergyChanged();
        }

        public void SetImmortality()
        {
            Console.WriteLine("Бессмертие активировано");
            isImmortal = true;
            immortal.Start();
            visibility.Start();
        }

        public void EnergyAdd(int n) => Energy += n;

        public Armory Armory { get; private set; }

        public Player()
        { 
            Pos = new Point(100, 100);
            Size = new Size(96, 58);
            MoveSpeed = 10;
            MaxEnergy = 100;
            Energy = MaxEnergy;
            Image = Resources.PlayerSkins[GameForm.Rnd.Next(0, Resources.PlayerSkins.Count)];
            Armory = new Armory();
            Weapon = Armory.Weapons[WeaponTypes.Laser];
            Weapon.WeaponHolder = this;
            ChangeWeapon();
            Program.form.MouseDown += ShootCurrentWeapon;

            immortal.Tick += ResetImmortality;
            visibility.Tick += SetVisibility;
        }

        private void SetVisibility(object sender, EventArgs e)
        {
            isVisible = !isVisible;
        }

        private void ResetImmortality(object sender, EventArgs e)
        {
            Console.WriteLine("Бессмертие закончилось");
            immortal.Stop();
            visibility.Stop();
            isVisible = true;
            isImmortal = false;
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
            if(isVisible)
                GameForm.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public void Move(Point cursorPos)
        {
            Pos = cursorPos;
            if (Pos.X > GameForm.FieldConstraint.Right) Pos.X = GameForm.FieldConstraint.Right;
            if (Pos.X < GameForm.FieldConstraint.Left) Pos.X = GameForm.FieldConstraint.Left;
            if (Pos.Y > GameForm.FieldConstraint.Bottom) Pos.Y = GameForm.FieldConstraint.Bottom;
            if (Pos.Y < GameForm.FieldConstraint.Top) Pos.Y = GameForm.FieldConstraint.Top;

        }

        public void ShootCurrentWeapon (object sender, MouseEventArgs e)
        {
            Shoot();
        }


    }
}
