using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class VectorMath
    {
        public static float Distance(Vec2 a, Vec2 b)
        {
            return (float)Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        public static Vec2 Normalize(Vec2 a)
        {
            float m = (float)Math.Sqrt(a.X * a.X + a.Y * a.Y);
            return new Vec2(a.X/m, a.Y/m);
        }

        public static float Dot(Vec2 a, Vec2 b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

    }
}
