using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow gw = new GameWindow();
            Application.Run(gw);
        }


        void CreateMainWindow()
        {

        }
    }

    class GameWindow : Form {
        public GameWindow ()
        {
            Text = "Multiplier";
            Width = 2;
            Click += gwClicker;
            Paint += gwPainter;

        }

        void gwClicker(object objSrc, EventArgs args)
        {

        }

        void gwPainter(object objSrc, PaintEventArgs args)
        {
            Graphics grfx = args.Graphics;
            grfx.DrawString("Hello WF", Font, SystemBrushes.ControlText, 0, 0);
        }
    }

}
