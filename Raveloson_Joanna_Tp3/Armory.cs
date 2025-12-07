using System;
using System.Collections.Generic;

public static class Armory{
    public static List<Weapon> Weapons = new List<Weapon>();

    static Armory(){
        Weapons.Add(new Weapon("Laser", 2, 3, EWeaponType.DIRECT, 2));
        Weapons.Add(new Weapon("Hammer", 1, 8, EWeaponType.EXPLOSIVE, 1.5));
        Weapons.Add(new Weapon("Torpille", 3, 3, EWeaponType.GUIDED, 2));
        Weapons.Add(new Weapon("Mitrailleuse", 6, 8, EWeaponType.DIRECT, 1));
        Weapons.Add(new Weapon("EMG", 1, 7, EWeaponType.EXPLOSIVE, 1.5));
        Weapons.Add(new Weapon("Missile", 4, 100, EWeaponType.GUIDED, 4));
        Weapons.Add(new Weapon("Grenade", 10, 20, EWeaponType.EXPLOSIVE, 4));
        Weapons.Add(new Weapon("DragonFire", 5, 10, EWeaponType.DIRECT, 3));
    }

    public static void ViewArmory(){
        Console.WriteLine("=== Armory ===");
        foreach (var weapon in Weapons)
        {
            Console.WriteLine($"{weapon.Name} | Damage: {weapon.MinDamage}-{weapon.MaxDamage} | Type: {weapon.Type}");
        }
    }

    public static Weapon? GetWeapon(int index)
    {
        if (index >= 0 && index < Weapons.Count)
            return Weapons[index];

        return null;
    }

    public static Weapon CreatWeapon(Weapon weapon)
    {
        Weapon w = new Weapon(weapon);
        if (!IsWeaponFromArmory(w)) { throw new ArmoryException(); }
        return w;
    }

    public static bool IsWeaponFromArmory(Weapon weapon)
    {
        return Weapons.Exists(w => w.Name == weapon.Name);
    }

    public static Weapon? GetWeaponByName(string name)
    {
        return Weapons.FirstOrDefault(w => w.Name == name);
    }

    public static List<Weapon> Get5StrongestWeaponsByAverageDamage()
    {
        return Weapons
            .OrderByDescending(w => w.AverageDamage)
            .Take(5)
            .ToList();
    }

    public static List<Weapon> Get5HighestMinDamageWeapons()
    {
        return Weapons
            .OrderByDescending(w => w.MinDamage)
            .Take(5)
            .ToList();
    }

}