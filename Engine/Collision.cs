using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Collision
    {
        public static bool CircleVsCircle(Circle a, Circle b, out float depth)
        {
            float distance = VectorMath.Distance(a.Center, b.Center);
            float radii = a.Radius + b.Radius;

            depth = radii - distance;

            if (distance >= radii)
            {
                return false;
            }
            return true;
        }

        public static void OnColision(Circle a, Circle b)
        {
            if (CircleVsCircle(a, b, out float depth))
            {
                Vec2 CNormal = new Vec2(a.Center - b.Center);
                a.Move(CNormal.X * depth, CNormal.Y * depth);
                b.Move(-CNormal.X * depth, -CNormal.Y * depth);
            }
        }



    }
}
