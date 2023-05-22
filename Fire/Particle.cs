using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fire
{
    public class Particle
    {
        private int size;
        private float startingX;
        private float startingY;
        private float vel_x = 0;
        private float vel_y = 0;
        private int WindowWidth;
        private int WindowHeight;


        System.Drawing.RectangleF ellipse;
        Pen p;
        public Particle(float x, float y, int ss, float velx, float vely, int windowWidth, int windowHeight)
        {
            size = ss;
            startingX = x;
            startingY = y;
            //red, orange, yellow, white
            //red = rgb(255,0,0)
            //yellow = rgb(255,255,0)
            ellipse = new RectangleF(new PointF(x, y), new SizeF(new PointF(size, size)));
            Color c = Color.FromArgb(255,0,0);
            p = new Pen(c);


            vel_x = velx;
            vel_y = vely;
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
        }
        public float X() { return ellipse.X; }
        public float Y() { return ellipse.Y; }
        public void Run(Graphics g)
        {
            Update();
            Draw(g);
        }
        public void Draw(Graphics g)
        {
            g.FillEllipse(p.Brush, ellipse);
        }
        private float GetNewRange(float y)
        {
            //0 = 5*size
            //start = 1*size
            //y: startingY -> 0
            return 15*(startingY / y);
        }
        public bool OutOfBounds()
        {
            return ellipse.X < 0 || ellipse.X >= WindowWidth || ellipse.Y < 0 || ellipse.Y > WindowHeight;
        }
        public void Update()
        {
            float nextX = ellipse.X + vel_x;

            if (Math.Abs(startingX - nextX) > GetNewRange(ellipse.Y))
            {
                vel_x *= -1;
                nextX = ellipse.X + vel_x;
            }
            if (nextX < 0 || nextX > WindowWidth)
            {
                vel_x *= -1;
            }
            ellipse.X = nextX;
            ellipse.Y += vel_y;
            int yellowAmt = 255 - (int)(ellipse.Y / startingY * 255);
            if (yellowAmt > 255)
            {
                yellowAmt = 255;
            }
            p.Color = Color.FromArgb(255, yellowAmt, 0);


        }
    }
}
