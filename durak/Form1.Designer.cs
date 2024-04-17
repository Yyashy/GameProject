//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)


namespace durak
{
    partial class Form1
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
            this.startButton = new System.Windows.Forms.Button();
            this.ruleButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.IndianRed;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("French Script MT", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(332, 139);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(222, 73);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.startButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.startButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // ruleButton
            // 
            this.ruleButton.BackColor = System.Drawing.Color.IndianRed;
            this.ruleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ruleButton.Font = new System.Drawing.Font("French Script MT", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruleButton.ForeColor = System.Drawing.Color.White;
            this.ruleButton.Location = new System.Drawing.Point(332, 233);
            this.ruleButton.Name = "ruleButton";
            this.ruleButton.Size = new System.Drawing.Size(222, 73);
            this.ruleButton.TabIndex = 1;
            this.ruleButton.Text = "Game Rules";
            this.ruleButton.UseVisualStyleBackColor = false;
            this.ruleButton.Click += new System.EventHandler(this.ruleButton_Click);
            this.ruleButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.ruleButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.IndianRed;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("French Script MT", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.White;
            this.quitButton.Location = new System.Drawing.Point(332, 329);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(222, 73);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quit Game";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            this.quitButton.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.quitButton.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 71.99999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(758, 123);
            this.label1.TabIndex = 3;
            this.label1.Text = "Durak Game";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.ruleButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button ruleButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label1;
    }
}

