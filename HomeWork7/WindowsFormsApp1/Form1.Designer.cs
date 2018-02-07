namespace WindowsFormsApp1
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
            this.tbEnter = new System.Windows.Forms.TextBox();
            this.lbEnter = new System.Windows.Forms.Label();
            this.lbStepsCount = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbEnter
            // 
            this.tbEnter.Location = new System.Drawing.Point(94, 134);
            this.tbEnter.Name = "tbEnter";
            this.tbEnter.Size = new System.Drawing.Size(100, 20);
            this.tbEnter.TabIndex = 0;
            this.tbEnter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEnter_KeyPress);
            // 
            // lbEnter
            // 
            this.lbEnter.AutoSize = true;
            this.lbEnter.Location = new System.Drawing.Point(91, 118);
            this.lbEnter.Name = "lbEnter";
            this.lbEnter.Size = new System.Drawing.Size(66, 13);
            this.lbEnter.TabIndex = 1;
            this.lbEnter.Text = "Ваше число";
            // 
            // lbStepsCount
            // 
            this.lbStepsCount.AutoSize = true;
            this.lbStepsCount.Location = new System.Drawing.Point(209, 35);
            this.lbStepsCount.Name = "lbStepsCount";
            this.lbStepsCount.Size = new System.Drawing.Size(0, 13);
            this.lbStepsCount.TabIndex = 2;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Location = new System.Drawing.Point(94, 161);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(0, 13);
            this.lbMessage.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbStepsCount);
            this.Controls.Add(this.lbEnter);
            this.Controls.Add(this.tbEnter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEnter;
        private System.Windows.Forms.Label lbEnter;
        private System.Windows.Forms.Label lbStepsCount;
        private System.Windows.Forms.Label lbMessage;
    }
}

