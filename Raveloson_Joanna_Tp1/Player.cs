public class Player {
    private string firstName;
    private string lastName;
    public string alias;
    public string name;

    private string FirstName { get{ return firstName; } }
    private string LastName { get{ return lastName; } }
    public string Alias { get{ return alias; } set{ alias = value; } }
    public string Name { get{ return name; } }

    public Spaceship spaceship { get; }

    public Player(string firstName, string lastName, string alias) {
        this.firstName = formatName(firstName);
        this.lastName = formatName(lastName);
        this.alias = alias;
        this.name = $"{this.firstName} {this.lastName}";
        this.spaceship = new Spaceship(100, 50);
    }

    private static string formatName(string name) {
        string formattedName = $"{char.ToUpper(name[0])}{name.Substring(1).ToLower()}";
        return formattedName;
    }

    public override string ToString() {
        return $"{this.alias} ({this.name})";
    }

    public override bool Equals(object? obj) {
        if (obj is Player other) {
            return this.alias == other.alias;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return alias?.ToLower().GetHashCode() ?? 0;
    }

};