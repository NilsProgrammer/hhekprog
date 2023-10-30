namespace ZombieManager;
public class Humanoid
{
    private double health = 100;
    private double maxHealth = 100;

    public string Name { get; set; }
    public Vector2 Position { get; set; } = new Vector2();
    public double Damage { get; set; } = 10;
    public double Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value > maxHealth) { return; }
            health = maxHealth;
        }
    }
    public double MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            if (value < 0) { return; }
            maxHealth = value;
        }
    }

    protected Humanoid()
    {
        Name = "Humanoid";
    }

    public void Attack<T>(T entity, double? amount) where T : Humanoid
    {
        entity.TakeDamage(amount ?? Damage);
    }

    public void TakeDamage(double damage)
    {
        Health -= damage;
    }
}
