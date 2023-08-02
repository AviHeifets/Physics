using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Collision
    {
        public static bool CircleVsCircle(RigidBody a, RigidBody b, out float depth)
        {
            depth = 0;
            float distanceSquared = VectorMath.DistanceSquared(a.Position, b.Position);
            float radiiSquared = (a.Radius + b.Radius) * (a.Radius + b.Radius);

            if (distanceSquared >= radiiSquared)
            {
                return false;
            }



            float distance = (float)Math.Sqrt(distanceSquared);
            float radii = a.Radius + b.Radius;
            depth = radii - distance;
            return true;
        }

        public static void OnColision(RigidBody a, RigidBody b, float depth)
        {
            Vec2 CNormal = new Vec2( b.Position - a.Position );
            CNormal = VectorMath.Normalize(CNormal);
            a.ApplyForce(new Vec2(-CNormal.X * depth, -CNormal.Y * depth));
            b.ApplyForce(new Vec2(CNormal.X * depth, CNormal.Y * depth));
        }

      
    }
}
