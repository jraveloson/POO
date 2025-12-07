using Models.SpaceShips;
using Models;

public class SpaceInvaders {

    public List<Player> players = new List<Player>();
    public List<Spaceship> enemies = new List<Spaceship>();
    public Player currentPlayer;
    private static Random rng = new Random();
    SpaceInvaders() {
        Init();
    }

    private void Init() {
        Player player1 = new Player("joanna", "raveloson", "jojo");
        players.Add(player1);
        currentPlayer = player1;
        enemies.Add(new Dart());
        // enemies.Add(new Rocinante());
        // enemies.Add(new ViperMKII());
        // enemies.Add(new Tardis());
        // enemies.Add(new F18()); 
    }

    private void playRound() {
        foreach (var enemy in enemies.ToList())
        {
            if (enemy is IAbility abilityEnemy)
            {
                abilityEnemy.UseAbility(enemies);
            }

            if (!enemy.IsDestroyed) {
                enemy.ShootTarget(players[0].spaceship);
            }
        }
        enemies.RemoveAll(e => e.IsDestroyed);

        var aliveEnemies = enemies.Where(e => !e.IsDestroyed).ToList();
        if (aliveEnemies.Count > 0)
        {
            double probability = 1.0;
            foreach (var enemy in aliveEnemies) {
                if (rng.NextDouble() < (probability / aliveEnemies.Count)) {
                    players[0].spaceship.ShootTarget(enemy);
                    break;
                }
                probability += 1.0;
            }
        }

        foreach (var player in players)
        {
            if (player.spaceship.CurrentShield < player.spaceship.MaxShield)
            {
                player.spaceship.CurrentShield += 2;
                if (player.spaceship.CurrentShield > player.spaceship.MaxShield)
                    player.spaceship.CurrentShield = player.spaceship.MaxShield;
            }
        }
    }

