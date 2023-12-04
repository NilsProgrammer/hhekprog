public class Patient : Person
{   
    string job {get;} = "Patient";
    public Patient() {}
    public Patient(string name, int alter) : base(name, alter) {
        this.name = name;
        this.alter = alter;
    }
}