using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpP2_Homework_1
{
    /// <summary>
    /// Реализует объект Корабль
    /// </summary>
    class Ship : GameObject
    {
        /// <summary>
        /// Событие возникающее когда изменяется значение энергии
        /// </summary>
        public event Action EnergyChanged;
        /// <summary>
        /// Событие возникающее когда корабль теряет всю энергию
        /// </summary>
        public event Action OnDie;
        /// <summary>
        /// Событие выстрел
        /// </summary>
        public Action Shoot { private get; set; }
        /// <summary>
        /// Скорость передвижения игрока
        /// </summary>
        int MoveSpeed;

        /// <summary>
        /// Флаг бессмертие
        /// </summary>
        bool isImmortal = false;
        /// <summary>
        /// Максимальное значение энергии корабля
        /// </summary>
        public int MaxEnergy { get; private set; }
        /// <summary>
        /// Оружейная
        /// </summary>
        public Armory Armory { get; private set; }
        /// <summary>
        /// Флаг видимость корабля
        /// </summary>
        public bool isVisible = true;

        /// <summary>
        /// Таймер видимости
        /// </summary>
        Timer visibility = new Timer { Interval = 100 };

        /// <summary>
        /// Таймер бессмертия
        /// </summary>
        Timer immortal = new Timer { Interval = 3000 };

        /// <summary>
        /// Слот для оружия
        /// </summary>
        public Point WeaponSlot {
            get
            {
                return new Point(Pos.X + Size.Width, Pos.Y + Size.Height / 2);
            }
        }

        /// <summary>
        /// Орудие
        /// </summary>
        public Weapon Weapon { get; private set; }

        /// <summary>
        /// Текущий уровень энергии корабля
        /// </summary>
        public int Energy { get; private set; }

        /// <summary>
        /// Создает экземпляр класса Ship
        /// </summary>
        public Ship()
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

        /// <summary>
        /// Уменьшает энергию
        /// </summary>
        /// <param name="n"></param>
        public void Hurt(int n)
        {
            if (!isImmortal)
            {
                SetImmortality();
                Energy = Energy > 0 ? Energy - n : 0;
                EnergyChanged();
            }
            if (Energy <= 0) OnDie();
        }

        /// <summary>
        /// Увеличивает энергию
        /// </summary>
        /// <param name="n"></param>
        public void Heal(int n)
        {
            Energy = Energy+n < MaxEnergy ? Energy + n : MaxEnergy;
            EnergyChanged();
        }


        /// <summary>
        /// Делает корабль бессмертным
        /// </summary>
        public void SetImmortality()
        {
            Console.WriteLine("Бессмертие активировано");
            isImmortal = true;
            immortal.Start();
            visibility.Start();
        }

        /// <summary>
        /// Делает невидимым
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetVisibility(object sender, EventArgs e)
        {
            isVisible = !isVisible;
        }
        /// <summary>
        /// Сбрасывает бессмертие
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetImmortality(object sender, EventArgs e)
        {
            Console.WriteLine("Бессмертие закончилось");
            immortal.Stop();
            visibility.Stop();
            isVisible = true;
            isImmortal = false;
        }

        /// <summary>
        /// Меняет орудие
        /// </summary>
        public void ChangeWeapon()
        {
            Shoot += Weapon.Shoot;
        }

        public void AttachWeaponToSlot()
        {

        }

        /// <summary>
        /// Отрисовывает корабль
        /// </summary>
        public override void Draw()
        {
            if(isVisible)
                GameForm.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        /// <summary>
        /// Перемещает корабль
        /// </summary>
        /// <param name="cursorPos">Позиция курсора</param>
        public void Move(Point cursorPos)
        {
            Pos = cursorPos;
            if (Pos.X > GameForm.FieldConstraint.Right) Pos.X = GameForm.FieldConstraint.Right;
            if (Pos.X < GameForm.FieldConstraint.Left) Pos.X = GameForm.FieldConstraint.Left;
            if (Pos.Y > GameForm.FieldConstraint.Bottom) Pos.Y = GameForm.FieldConstraint.Bottom;
            if (Pos.Y < GameForm.FieldConstraint.Top) Pos.Y = GameForm.FieldConstraint.Top;

        }

        /// <summary>
        /// Стреляет из текущего орудия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShootCurrentWeapon (object sender, MouseEventArgs e)
        {
            Shoot();
        }


    }
}
