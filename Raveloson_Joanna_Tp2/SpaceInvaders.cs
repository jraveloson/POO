public class SpaceInvaders {

    public List<Player> players = new List<Player>();
    SpaceInvaders() {
        Init();
    }

    private void Init() {
        Player player1 = new Player("joanna", "raveloson", "jojo");
        Player player2 = new Player("alice", "dupont", "alice");
        Player player3 = new Player("bob", "martin", "bobby");
        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
    }

    // Main
    static void Main(string[] args) {
        SpaceInvaders spaceInvaders = new SpaceInvaders();
        Console.WriteLine("=== Players ===");
        foreach (Player player in spaceInvaders.players) {
            Console.WriteLine(player.ToString());
        }
        Armory armory = new Armory();
        Weapon weapon1 = new Weapon("Bomb", 15, 25, EWeaponType.DIRECT);
        armory.AddWeapon(weapon1);
        spaceInvaders.players[0].spaceship.AddWeapon(weapon1);
        
        armory.ViewArmory();

        Console.WriteLine("-- " + spaceInvaders.players[0].ToString() + " --");
        spaceInvaders.players[0].spaceship.ViewShip();
    }
}
