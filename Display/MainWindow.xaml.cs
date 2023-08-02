using System.Windows;
using Engine;
using System.Windows.Threading;
using System;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Display
{
    public partial class MainWindow : Window
    {
        readonly World world = new();
        readonly Stopwatch sw = new Stopwatch();
        readonly Brush brush = new SolidColorBrush(Colors.Black);
        Random rnd = new Random();
        TimeSpan deltaTime = TimeSpan.FromSeconds(1.0 / 60.0);

        public MainWindow()
        {
            InitializeComponent();

            CompositionTarget.Rendering += OnRendering;
            sw.Start();
        }

        private void OnRendering(object? sender, EventArgs e)
        {
            sw.Stop();
            deltaTime = sw.Elapsed;
            world.HandleColisions((float)deltaTime.TotalSeconds);
            sw.Restart();

            canvas.Children.Clear();

            foreach (RigidBody body in world.RigidBodies)
            {
                float diameter = (body.Radius * 2);
                float x = (body.Position.X - body.Radius);
                float y = (body.Position.Y - body.Radius);
                Ellipse circle = new Ellipse
                {
                    Width = diameter,
                    Height = diameter,
                    Fill = Brushes.Blue,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };

                Canvas.SetLeft(circle, x);
                Canvas.SetTop(circle, y);
                canvas.Children.Add(circle);
            }
        }

        private void AddObject(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RigidBody body = new RigidBody(new Vec2(rnd.Next(1920), rnd.Next(1080)), false, rnd.Next(50));
            world.RigidBodies.Add(body);
        }

    }
}
