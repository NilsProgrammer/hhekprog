namespace ZombieManager;
public class Vector2
{
    private int x = 0;
    private int y = 0;

    public int X {
        get {
            return x;
        }
        set {
            if (value < 0 || value > Console.WindowWidth) {throw new Exception();}
            x = value;
        }
    }

    public int Y {
        get {
            return y;
        }
        set {
            if (value < 0 || value > Console.WindowHeight) {throw new Exception();}
            y = value;
        }
    }

    public double Magnitude {
        get {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }
    }
    public Vector2() {

    }

    public Vector2(int x, int y) {
        X = x;
        Y = y;
    }

    public void Add(Vector2 vector) {
        X += vector.X;
        Y += vector.Y;
    }

    public void Sub(Vector2 vector) {
        X -= vector.X;
        Y -= vector.Y;
    }

    public int CompareTo(Vector2? vector)
    {
        if (this == null && vector != null) {
            return -1;
        }
        else if (this != null && vector == null) {
            return 1;
        }
        else if (this == null && vector == null) {
            return 0;
        }

        if (this.Magnitude < vector!.Magnitude) {
            return -1;
        }
        else if (this.Magnitude > vector.Magnitude) {
            return 1;
        }

        return 0;
    }

    public bool Equals(Vector2 vector) {
        return X == vector.X && Y == vector.Y;
    }

    public override string ToString()
    {
        return this != null ? "Vector2(" + X + "," + Y + ")": "null";
    }
}