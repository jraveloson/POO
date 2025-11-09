public class Weapon {
    public string Name { get; set; }
    public EWeaponType Type { get; set; }
    public double MinDamage { get; set; }
    public double MaxDamage { get; set; }
    public double ReloadTime { get; set; }
    public double TimeBeforReload { get; set; }
    

    public Weapon(string name, double minDamage, double maxDamage, EWeaponType type, double reloadTime){
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Type = type;
        ReloadTime = reloadTime;
        TimeBeforeReload = ReloadTime;
    }

    public double Shoot()
    {
        double damage = 0;
        if(ReloadTime > 0)
        {
            Console.WriteLine($"{Name} reloading... ${TimeBeforeReload} seconds left.");
            return 0;
        }
        else if(ReloadTime == 0)
        {
            if(this.Type == DIRECT)
            {
                // 1 chance sur 10 de rater le tir
                Random rand = new Random();
                int chance = rand.Next(1, 11);
                if(chance == 1)
                {
                    Console.WriteLine($"{Name} missed the shot!");
                    damage = 0;
                }
                else
                {
                    damage = rand.NextDouble() * (MaxDamage - MinDamage) + MinDamage;
                    Console.WriteLine($"{Name} hit the target for {damage} damage.");
                    ReloadTime = TimeBeforeReload;
                }
            }
            else if(this.Type == EXPLOSIVE)
            {
                // 1 chance sur 4 de rater
                int chance = rand.Next(1, 5);
                if(chance == 1)
                {
                    Console.WriteLine($"{Name} missed the shot!");
                    damage = 0;
                }
                else
                {
                    // Multiplie les dégats et le temps de rechargement par 2
                    damage = rand.NextDouble() * (MaxDamage - MinDamage) + MinDamage;
                    damage *= 2;
                    Console.WriteLine($"{Name} hit the target for {damage} damage.");
                    ReloadTime = TimeBeforeReload * 2;
                }
            }
            else if (this.Type == GUIDED)
            {
                // Dégats minimum garantis
                damage = MinDamage;
                Console.WriteLine($"{Name} hit the target for {damage} damage.");
                ReloadTime = TimeBeforeReload;
            }
        }
    }
}

public enum EWeaponType {
    DIRECT,
    EXPLOSIVE,
    GUIDED
}