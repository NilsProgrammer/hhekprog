namespace ZombieManager;
public class Vector2
{
    public int X { get; set; } = 0;

    public int Y { get; set; } = 0;

    public static Vector2 Add(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
    }

    public Vector2() {}

    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Add(Vector2 vector)
    {
        X += vector.X;
        Y += vector.Y;
    }

    public bool Equals(Vector2 vector)
    {
        return X == vector.X && Y == vector.Y;
    }

    public Vector2 Clone()
    {
        return new Vector2(X, Y);
    }

    public override string ToString()
    {
        return this != null ? "Vector2(" + X + "," + Y + ")" : "null";
    }
}