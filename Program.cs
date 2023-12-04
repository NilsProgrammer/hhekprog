namespace interfaceabstractclass;
class Program
{
    static void Main(string[] args)
    {
        PersonManager<Patient> patientenManager = new PersonManager<Patient>();
        patientenManager.add(new Patient("Dieter", 40));
        patientenManager.add(new Patient("Heinz", 20));
        patientenManager.get().ForEach((patient) => Console.WriteLine(patient.name + ", " + patient.alter));

        PersonManager<Employee> employeeManager = new PersonManager<Employee>();
        employeeManager.add(new Employee("Müller", 40));
        employeeManager.add(new Employee("Bob", 20));
        employeeManager.get().ForEach((employee) => Console.WriteLine(employee.name + ", " + employee.alter));

        Console.ReadLine();
    }
}
