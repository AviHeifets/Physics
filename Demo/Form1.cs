using Engine;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.Xml;

namespace Demo
{
    public partial class Form1 : Form
    {

        World world = new World();
        float speed = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            timer1.Start();
        }



        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            Pen pen = new Pen(Color.Black, 1);

            Brush brush = new SolidBrush(Color.Red);

            world.HandleColisions();

            foreach (RigidBody body in world.RigidBodies)
            {
                float diameter = (body.Radius * 2);
                float x = (body.Position.X - body.Radius);
                float y = (body.Position.Y - body.Radius);
                g.FillEllipse(brush, x, y, diameter, diameter);
                g.DrawEllipse(pen, x, y, diameter, diameter);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 16;
            float deltaTime = timer1.Interval / 1000f;
            world.Update(deltaTime);
            Invalidate();
        }

        private void mouseDown(object sender, EventArgs e)
        {
            timer2.Interval = 16;
            Random rnd = new Random();
            RigidBody body = new RigidBody(new Vec2(rnd.Next(1920), rnd.Next(1080)), false, rnd.Next(50));
            world.RigidBodies.Add(body);

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            timer2.Start();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            timer2.Stop();
        }
    }
}