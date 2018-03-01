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
    /// Реализует объект-библиотеку ресурсов
    /// </summary>
    public static class Resources
    {
        /// <summary>
        /// Коллекция скинов игрока
        /// </summary>
        static List<Image> playerSkins;

        /// <summary>
        /// Коллекция скинов астероида
        /// </summary>
        static List<Image> asteroidsSkins;
        /// <summary>
        /// Коллекция скинов планеты
        /// </summary>
        static List<Image> planetsSkins;
        /// <summary>
        /// Коллекция скинов звезды
        /// </summary>
        static List<Image> starsSkins;
        /// <summary>
        /// Коллекция скинов лазера
        /// </summary>
        static List<Image> laserSkins;
        /// <summary>
        /// Коллекция скинов аптечки
        /// </summary>
        static List<Image> batterySkins;

        public static List<Image> PlayerSkins {
            get
            {
                if (playerSkins == null) {
                    playerSkins = new List<Image>();
                    LoadResources(playerSkins, "Player");
                    return playerSkins;
                }
                else
                {
                    return playerSkins;
                }
            }
        }

        public static List<Image> AsteroidsSkins
        {
            get
            {
                if (asteroidsSkins == null)
                {
                    asteroidsSkins = new List<Image>();
                    LoadResources(asteroidsSkins, "Asteroids");
                    return asteroidsSkins;
                }
                else
                {
                    return asteroidsSkins;
                }
            }
        }

        public static List<Image> PlanetsSkins
        {
            get
            {
                if (planetsSkins == null)
                {
                    planetsSkins = new List<Image>();
                    LoadResources(planetsSkins, "Planets");
                    return planetsSkins;
                }
                else
                {
                    return planetsSkins;
                }
            }
        }

        public static List<Image> StarsSkins
        {
            get
            {
                if (starsSkins == null)
                {
                    starsSkins = new List<Image>();
                    LoadResources(starsSkins, "Stars");
                    return starsSkins;
                }
                else
                {
                    return starsSkins;
                }
            }
        }
        public static List<Image> LaserSkins
        {
            get
            {
                if (laserSkins == null)
                {
                    laserSkins = new List<Image>();
                    LoadResources(laserSkins, "Projectiles");
                    return laserSkins;
                }
                else
                {
                    return laserSkins;
                }
            }
        }
        public static List<Image> BatterySkins
        {
            get
            {
                if (batterySkins == null)
                {
                    batterySkins = new List<Image>();
                    LoadResources(batterySkins, "Battery");
                    return batterySkins;
                }
                else
                {
                    return batterySkins;
                }
            }
        }

        /// <summary>
        /// Стандартный путь до ресурсов
        /// </summary>
        static string pathToResources = Directory.GetCurrentDirectory() + "\\Resources\\Sprites";

        /// <summary>
        /// Загружает ресурсы в коллекцию
        /// </summary>
        /// <param name="collection">Коллеция</param>
        /// <param name="type">Тип ресурсов</param>
        static void LoadResources(List<Image> collection, string type )
        {
            string [] files = Directory.GetFiles(pathToResources + $"\\{type}\\", "*.png");
            foreach (string fileName in files)
            {
                collection.Add(Image.FromFile(fileName));
            }        
        }





    }
}
