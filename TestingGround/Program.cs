using Engine;
using System.Numerics;

Vec2 v1 = new Vec2(4.3f, 2.1f);
Vec2 v2 = new Vec2(2.2f, 2.4f);

Console.WriteLine(v1 + v2);
Console.WriteLine(v1 - v2);
Console.WriteLine(v1 * v2);
Console.WriteLine(v1 / v2);

Console.WriteLine(VectorMath.Normalize(v1));

v1 = VectorMath.Normalize(v1);
v2 = VectorMath.Normalize(v2);
Vector2 v3 = new Vector2(4.3f, 2.1f);
Vector2 v4 = new Vector2(2.2f, 2.4f);


Console.WriteLine(VectorMath.Dot(v2, v1));
Console.WriteLine(Vector2.Dot(v3, v4));

Random rnd = new Random();
Circle circle1 = new Circle(new Vec2(5, 5), 5);
Circle circle2 = new Circle(new Vec2(0, 14.5f), 5);

Console.WriteLine(Collision.CircleVsCircle(circle1,circle2, out float depth));
Console.WriteLine(depth);

circle1.Move(new Vec2(-3, 5));

Console.WriteLine(circle1.Direction); 

