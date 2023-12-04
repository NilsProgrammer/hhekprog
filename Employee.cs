public class Employee : Person
{   
    string job {get;} = "Employee";
    public Employee() {}
    public Employee(string name, int alter) : base(name, alter) {
        this.name = name;
        this.alter = alter;
    }
}
