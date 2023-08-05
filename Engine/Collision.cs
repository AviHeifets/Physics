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
            Vec2 collisionNormal = VectorMath.Normalize(b.Position - a.Position);

            // Separate the objects based on the collision depth
            float totalMass = a.Mass + b.Mass;
            Vec2 separationVector = new Vec2(collisionNormal.X * (depth * (a.Mass / totalMass)), collisionNormal.Y * (depth * (a.Mass / totalMass)));
            a.ApplyForce(separationVector * -1);
            b.ApplyForce(separationVector);

            // Calculate relative velocity along the collision normal
            Vec2 relativeVelocity = b.Velocity - a.Velocity;
            float relativeSpeedAlongNormal = VectorMath.Dot(relativeVelocity, collisionNormal);

            if (relativeSpeedAlongNormal > 0)
            {
                return;
            }

            // Calculate impulse (change in velocity) based on collision response
            float restitution = 0.8f; 
            float impulseMagnitude = -(1 + restitution) * relativeSpeedAlongNormal / totalMass;
            Vec2 impulse = new Vec2(impulseMagnitude * collisionNormal.X, impulseMagnitude * collisionNormal.Y);

            a.ApplyForce(new Vec2(-impulse.X * b.Mass, -impulse.Y * b.Mass));
            b.ApplyForce(new Vec2(impulse.X * a.Mass, impulse.Y * a.Mass));

        }


    }
}
