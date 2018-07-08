using System;
using System.Drawing;
using System.Windows.Forms;

namespace OP_Lab9_serpinsky
{
    public partial class SerpinskyForm : Form
    {
        private Graphics serpinsky;
        private Pen basicPen;

        public SerpinskyForm()
        {
            InitializeComponent();
        }

        private void BtnDrawSerpinsky_Click(object sender, EventArgs e)
        {
            serpinsky = this.CreateGraphics();
            serpinsky.Clear(Color.WhiteSmoke);
            serpinsky.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            basicPen = new Pen(Color.DarkCyan, 1);

            int depth;
            try
            {
                depth = Math.Abs(int.Parse(textBoxDepth.Text));
            } catch
            {
                depth = 1;
                string message = "Try to paste a number to the field, please";
                MessageForm window = new MessageForm(message);
                window.Show();
            }
            if (depth > 13)
            {
                depth = 5;
                string message = "Don't enter so big number, please. Maximum is 13. It will take a lot of time to draw the Triangle Serpinskogo.";
                MessageForm window = new MessageForm(message);
                window.Show();
            }
            // finding start points on canvas
            Point center = new Point(500, 350);
            int R = 300;
            Point a = new Point();
            Point b = new Point();
            Point c = new Point();
            Point[] serpinskyPoints = new Point[] { a, b, c, a };
            for (int i = 0; i < 3; i++)
            {
                double x = Math.Cos((2 * Math.PI * (i) / 3) - 180) * R + center.X;
                serpinskyPoints[i].X = Convert.ToInt32(x);
                double y = Math.Sin((2 * Math.PI * (i) / 3) - 180) * R + center.Y;
                serpinskyPoints[i].Y = Convert.ToInt32(y);
            }
            a = serpinskyPoints[0];
            b = serpinskyPoints[1];
            c = serpinskyPoints[2];

            this.DrawSerpinsky(depth, a, b, c);
        }

        private void DrawSerpinsky(int count, Point a, Point b, Point c)
        {
            Point[] serpinskyPoints = new Point[] { a, b, c, a };
            serpinsky.DrawLines(basicPen, serpinskyPoints);
            if (count > 0)
            {
                Point aNext = a;
                Point bNext = b;
                Point cNext = c;
                Point[] serpinskyNextPoints = new Point[] { aNext, bNext, cNext };

                for (int i = 0; i < serpinskyNextPoints.Length; i++)
                {
                    int x = (serpinskyPoints[i].X + serpinskyPoints[i + 1].X) / 2;
                    int y = (serpinskyPoints[i].Y + serpinskyPoints[i + 1].Y) / 2;
                    Point middle = new Point(x, y);
                    serpinskyNextPoints[i] = middle;
                }
                aNext = serpinskyNextPoints[0];
                bNext = serpinskyNextPoints[1];
                cNext = serpinskyNextPoints[2];

                count--;
                this.DrawSerpinsky(count, aNext, b, bNext);
                this.DrawSerpinsky(count, bNext, c, cNext);
                this.DrawSerpinsky(count, cNext, a, aNext);
            }
        }
    }
}
