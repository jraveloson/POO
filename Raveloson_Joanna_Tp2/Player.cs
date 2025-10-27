public class Player {

    private string FirstName { get; }
    private string LastName { get; }
    public string Alias { get; }
    public string Name { get{ return FirstName + " " + LastName; } }

    public Spaceship spaceship { get; set;}

    public Player(string firstName, string lastName, string alias) {
        FirstName = formatName(firstName);
        LastName = formatName(lastName);
        Alias = alias;
        this.spaceship = new Spaceship();
    }

    private static string formatName(string name) {
        string formattedName = $"{char.ToUpper(name[0])}{name.Substring(1).ToLower()}";
        return formattedName;
    }

    public override string ToString() {
        return $"{Alias} ({Name})";
    }

    public override bool Equals(object? obj) {
        if (obj is Player other) {
            return Alias == other.Alias;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return Alias?.ToLower().GetHashCode() ?? 0;
    }

};