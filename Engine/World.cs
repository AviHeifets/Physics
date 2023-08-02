using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public sealed class World
    {
        public List<RigidBody> RigidBodies { get; set; }

        public static readonly Vec2 Gravity = new Vec2(0, 9.81f);

        private List<Collisions> CollisionBuffer;

        public World()
        {
            RigidBodies = new List<RigidBody>();
            CollisionBuffer = new List<Collisions>();
        }

        public void HandleColisions(float deltaTime)
        {
            for (int i = 0; i < RigidBodies.Count; i++)
            {
                RigidBody body = RigidBodies[i];
                for (int j = i + 1; j < RigidBodies.Count; j++)
                {
                    RigidBody body2 = RigidBodies[j];
                    if (Collision.CircleVsCircle(body, body2, out float depth)) 
                    {
                        CollisionBuffer.Add(new Collisions(body, body2, depth));
                    }   
                }
            }
            Update(deltaTime);
        }


        public void AddBody(RigidBody body)
        {
            RigidBodies.Add(body);
        }

        public void RemoveBody(RigidBody body)
        {
            RigidBodies.Remove(body);
        }

        public void RemoveAllBodies()
        {
            RigidBodies.Clear();
        }

        public void Update(float deltaTime)
        {
            foreach (Collisions coliision in CollisionBuffer)
            {
                Collision.OnColision(coliision.A, coliision.B, coliision.Depth);
            }
            foreach (RigidBody body in RigidBodies)
            {
                body.ApplyForce(Gravity);
                body.Update(deltaTime);
            }

            CollisionBuffer.Clear();
            
        }



        private struct Collisions
        {
            public RigidBody A { get; set; }
            public RigidBody B { get; set; }
            public float Depth { get; set; }

            public Collisions(RigidBody a, RigidBody b, float depth)
            {
                this.A = a;
                this.B = b;
                this.Depth = depth;
            }
        }
    }
}
