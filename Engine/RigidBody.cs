using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class RigidBody
    {
        public Vec2 Position { get; set; }
        public Vec2 Velocity { get; set; } = Vec2.ZeroVec();
        public float Radius { get; set; }
        public float Mass { get; set; }


        public RigidBody(Vec2 pos, bool isStatic, float radius, float mass)
        {
            this.Position = pos;
            this.IsStatic = isStatic;
            this.Radius = radius;
            this.Mass = mass;
        }
        public readonly bool IsStatic;

        public void ApplyForce(Vec2 force)
        {
            if (!IsStatic)
                Velocity += force;
        }

        public void Update(float deltaTime)
        {
            if (!IsStatic)
                this.Position += new Vec2(Velocity.X * deltaTime, Velocity.Y * deltaTime);
            Confinment(Velocity);

        }

    
        private void Confinment(Vec2 velocity)
        {
            if (Position.X - Radius < 0  )
            {
                Position = new Vec2(0 + Radius,Position.Y);
                ApplyForce(new Vec2(-velocity.X + -velocity.X, 0 ));
            }  

            if (Position.X - Radius > 1600)
            {
                Position = new Vec2(1600 - Radius, Position.Y);
                ApplyForce(new Vec2(-velocity.X + -velocity.X, 0));
            }
        

            if (Position.Y - Radius < 0 )
            {
                Position = new Vec2(Position.X, 0 + Radius);
                ApplyForce(new Vec2(0, -velocity.Y + -velocity.Y ));
            }

            if (Position.Y + Radius > 800)
            {
                Position = new Vec2(Position.X, 800 - Radius);
                ApplyForce(new Vec2(0, -velocity.Y + -velocity.Y));
            }
        }
    }
}

