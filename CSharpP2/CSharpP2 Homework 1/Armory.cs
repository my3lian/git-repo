using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpP2_Homework_1
{
    class Armory
    {
        public Dictionary<WeaponTypes, Weapon> Weapons { get; private set; }

        public Armory() {
            Weapons = new Dictionary<WeaponTypes, Weapon>();
            Weapons.Add(WeaponTypes.Laser, new Weapon( 1, "Laser", new Projectile(50, 20,new System.Drawing.Size(100, 10), Resources.LaserSkins.First())));
            Weapons.Add(WeaponTypes.RocketLauncher, new Weapon( 100, "Laser", new Projectile(50, 20, new System.Drawing.Size(100, 10), Resources.LaserSkins.First())));
        } 



    }
}
