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

        public readonly float Gravity;

        public World(float g)
        {
            Gravity = g;
            RigidBodies = new List<RigidBody>();
        }

        public void HandleColisions()
        {
            for (int i = 0; i < RigidBodies.Count; i++)
            {
                RigidBody body = RigidBodies[i];
                for (int j = i + 1; j < RigidBodies.Count; j++)
                {
                    RigidBody body2 = RigidBodies[j];
                    if (Collision.CircleVsCircle(body, body2, out float depth)) 
                    {
                        Collision.OnColision(body, body2, depth);
                    }   
                }
            }
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


    }
}
