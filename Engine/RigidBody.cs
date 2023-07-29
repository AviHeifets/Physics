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
        public Vec2 LastPos { get; set; }
        public Vec2 Velocity { get; set; } // TODO: make private when figured
        public float Radius { get; set; }
        public float Mass { get; set; }  //TODO: add mass

        public RigidBody(Vec2 pos, bool isStatic, float radius)
        {
            this.Position = pos;
            this.LastPos = Position;
            this.Velocity = Vec2.ZeroVec();
            this.IsStatic = isStatic;
            this.Radius = radius;
        }
        public readonly bool IsStatic;

        //public void Move(Vec2 direction)
        //{
        //    LastPos = Position;
        //    this.Position += direction;
        //}

        //public void Move(float x, float y)
        //{
        //    LastPos = Position;
        //    this.Position += new Vec2(x, y);
        //}

        public void ApplyForce(Vec2 force)
        {
            Velocity += force;
        }

        public void Update(float deltaTime)
        {
            if (!IsStatic)
                this.Position += new Vec2(Velocity.X * deltaTime , Velocity.Y * deltaTime);
        }

    }
}

