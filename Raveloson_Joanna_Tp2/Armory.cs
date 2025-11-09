using System;
using System.Collections.Generic;

public class Armory{
    private static List<Weapon> Weapons = new List<Weapon>();

    public Armory(){
        Init();
    }

    private void Init(){
        Weapons.Add(new Weapon("Laser", 2, 3, EWeaponType.DIRECT, 2));
        Weapons.Add(new Weapon("Hammer", 1, 8, EWeaponType.EXPLOSIVE, 1.5));
        Weapons.Add(new Weapon("Torpille", 3, 3, EWeaponType.GUIDED, 2));
        Weapons.Add(new Weapon("Mitrailleuse", 6, 8, EWeaponType.DIRECT, 1));
        Weapons.Add(new Weapon("EMG", 1, 7, EWeaponType.EXPLOSIVE, 1.5));
        Weapons.Add(new Weapon("Missile", 4, 100, EWeaponType.GUIDED, 4));
        Weapons.Add(new Weapon("Grenade", 10, 20, EWeaponType.EXPLOSIVE, 4));
        Weapons.Add(new Weapon("DragonFire", 5, 10, EWeaponType.DIRECT, 3));
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