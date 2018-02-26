using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpP2_Homework_1
{
    public static class Resources
    {
        static List<Image> playerSkins;
        static List<Image> asteroidsSkins;
        static List<Image> planetsSkins;
        static List<Image> starsSkins;

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

        static string pathToResources = Directory.GetCurrentDirectory() + "\\Resources\\Sprites";


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
