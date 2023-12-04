public abstract class Person : IPerson
{
    public string name {get; set;} = "Person";
    public int alter {get; set;} = 18;
    
    protected Person() {}
    protected Person(string name, int alter) {
        this.name = name;
        this.alter = alter;
    }

    public void test<T>() where T : Person {

    }
}
