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
        public float Radius { get; set; }

        private float mass;
        private Vec2 lastPos;
        private float density;
        private Vec2 velocity;

        public RigidBody(Vec2 pos, bool isStatic, float radius)
        {
            this.Position = pos;
            this.lastPos = Position;
            this.velocity = Vec2.ZeroVec();
            this.IsStatic = isStatic;
            this.Radius = radius;
        }
        public readonly bool IsStatic;

        //public void Move(Vec2 direction)
        //{
        //    lastPos = Position;
        //    this.Position += direction;
        //}

        //public void Move(float x, float y)
        //{
        //    lastPos = Position;
        //    this.Position += new Vec2(x, y);
        //}

        public void ApplyForce(Vec2 force)
        {
            if (!IsStatic)
                velocity += force;
        }

        public void Update(float deltaTime)
        {
            if (!IsStatic)
                this.Position += new Vec2(velocity.X * deltaTime, velocity.Y * deltaTime);
            Confinment();

        }

        private void Confinment()
        {
            if (Position.X - Radius < 0)
            {
                Position = new Vec2(Radius, Position.Y);
                velocity.X = 0;
            }
            else if (Position.X + Radius > 1500)
            {
                Position = new Vec2(1500 - Radius, Position.Y);
                velocity.X = 0;
            }

            if (Position.Y - Radius < 0)
            {
                Position = new Vec2(Position.X, Radius);
                velocity.Y = 0;
            }
            else if (Position.Y + Radius > 800)
            {
                Position = new Vec2(Position.X, 800 - Radius);
                velocity.Y = 0;
            }

        }
    }
}

