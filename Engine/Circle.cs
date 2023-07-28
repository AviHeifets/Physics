using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public sealed class Circle
    {
        public Vec2 Center { get; set; }
        public float Radius { get; set; }
        public Vec2 Direction { get; set; }
        public Vec2 LastPos { get; set; }

        public Circle(Vec2 pos, float r)
        {
            this.Center = pos;
            this.Radius = r;
            this.LastPos = Center;
        }

        public void Move(Vec2 direction) 
        {
            LastPos = Center;
            this.Center += direction;
            this.Direction = VectorMath.Normalize(new Vec2(Center - LastPos));
        }

        public void Move(float x, float y)
        {
            LastPos = Center;
            this.Center += new Vec2(x, y);
            this.Direction = VectorMath.Normalize(new Vec2(Center - LastPos));
        }



    }
}
