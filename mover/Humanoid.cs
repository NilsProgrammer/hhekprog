namespace ZombieManager;
public class Humanoid
{
    public string Name { get; set; }
    public Vector2 Position { get; set; } = new Vector2();

    protected Humanoid()
    {
        Name = "Humanoid";
    }

    protected Humanoid(string name, Vector2 position)
    {
        Name = name;
        Position = position;
    }

    public override string ToString()
    {
        return GetType() + "(Name=" + Name + ", Position=" + Position.ToString() + ")";
    }

    /*
    public void Attack<T>(T entity, double? amount) where T : Humanoid
    {
        entity.TakeDamage(amount ?? Damage);
    }

    public void TakeDamage(double damage)
    {
        Health -= damage;
    }
    */
}
