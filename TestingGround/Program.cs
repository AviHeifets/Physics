using Engine;
using System.Numerics;

Vec2 v1 = new Vec2(6f, 4f);
Vec2 v2 = new Vec2(2f, 4f);




Random rnd = new Random();
RigidBody circle1 = new RigidBody(v1, false, 2);
RigidBody circle2 = new RigidBody(v2, false, 2);

Console.WriteLine(Collision.CircleVsCircle(circle1,circle2, out float depth));
Console.WriteLine(depth);