    public void Menu()
    {
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("\n=== Space Invaders Menu ===");
            Console.WriteLine("1. Player Menu");
            Console.WriteLine("2. Spaceship Menu");
            Console.WriteLine("3. Armory Menu");
            Console.WriteLine("4. Display Top 5 Weapons");
            Console.WriteLine("5. Play Round");
            Console.WriteLine("0. Quit");
            Console.Write("Choice: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1": PlayerMenu(); break;
                case "2": SpaceshipMenu(); break;
                case "3": ArmoryMenu(); break;
                case "4": DisplayTopWeapons(); break;
                case "5": playRound(); break;
                case "0": quit = true; break;
                default: Console.WriteLine("Choix invalide."); break;
            }
        }
    }

    private void PlayerMenu()
    {
        Console.WriteLine("\n=== Player Management ===");
        Console.WriteLine("1. Create a player");
        Console.WriteLine("2. Delete a player");
        Console.WriteLine("3. Choose current player");
        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Write("Last Name: "); string nom = Console.ReadLine()!;
                Console.Write("First Name: "); string prenom = Console.ReadLine()!;
                Console.Write("Username: "); string pseudo = Console.ReadLine()!;
                Player p = new Player(nom, prenom, pseudo);
                players.Add(p);
                Console.WriteLine("Player created!");
                break;
            case "2":
                for (int i = 0; i < players.Count; i++)
                    Console.WriteLine($"{i}: {players[i].Alias}");
                Console.Write("Index to delete: "); int idx = int.Parse(Console.ReadLine()!);
                players.RemoveAt(idx);
                Console.WriteLine("Player deleted!");
                break;
            case "3":
                for (int i = 0; i < players.Count; i++)
                    Console.WriteLine($"{i}: {players[i].Alias}");
                Console.Write("Index of current player: "); int idx2 = int.Parse(Console.ReadLine()!);
                currentPlayer = players[idx2];
                Console.WriteLine($"Current player: {currentPlayer.Alias}");
                break;
            default: Console.WriteLine("Invalid choice."); break;
        }
    }

    private void SpaceshipMenu()
    {
        if (currentPlayer == null) { Console.WriteLine("No player selected."); return; }

        Console.WriteLine("\n=== Spaceship Management ===");
        Console.WriteLine("1. Add a weapon");
        Console.WriteLine("2. Remove a weapon");
        string? choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Armory.ViewArmory();
                Console.Write("Index of the weapon to add: "); int idx = int.Parse(Console.ReadLine()!);
                Weapon? w = Armory.GetWeapon(idx);
                if (w != null) currentPlayer.spaceship.AddWeapon(new Weapon(w));
                break;
            case "2":
                for (int i = 0; i < currentPlayer.spaceship.weapons.Count; i++)
                    Console.WriteLine($"{i}: {currentPlayer.spaceship.weapons[i].Name}");
                Console.Write("Index of the weapon to remove: "); int idx2 = int.Parse(Console.ReadLine()!);
                currentPlayer.spaceship.weapons.RemoveAt(idx2);
                break;
            default: Console.WriteLine("Invalid choice."); break;
        }
    }

    private void ArmoryMenu()
    {
        Console.WriteLine("\n=== Gestion de l'Armurerie ===");
        Console.WriteLine("1. Ajouter une arme");
        Console.WriteLine("2. Modifier une arme");
        Console.WriteLine("3. Supprimer une arme");
        Console.WriteLine("4. Créer depuis un fichier");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Name: "); string nom = Console.ReadLine()!;
                Console.Write("MinDamage: "); double minD = double.Parse(Console.ReadLine()!);
                Console.Write("MaxDamage: "); double maxD = double.Parse(Console.ReadLine()!);
                Console.Write("Type (DIRECT, EXPLOSIVE, GUIDED): "); string t = Console.ReadLine()!;
                Console.Write("ReloadTime: "); double rt = double.Parse(Console.ReadLine()!);
                EWeaponType type = Enum.Parse<EWeaponType>(t, true);
                Armory.Weapons.Add(new Weapon(nom, minD, maxD, type, rt));
                Console.WriteLine("Weapon added!");
                break;
            case "2":
                for (int i = 0; i < Armory.Weapons.Count; i++)
                    Console.WriteLine($"{i}: {Armory.Weapons[i].Name}");
                Console.Write("Index of the weapon to modify: "); int idxM = int.Parse(Console.ReadLine()!);
                Weapon wM = Armory.Weapons[idxM];
                Console.Write("New MinDamage: "); wM.MinDamage = double.Parse(Console.ReadLine()!);
                Console.Write("New MaxDamage: "); wM.MaxDamage = double.Parse(Console.ReadLine()!);
                break;
            case "3":
                for (int i = 0; i < Armory.Weapons.Count; i++)
                    Console.WriteLine($"{i}: {Armory.Weapons[i].Name}");
                Console.Write("Index of the weapon to remove: "); int idxS = int.Parse(Console.ReadLine()!);
                Armory.Weapons.RemoveAt(idxS);
                break;
            case "4":
                Console.Write("File path: "); string file = Console.ReadLine()!;
                ArmeImporteur importeur = new ArmeImporteur();
                importeur.ReadFile(file);
                var freqs = importeur.GetFrequences();
                foreach (var kvp in freqs)
                {
                    string name = kvp.Key;
                    double minDmg = kvp.Key.Length;
                    double maxDmg = kvp.Key.Length + kvp.Value;
                    EWeaponType randomType = (EWeaponType)rng.Next(0, 3);
                    Armory.Weapons.Add(new Weapon(name, minDmg, maxDmg, randomType, 2));
                }
                break;
            default: Console.WriteLine("Invalid choice."); break;
        }
    }

    private void DisplayTopWeapons()
    {
        Console.WriteLine("\n=== Top 5 Weapon Averages ===");
        var topAvg = Armory.Weapons.OrderByDescending(w => w.AverageDamage).Take(5);
        foreach (var w in topAvg)
            Console.WriteLine($"{w.Name} | Average: {w.AverageDamage:0.0}");

        Console.WriteLine("\n=== Top 5 Weapon MinDamage ===");
        var topMin = Armory.Weapons.OrderByDescending(w => w.MinDamage).Take(5);
        foreach (var w in topMin)
            Console.WriteLine($"{w.Name} | MinDamage: {w.MinDamage}");
    }


    static void Main(string[] args) {
        SpaceInvaders game = new SpaceInvaders();
        if (args.Length > 0)
        {
            ArmeImporteur importeur = new ArmeImporteur();
            importeur.ReadFile(args[0]);
            var freqs = importeur.GetFrequences();
            foreach (var kvp in freqs)
            {
                string name = kvp.Key;
                double minDmg = kvp.Key.Length;
                double maxDmg = kvp.Key.Length + kvp.Value;
                EWeaponType randomType = (EWeaponType)rng.Next(0, 3);
                Armory.Weapons.Add(new Weapon(name, minDmg, maxDmg, randomType, 2));
            }
        }

        game.Menu();
    }
}
