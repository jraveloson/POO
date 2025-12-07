using Models.SpaceShips;
using Models;

public class Weapon : IWeapon {
    public string Name { get; set; }
    public EWeaponType Type { get; set; }
    public double MinDamage { get; set; }
    public double MaxDamage { get; set; }
    public double ReloadTime { get; set; }
    public double TimeBeforReload { get; set; }
    public bool IsReload => TimeBeforReload <= 0;
    public double AverageDamage => (MinDamage + MaxDamage) / 2;

    public Weapon(string name, double minDamage, double maxDamage, EWeaponType type, double reloadTime){
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Type = type;
        ReloadTime = reloadTime;
        TimeBeforReload = ReloadTime;
    }

    public Weapon(Weapon other)
    {
        Name = other.Name;
        MinDamage = other.MinDamage;
        MaxDamage = other.MaxDamage;
        Type = other.Type;
        ReloadTime = other.ReloadTime;
        TimeBeforReload = other.TimeBeforReload;
    }

    public double Shoot()
    {
        double damage = 0;
        Random rand = new Random();
        if(ReloadTime > 0)
        {
            Console.WriteLine($"{Name} reloading... ${TimeBeforReload} seconds left.");
            return 0;
        }
        else if(ReloadTime == 0)
        {
            if(this.Type == EWeaponType.DIRECT)
            {
                // 1 chance sur 10 de rater le tir
                int chance = rand.Next(1, 11);
                if(chance == 1)
                {
                    Console.WriteLine($"{Name} missed the shot!");
                    return damage = 0;
                }
                else
                {
                    damage = rand.NextDouble() * (MaxDamage - MinDamage) + MinDamage;
                    Console.WriteLine($"{Name} hit the target for {damage} damage.");
                    ReloadTime = TimeBeforReload;
                    return damage;
                }
            }
            else if(this.Type == EWeaponType.EXPLOSIVE)
            {
                // 1 chance sur 4 de rater
                int chance = rand.Next(1, 5);
                if(chance == 1)
                {
                    Console.WriteLine($"{Name} missed the shot!");
                    damage = 0;
                    return damage;
                }
                else
                {
                    // Multiplie les dégats et le temps de rechargement par 2
                    damage = rand.NextDouble() * (MaxDamage - MinDamage) + MinDamage;
                    damage *= 2;
                    Console.WriteLine($"{Name} hit the target for {damage} damage.");
                    ReloadTime = TimeBeforReload * 2;
                    return damage;
                }
            }
            else if (this.Type == EWeaponType.GUIDED)
            {
                // Dégats minimum garantis
                damage = MinDamage;
                Console.WriteLine($"{Name} hit the target for {damage} damage.");
                ReloadTime = TimeBeforReload;
                return damage;
            }
        }
        return damage;
    }
}

public enum EWeaponType {
    DIRECT,
    EXPLOSIVE,
    GUIDED
}