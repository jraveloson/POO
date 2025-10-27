using System;
using System.Collections.Generic;

public class Armory{
    private static List<Weapon> Weapons = new List<Weapon>();

    public Armory(){
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
            Console.WriteLine($"{weapon.Name} | Damage: {weapon.MinDamage}-{weapon.MaxDamage} | Type: {weapon.Type}");
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
        Weapons.Add(weapon);
    }

    public static bool IsWeaponFromArmory(Weapon weapon)
    {
        return Weapons.Contains(weapon);
    }

}