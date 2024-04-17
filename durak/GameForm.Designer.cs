//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)


namespace durak
{
    partial class GameForm
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
            this.playerHandPanel = new System.Windows.Forms.Panel();
            this.computerHandPanel = new System.Windows.Forms.Panel();
            this.tableHandPanel = new System.Windows.Forms.Panel();
            this.btnFinish = new System.Windows.Forms.Button();
            this.finishedCardPanel = new System.Windows.Forms.Panel();
            this.btnTakeCards = new System.Windows.Forms.Button();
            this.playerStatus = new System.Windows.Forms.Panel();
            this.computerStatus = new System.Windows.Forms.Panel();
            this.statuslabel = new System.Windows.Forms.Label();
            this.deckstatus = new System.Windows.Forms.Label();
            this.trumplabel = new System.Windows.Forms.Label();
            this.trumpPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // playerHandPanel
            // 
            this.playerHandPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerHandPanel.Location = new System.Drawing.Point(12, 381);
            this.playerHandPanel.Name = "playerHandPanel";
            this.playerHandPanel.Size = new System.Drawing.Size(956, 165);
            this.playerHandPanel.TabIndex = 1;
            this.playerHandPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.playerHandPanel_Paint);
            // 
            // computerHandPanel
            // 
            this.computerHandPanel.BackColor = System.Drawing.Color.Transparent;
            this.computerHandPanel.Location = new System.Drawing.Point(13, 13);
            this.computerHandPanel.Name = "computerHandPanel";
            this.computerHandPanel.Size = new System.Drawing.Size(450, 100);
            this.computerHandPanel.TabIndex = 2;
            // 
            // tableHandPanel
            // 
            this.tableHandPanel.Location = new System.Drawing.Point(438, 185);
            this.tableHandPanel.Name = "tableHandPanel";
            this.tableHandPanel.Size = new System.Drawing.Size(200, 100);
            this.tableHandPanel.TabIndex = 3;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinish.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnFinish.Location = new System.Drawing.Point(438, 305);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(119, 45);
            this.btnFinish.TabIndex = 4;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // finishedCardPanel
            // 
            this.finishedCardPanel.Location = new System.Drawing.Point(123, 185);
            this.finishedCardPanel.Name = "finishedCardPanel";
            this.finishedCardPanel.Size = new System.Drawing.Size(200, 100);
            this.finishedCardPanel.TabIndex = 5;
            // 
            // btnTakeCards
            // 
            this.btnTakeCards.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnTakeCards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeCards.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeCards.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTakeCards.Location = new System.Drawing.Point(572, 305);
            this.btnTakeCards.Name = "btnTakeCards";
            this.btnTakeCards.Size = new System.Drawing.Size(169, 45);
            this.btnTakeCards.TabIndex = 6;
            this.btnTakeCards.Text = "Take Cards";
            this.btnTakeCards.UseVisualStyleBackColor = false;
            this.btnTakeCards.Click += new System.EventHandler(this.btnTakeCards_Click);
            // 
            // playerStatus
            // 
            this.playerStatus.Location = new System.Drawing.Point(13, 305);
            this.playerStatus.Name = "playerStatus";
            this.playerStatus.Size = new System.Drawing.Size(258, 45);
            this.playerStatus.TabIndex = 7;
            // 
            // computerStatus
            // 
            this.computerStatus.Location = new System.Drawing.Point(758, 305);
            this.computerStatus.Name = "computerStatus";
            this.computerStatus.Size = new System.Drawing.Size(221, 45);
            this.computerStatus.TabIndex = 8;
            // 
            // statuslabel
            // 
            this.statuslabel.AutoSize = true;
            this.statuslabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statuslabel.ForeColor = System.Drawing.Color.GhostWhite;
            this.statuslabel.Location = new System.Drawing.Point(737, 109);
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(115, 37);
            this.statuslabel.TabIndex = 9;
            this.statuslabel.Text = "Status";
            // 
            // deckstatus
            // 
            this.deckstatus.AutoSize = true;
            this.deckstatus.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deckstatus.ForeColor = System.Drawing.Color.GhostWhite;
            this.deckstatus.Location = new System.Drawing.Point(659, 167);
            this.deckstatus.Name = "deckstatus";
            this.deckstatus.Size = new System.Drawing.Size(320, 37);
            this.deckstatus.TabIndex = 10;
            this.deckstatus.Text = "Cards Left on Deck:";
            // 
            // trumplabel
            // 
            this.trumplabel.AutoSize = true;
            this.trumplabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trumplabel.ForeColor = System.Drawing.Color.GhostWhite;
            this.trumplabel.Location = new System.Drawing.Point(659, 215);
            this.trumplabel.Name = "trumplabel";
            this.trumplabel.Size = new System.Drawing.Size(320, 37);
            this.trumplabel.TabIndex = 11;
            this.trumplabel.Text = "Cards Left on Deck:";
            // 
            // trumpPanel
            // 
            this.trumpPanel.Location = new System.Drawing.Point(13, 138);
            this.trumpPanel.Name = "trumpPanel";
            this.trumpPanel.Size = new System.Drawing.Size(200, 100);
            this.trumpPanel.TabIndex = 12;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(981, 549);
            this.Controls.Add(this.trumpPanel);
            this.Controls.Add(this.trumplabel);
            this.Controls.Add(this.deckstatus);
            this.Controls.Add(this.statuslabel);
            this.Controls.Add(this.computerStatus);
            this.Controls.Add(this.playerStatus);
            this.Controls.Add(this.btnTakeCards);
            this.Controls.Add(this.finishedCardPanel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.tableHandPanel);
            this.Controls.Add(this.computerHandPanel);
            this.Controls.Add(this.playerHandPanel);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel playerHandPanel;
        private System.Windows.Forms.Panel computerHandPanel;
        private System.Windows.Forms.Panel tableHandPanel;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Panel finishedCardPanel;
        private System.Windows.Forms.Button btnTakeCards;
        private System.Windows.Forms.Panel playerStatus;
        private System.Windows.Forms.Panel computerStatus;
        private System.Windows.Forms.Label statuslabel;
        private System.Windows.Forms.Label deckstatus;
        private System.Windows.Forms.Label trumplabel;
        private System.Windows.Forms.Panel trumpPanel;
    }
}