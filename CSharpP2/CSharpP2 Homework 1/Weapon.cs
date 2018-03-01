using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpP2_Homework_1
{
    class Weapon
    {        
        public int Damage { get; private set; }
        public int ProjectileSpd { get; private set; }
        public int FireRate { get; private set; }

        public Point Pos {
            get
            {
                return weaponHolder.WeaponSlot;
            }
        }
        public string Name { get; private set; }
        public Projectile Projectile { get; private set; }
        int timer = 0;


        Ship weaponHolder;
        public Ship WeaponHolder
        {
            private get
            {
                return weaponHolder;
            }
            set
            {
                weaponHolder = value;
            }
        }

        public Weapon( int fireRate, string name, Projectile projectile)
        {
            FireRate = fireRate;
            Name = name;
            Projectile = projectile;
        }

        public void Shoot()
        {
            Projectile.SetPos(Pos);
            if (timer < 0)
            {
                Projectile proj = Projectile.Clone() as Projectile;
                proj.AttachToWeapon(this);
                WeaponHolder.GameForm.AddObjects(proj);
                timer = FireRate;
            }
            else
            {
                timer--;
            }
        }
    }
}
