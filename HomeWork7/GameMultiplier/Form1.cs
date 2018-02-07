using System;

using System.Windows.Forms;
using static GameMultiplier.Program;

namespace GameMultiplier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }





        public void FormRefresh()
        {
            lbCurrent.Text = multiplier.Current.ToString();
            lbStepsCount.Text = $"Шагов: {multiplier.StepsCount}";
            
            Refresh();
            CheckScore();
        }

        private void btnIncrement_Click(object sender, EventArgs e)
        {
            multiplier.Inc();
            FormRefresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbForeword.Text = Multiplier.FOREWORD;
            FormRefresh();
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            multiplier.IncX2();
            FormRefresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            multiplier.Reset();
            FormRefresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnEndo_Click(object sender, EventArgs e)
        {
            multiplier.Endo();
            FormRefresh();
        }

        void Start()
        {
            lbCurrent.Text = multiplier.Current.ToString();
            lbFinish.Text = multiplier.Finish.ToString();
            pnlMainMenu.Visible = false;

            MessageBox.Show($"Нужно получить число: {multiplier.Finish} ");
        }

        void CheckScore ()
        {

            if (multiplier.IsWin)            
                if (MessageBox.Show($"У тебя получилось! Число шагов: {multiplier.StepsCount} ", "Победа!", MessageBoxButtons.OK) == DialogResult.OK)
                    Application.Exit();

            if (multiplier.IsLoose)
                if (MessageBox.Show("Упс... Перебор", "Ты проиграл", MessageBoxButtons.OK) == DialogResult.OK)
                    Application.Exit();
        }
    }
}
