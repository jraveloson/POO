using System;
using System.Collections.Generic;

public class Armory{
    private List<Weapon> Weapons;

    public Armory(){
        Weapons = new List<Weapon>();
        Init();
    }

    private void Init(){
        Weapons.Add(new Weapon("DragonFire", 5, 10, EWeaponType.DIRECT));
        Weapons.Add(new Weapon("Missile", 15, 25, EWeaponType.GUIDED));
        Weapons.Add(new Weapon("Grenade", 10, 20, EWeaponType.EXPLOSIVE));
    }

    public void ViewArmory(){
        Console.WriteLine("=== Armory ===");
        foreach (var weapon in Weapons)
        {
            Console.WriteLine($"{weapon.name} | Damage: {weapon.MinDamage}-{weapon.MaxDamage} | Type: {weapon.type}");
        }
    }

    public Weapon? GetWeapon(int index)
    {
        if (index >= 0 && index < Weapons.Count)
            return Weapons[index];

        return null;
    }

    public void AddWeapon(Weapon weapon)
    {
        this.Weapons.Add(weapon);
    }


}