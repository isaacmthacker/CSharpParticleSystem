using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fire
{
    public class ParticleSystem
    {
        private List<Particle> particles = new List<Particle>();
        private int width;
        private int height;
        private Random r;
        public ParticleSystem(int w, int h)
        {
            width = w;
            height = h;
            r = new Random();
            CreateParticles();
        }
        private Particle CreateParticle()
        {
            int StartRad = 50;

            int size = 10;
            int numSteps = 100;
            float step = (float)(2 * Math.PI / (float)numSteps);
            float velXStep = (float)(3.0 / 50.0);
            float velYStep = (float)(5.0 / 50.0);

            float angle = step * r.Next(1, numSteps);
            float rad = (float)(StartRad * (1.0 / r.Next(1, 10)));
            //Console.WriteLine(angle.ToString() + "," + rad.ToString());
            float centerx = (float)(rad * Math.Cos(angle) + (width / 2.0));
            float centery = (float)(rad * Math.Sin(angle) + (height / 2.0));

            float velx = velXStep * r.Next(-50, 50);
            float vely = -1 * velYStep * r.Next(20, 50);
            Console.WriteLine(centerx.ToString() + "," + centery.ToString() + " " + velx.ToString() + "," + vely.ToString());
            return new Particle(centerx, centery, size, velx, vely, width, height);
        }
        private void CreateParticles()
        {
            Console.WriteLine("Dims: " + width.ToString() + "," + height.ToString());

            int numPoints = 5000;
            for (int i = 0; i < numPoints; i++)
            {
                particles.Add(CreateParticle());
            }


            /*
            for (int i = 0; i < numPoints; ++i)
            {
                float x = r.Next(width);
                float y = r.Next(height);
                float velx = r.Next(-50, 50);
                float vely = r.Next(-50, 50);
                Console.WriteLine(x.ToString() + "," + y.ToString());
                particles.Add(new Particle(x, y, size, velx, vely, width, height));
            }
            */

            /*
            double end = 2 * Math.PI;
            double cur = 0;
            double rad = 150;
            double step = end / numPoints;
            double xOffset = width / 2;
            double yOffset = height / 2;

            while (cur < end)
            {
                //x = r*cos(T)
                //y = r*sin(T)
                float x = (float)(rad * Math.Cos(cur) + xOffset);
                float y = (float)(rad * Math.Sin(cur) + yOffset);

                Console.WriteLine(x.ToString() + "," + y.ToString());
                x -= size / 2;
                y -= size / 2;

                float endx = (float)(width/2.5*Math.Cos(cur)+xOffset);
                float endy = (float)(height/2.5*Math.Sin(cur)+yOffset);
                int steps = 150;
                float velx = (float)((endx - x) / steps);
                float vely = (float)((endy - y) / steps);

                Console.WriteLine(x.ToString() + "," + y.ToString() + " " + endx.ToString() + "," + endy.ToString() + " "
                    + velx.ToString() + "," + vely.ToString());

                particles.Add(new Particle(x, y, size, velx, vely));
                //particles.Add(new Particle((int)x, (int)y, size, 0,0));
                particles.Add(new Particle(endx, endy, size, 0,0));
                cur += step;
            }
            */
        }
        public void Run(Graphics g)
        {
            for(int i = 0; i < particles.Count; ++i)
            {
                particles[i].Run(g);
                if (particles[i].OutOfBounds())
                {
                    particles[i] = CreateParticle();
                }
            }
        }
    }
    
}
