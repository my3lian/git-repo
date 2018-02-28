using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpP2_Homework_1
{
    class GameUI
    {
        public Game GameForm { get; private set; }

        public GameUI()
        {
            GameForm = Program.Game;
            GameForm.player.EnergyChanged += Update;

        }

        private void Update()
        {
            throw new NotImplementedException();
        }
    }

    class UIObject
    {
        protected Point pos;
        protected Size size;



        public virtual void Draw() {

        }
        void Update() { }



        
    }

    class EnergyBar : UIObject
    {
        public override void Draw ()
        {
            GameForm.Buffer.Graphics.DrawLine(new Pen(Color.White, 10), Pos, new Point(Pos.X + value));
        }
    }
}
