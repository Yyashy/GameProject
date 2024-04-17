//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)


namespace durak
{
    partial class ruleForm
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
            this.rulesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rulesRichTextBox
            // 
            this.rulesRichTextBox.Location = new System.Drawing.Point(3, 1);
            this.rulesRichTextBox.Name = "rulesRichTextBox";
            this.rulesRichTextBox.Size = new System.Drawing.Size(841, 502);
            this.rulesRichTextBox.TabIndex = 0;
            this.rulesRichTextBox.Text = "";
            // 
            // ruleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(847, 504);
            this.Controls.Add(this.rulesRichTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ruleForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Durak Game Rules";
            this.Load += new System.EventHandler(this.ruleForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rulesRichTextBox;
    }
}