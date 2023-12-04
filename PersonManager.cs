public class PersonManager<T> where T : IPerson
{
    private List<T> personen = new List<T>();

    public void add(T person) {
        personen.Add(person);
    }

    public List<T> get() {
        return personen;
    }
}
