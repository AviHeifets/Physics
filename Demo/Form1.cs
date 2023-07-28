using Engine;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.Xml;

namespace Demo
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        List<Circle> circles;
        float speed = 5;
        public Form1()
        {
            InitializeComponent();
            g = base.CreateGraphics();
            pen = new Pen(Color.Black, 3);
            circles = new List<Circle>();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            Circle circle = new Circle(new Vec2((float)rnd.Next(200), (float)rnd.Next(200)), rnd.Next(5, 100));
            circles.Add(circle);
            DrawCircle(circle);
            
        }

        private void DrawCircle(Circle circle)
        {
            g.DrawEllipse(pen, circle.Center.X, circle.Center.Y, circle.Radius, circle.Radius);
            Brush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, circle.Center.X, circle.Center.Y, circle.Radius, circle.Radius);
        }

        public void DrawWorld(List<Circle> circles)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.Clear(Color.White);

            CheckColisions();

            foreach (Circle circle in circles)
            {
                DrawCircle(circle);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            {
                circles[0].Move(new Vec2(0, speed));
                DrawWorld(circles);
            }
            if (e.KeyChar == 'w')
            {
                circles[0].Move(new Vec2(0, -speed));
                DrawWorld(circles);
            }
            if (e.KeyChar == 'd')
            {
                circles[0].Move(new Vec2(speed, 0));
                DrawWorld(circles);
            }
            if (e.KeyChar == 'a')
            {
                circles[0].Move(new Vec2(-speed, 0));
                DrawWorld(circles);

            }

        }

        private void CheckColisions()
        {
            for (int i = 0; i < circles.Count; i++)
            {
                Circle circle = circles[i];
                for ( int j = i + 1; j < circles.Count; j++)
                {
                    Circle circle2 = circles[j];
                    Collision.OnColision(circle, circle2);
                }
            }
        }
    }
}