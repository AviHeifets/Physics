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
        World world = new World(9.81f);
        float speed = 5;
        public Form1()
        {
            InitializeComponent();
            g = base.CreateGraphics();
            pen = new Pen(Color.Black, 3);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            RigidBody body = new RigidBody(new Vec2(rnd.Next(400), rnd.Next(400)),false, rnd.Next(50));
            world.RigidBodies.Add(body);
            DrawCircle(body);

        }

        private void DrawCircle(RigidBody circle)
        {
            g.DrawEllipse(pen, circle.Position.X, circle.Position.Y, circle.Radius, circle.Radius);
            Brush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, circle.Position.X, circle.Position.Y, circle.Radius, circle.Radius);
        }

        public void DrawWorld(List<RigidBody> circles)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.Clear(Color.White);

            world.HandleColisions();

            foreach (RigidBody body in world.RigidBodies)
            {
                DrawCircle(body);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
            {
                world.RigidBodies[0].Move(new Vec2(0, speed));
                DrawWorld(world.RigidBodies);
            }
            if (e.KeyChar == 'w')
            {
                world.RigidBodies[0].Move(new Vec2(0, -speed));
                DrawWorld(world.RigidBodies);
            }
            if (e.KeyChar == 'd')
            {
                world.RigidBodies[0].Move(new Vec2(speed, 0));
                DrawWorld(world.RigidBodies);
            }
            if (e.KeyChar == 'a')
            {
                world.RigidBodies[0].Move(new Vec2(-speed, 0));
                DrawWorld(world.RigidBodies);

            }

        }

       
    }
}