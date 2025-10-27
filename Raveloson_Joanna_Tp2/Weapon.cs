public class Weapon {
    public string Name { get; set; }
    public EWeaponType Type { get; set; }
    public double MinDamage { get; set; }
    public double MaxDamage { get; set; }
    

    public Weapon(string name, double minDamage, double maxDamage, EWeaponType type){
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Type = type;
    }
}

public enum EWeaponType {
    DIRECT,
    EXPLOSIVE,
    GUIDED
}