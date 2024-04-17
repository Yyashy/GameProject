//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)


using System.Windows.Forms;

namespace durak
{
    public class RotatablePictureBox : PictureBox
    {
        public float RotationAngle { get; set; } = 0;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform((float)this.Width / 2, (float)this.Height / 2);
            e.Graphics.RotateTransform(RotationAngle);
            e.Graphics.TranslateTransform(-(float)this.Width / 2, -(float)this.Height / 2);

            base.OnPaint(e);
        }
    }
}
