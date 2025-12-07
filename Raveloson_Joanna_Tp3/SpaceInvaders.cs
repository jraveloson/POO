using Models.SpaceShips;
using Models;

public class SpaceInvaders {

    public List<Player> players = new List<Player>();
    public List<Spaceship> enemies = new List<Spaceship>();
    private static Random rng = new Random();
    SpaceInvaders() {
        Init();
    }

    private void Init() {
        Player player1 = new Player("joanna", "raveloson", "jojo");
        players.Add(player1);
        enemies.Add(new Dart());
        enemies.Add(new Rocinante());
        enemies.Add(new ViperMKII());
        enemies.Add(new Tardis());
        enemies.Add(new F18()); 
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

    static void Main(string[] args) {
        SpaceInvaders spaceInvaders = new SpaceInvaders();
        Console.WriteLine("=== Players ===");
        foreach (Player player in spaceInvaders.players) {
            Console.WriteLine(player.ToString());
        }

        Armory.ViewArmory();

        while (!spaceInvaders.players[0].spaceship.IsDestroyed 
       && spaceInvaders.enemies.Any(e => !e.IsDestroyed))
        {
            Console.WriteLine("=== New Round ===");
            int remainingEnemies = spaceInvaders.enemies.Count(e => !e.IsDestroyed);
            Console.WriteLine($"Remaining Enemies: {remainingEnemies}");
            spaceInvaders.playRound();
        }
    }
}
