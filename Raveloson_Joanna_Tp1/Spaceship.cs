using System;
using System.Collections.Generic;
using System.Linq;

public class Spaceship
{
    public int MaxStructure { get; set; }
    public int MaxShield { get; set; }
    public int CurrentStructure { get; set; }
    public int CurrentShield { get; set; }
    public bool IsDestroyed { get { return CurrentStructure <= 0; }}

    public List<Weapon> weapons { get; } = new List<Weapon>();

    public Spaceship(){ }

    public void AddWeapon(Weapon weapon){
        if(this.weapons.Count >=3)
        {
            Console.WriteLine("No more than 3 weapons");
            return;
        }
        if(!Armory.IsWeaponFromArmory(weapon))
        {
            Console.WriteLine("This weapon doesn't exist in the armory");
            return;
        }
        this.weapons.Add(weapon);
    }

    public void RemoveWeapon(Weapon oWeapon)
    {
        if(this.weapons.Contains(oWeapon))
            this.weapons.Remove(oWeapon);
    }

    public void ClearWeapons()
    {
       this.weapons.Clear();
    }

    public void ViewWeapons()
    {
        if (weapons.Count == 0)
        {
            Console.WriteLine("No weapon");
            return;
        }

        Console.WriteLine("=== Weapons ===");
        foreach (var w in weapons)
        {
            Console.WriteLine($"{w.Name} | Damage: {w.MinDamage}-{w.MaxDamage} | Type: {w.Type}");
        }
    }

    public double AverageDamages(){
        if (weapons.Count == 0) return 0;

        return weapons.Average(w => (w.MinDamage + w.MaxDamage) / 2.0);
    }

    public void ViewShip()
{
    Console.WriteLine("=== Spaceship Info ===");
    Console.WriteLine($"Structure: {CurrentStructure}/{MaxStructure}");
    Console.WriteLine($"Shield: {CurrentShield}/{MaxShield}");
    Console.WriteLine($"Destroyed: {(IsDestroyed ? "Yes" : "No")}");
    Console.WriteLine($"Average Damage: {AverageDamages():0.0}");
    
    ViewWeapons();
}
}