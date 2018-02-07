namespace GameMultiplier
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbCurrent = new System.Windows.Forms.Label();
            this.btnIncrement = new System.Windows.Forms.Button();
            this.btnMult = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlMainMenu = new System.Windows.Forms.Panel();
            this.lbForeword = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbFinish = new System.Windows.Forms.Label();
            this.btnEndo = new System.Windows.Forms.Button();
            this.lbStepsCount = new System.Windows.Forms.Label();
            this.pnlMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCurrent
            // 
            this.lbCurrent.AutoSize = true;
            this.lbCurrent.Location = new System.Drawing.Point(192, 120);
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.Size = new System.Drawing.Size(35, 13);
            this.lbCurrent.TabIndex = 0;
            this.lbCurrent.Text = "label1";
            // 
            // btnIncrement
            // 
            this.btnIncrement.Location = new System.Drawing.Point(95, 175);
            this.btnIncrement.Name = "btnIncrement";
            this.btnIncrement.Size = new System.Drawing.Size(75, 23);
            this.btnIncrement.TabIndex = 1;
            this.btnIncrement.Text = "+1";
            this.btnIncrement.UseVisualStyleBackColor = true;
            this.btnIncrement.Click += new System.EventHandler(this.btnIncrement_Click);
            // 
            // btnMult
            // 
            this.btnMult.Location = new System.Drawing.Point(257, 175);
            this.btnMult.Name = "btnMult";
            this.btnMult.Size = new System.Drawing.Size(75, 23);
            this.btnMult.TabIndex = 2;
            this.btnMult.Text = "x2";
            this.btnMult.UseVisualStyleBackColor = true;
            this.btnMult.Click += new System.EventHandler(this.btnMult_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(176, 175);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.AutoSize = true;
            this.pnlMainMenu.Controls.Add(this.lbForeword);
            this.pnlMainMenu.Controls.Add(this.btnStart);
            this.pnlMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMainMenu.Name = "pnlMainMenu";
            this.pnlMainMenu.Size = new System.Drawing.Size(424, 267);
            this.pnlMainMenu.TabIndex = 4;
            // 
            // lbForeword
            // 
            this.lbForeword.AutoSize = true;
            this.lbForeword.Location = new System.Drawing.Point(16, 13);
            this.lbForeword.Name = "lbForeword";
            this.lbForeword.Size = new System.Drawing.Size(35, 13);
            this.lbForeword.TabIndex = 0;
            this.lbForeword.Text = "label1";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(176, 146);
            this.btnStart.Name = "btnStart";
            this.btnStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Play";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbFinish
            // 
            this.lbFinish.AutoSize = true;
            this.lbFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFinish.Location = new System.Drawing.Point(176, 49);
            this.lbFinish.Name = "lbFinish";
            this.lbFinish.Size = new System.Drawing.Size(51, 20);
            this.lbFinish.TabIndex = 4;
            this.lbFinish.Text = "label1";
            // 
            // btnEndo
            // 
            this.btnEndo.Location = new System.Drawing.Point(176, 205);
            this.btnEndo.Name = "btnEndo";
            this.btnEndo.Size = new System.Drawing.Size(75, 23);
            this.btnEndo.TabIndex = 2;
            this.btnEndo.Text = "Endo";
            this.btnEndo.UseVisualStyleBackColor = true;
            this.btnEndo.Click += new System.EventHandler(this.btnEndo_Click);
            // 
            // lbStepsCount
            // 
            this.lbStepsCount.AutoSize = true;
            this.lbStepsCount.Location = new System.Drawing.Point(0, 0);
            this.lbStepsCount.Name = "lbStepsCount";
            this.lbStepsCount.Size = new System.Drawing.Size(35, 13);
            this.lbStepsCount.TabIndex = 2;
            this.lbStepsCount.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 267);
            this.Controls.Add(this.pnlMainMenu);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnMult);
            this.Controls.Add(this.btnIncrement);
            this.Controls.Add(this.lbCurrent);
            this.Controls.Add(this.lbFinish);
            this.Controls.Add(this.btnEndo);
            this.Controls.Add(this.lbStepsCount);
            this.Name = "Form1";
            this.Text = "Multiplier";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMainMenu.ResumeLayout(false);
            this.pnlMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCurrent;
        private System.Windows.Forms.Button btnIncrement;
        private System.Windows.Forms.Button btnMult;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlMainMenu;
        private System.Windows.Forms.Label lbForeword;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbFinish;
        private System.Windows.Forms.Button btnEndo;
        private System.Windows.Forms.Label lbStepsCount;
    }
}

