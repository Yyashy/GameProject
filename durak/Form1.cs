//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)


using System;
using System.Drawing;
using System.Windows.Forms;

namespace durak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              
           
            startButton.FlatStyle = FlatStyle.Flat;
           
            startButton.ForeColor = Color.White;
            startButton.FlatAppearance.BorderSize = 0; // Remove borderstartButton.Size = new Size(200, 50);
           
            startButton.FlatAppearance.BorderSize = 0; // Remove border

            centerButtons();
        }

        private void centerButtons()
        {
           
            int verticalSpacing = 30; // Space between buttons

            int startX = (this.ClientSize.Width - startButton.Width) / 2;
            int startY = (this.ClientSize.Height - (3 * startButton.Height + 2 * verticalSpacing)) / 2;

            // Start Button
            startButton.Location = new Point(startX, startY);
            // Other button properties...

            // Rules Button
            
            ruleButton.Location = new Point(startX, startY + startButton.Height + verticalSpacing);
            // Other button properties...

            // Quit Button
          
            quitButton.Location = new Point(startX, startY + 2 * (startButton.Height + verticalSpacing));
            // Other button properties...
            label1.Top = 10;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;

        }
        private void startButton_Click(object sender, EventArgs e)
        {
            GameForm gameform = new GameForm();
            gameform.Show();
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Green;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.IndianRed;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ruleButton_Click(object sender, EventArgs e)
        {
            ruleForm rulesForm = new ruleForm();
            rulesForm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
