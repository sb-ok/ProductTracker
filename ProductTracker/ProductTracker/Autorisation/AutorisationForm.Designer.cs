namespace ProductTracker.Autorisation
{
    partial class AutorisationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginBox = new System.Windows.Forms.TextBox();
            this.pswBox = new System.Windows.Forms.TextBox();
            this.afButLog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(12, 25);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(164, 20);
            this.loginBox.TabIndex = 0;
            // 
            // pswBox
            // 
            this.pswBox.Location = new System.Drawing.Point(12, 67);
            this.pswBox.Name = "pswBox";
            this.pswBox.Size = new System.Drawing.Size(164, 20);
            this.pswBox.TabIndex = 1;
            // 
            // afButLog
            // 
            this.afButLog.Location = new System.Drawing.Point(197, 41);
            this.afButLog.Name = "afButLog";
            this.afButLog.Size = new System.Drawing.Size(75, 32);
            this.afButLog.TabIndex = 2;
            this.afButLog.Text = "Войти";
            this.afButLog.UseVisualStyleBackColor = true;
            this.afButLog.Click += new System.EventHandler(this.afButLog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Введите пароль:";
            // 
            // AutorisationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 102);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.afButLog);
            this.Controls.Add(this.pswBox);
            this.Controls.Add(this.loginBox);
            this.Name = "AutorisationForm";
            this.Text = "Вход в систему";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox pswBox;
        private System.Windows.Forms.Button afButLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

