using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct Vec2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vec2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vec2(Vec2 vec)
        {
            this.X = vec.X;
            this.Y = vec.Y;
        }

        public static Vec2 ZeroVec()
        {
            return new Vec2(0, 0);
        }

        static public Vec2 operator +(Vec2 first, Vec2 other)
        {
            return new Vec2(first.X + other.X, first.Y + other.Y);
        }

        static public Vec2 operator -(Vec2 first, Vec2 other)
        {
            return new Vec2(first.X - other.X, first.Y - other.Y);
        }

        static public Vec2 operator *(Vec2 first, Vec2 other)
        {
            return new Vec2(first.X * other.X, first.Y * other.Y);
        }

        static public Vec2 operator /(Vec2 first, Vec2 other)
        {
            return new Vec2(first.X / other.X, first.Y / other.Y);
        }


        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
