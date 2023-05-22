using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fire
{
    public class DrawingThreadManager
    {
        FireDisplay f;
        public DrawingThreadManager(FireDisplay ff)
        {
            f = ff;
        }
        public void DrawingThread()
        {
            while (true)
            {
                f.Invalidate();
                System.Threading.Thread.Sleep(33);
            }
        }
    }
    
    public partial class FireDisplay : Form
    {
        public ParticleSystem particleSystem;
        public Canvas canvas;
        public FireDisplay()
        {
            InitializeComponent();
            DoubleBuffered = true;

            //Different way to double buffer, above seems good enough
            //SetStyle(ControlStyles.OptimizedDoubleBuffer |
            //    ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint,
            //    true);
            //UpdateStyles();

            //canvas = new Canvas();

            particleSystem = new ParticleSystem(800, 600);

            DrawingThreadManager dtm = new DrawingThreadManager(this);
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(dtm.DrawingThread));
            t.Start();
        }



        private void FireDisplay_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(System.Drawing.Brushes.White, new Rectangle(0, 0, Width, Height));
            particleSystem.Run(g);
            Pen pen = new Pen(Brushes.Black);
            int rad = 150;
            g.DrawLine(pen, new Point(Width / 2, Height / 2 - rad), new Point(Width / 2, Height / 2 + rad));
            g.DrawLine(pen, new Point(Width / 2 - rad, Height / 2), new Point(Width / 2 + rad, Height / 2));
            int s = 150;
            g.DrawEllipse(pen, new RectangleF(new PointF((float)(Width / 2.0 - (float)(s/2.0)), (float)(Height / 2.0) - (float)(s/2.0)), new SizeF(s, s)));
            pen.Dispose();
        }
    }
}
