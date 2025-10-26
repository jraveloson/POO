public class Weapon {
    public string name;
    public EWeaponType type;
    public int MinDamage { get; }
    public int MaxDamage { get; }
    

    public Weapon(string name, int minDamage, int maxDamage, EWeaponType type){
        this.name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        this.type = type;
    }
}

public enum EWeaponType {
    DIRECT,
    EXPLOSIVE,
    GUIDED
}