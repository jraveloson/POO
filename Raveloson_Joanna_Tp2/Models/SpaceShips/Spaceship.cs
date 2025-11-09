using System;
using System.Collections.Generic;
using System.Linq;
using Models.SpaceShips;

namespace Models.SpaceShips
{

    public class Spaceship
    {
        public double MaxStructure { get; set; }
        public double MaxShield { get; set; }
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public bool IsDestroyed { get { return CurrentStructure <= 0; }}

        public List<Weapon> weapons { get; } = new List<Weapon>();

        public void AddWeapon(Weapon weapon){
            if(this.weapons.Count >=3)
            {
                Console.WriteLine("No more than 3 weapons");
                return;
            }
            if(!Armory.IsWeaponFromArmory(weapon))
            {
                Console.WriteLine($"{weapon.Name} doesn't exist in the armory");
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

        public virtual void TakeDamage(double totalDamage)
        {
            if (totalDamage <= 0)
            {
                Console.WriteLine("No damage caused !");
                return;
            }

            Console.WriteLine($"The spaceship takes {totalDamage} damage points !");

            // Les boucliers encaissent d'abord
            if (CurrentShield > 0)
            {
                if (totalDamage <= CurrentShield)
                {
                    CurrentShield -= totalDamage;
                    totalDamage = 0;
                }
                else
                {
                    totalDamage -= CurrentShield;
                    CurrentShield = 0;
                }
            }

            if (totalDamage > 0)
            {
                CurrentStructure -= totalDamage;
                if (CurrentStructure < 0)
                    CurrentStructure = 0;
            }

            // Résumé
            Console.WriteLine($"→ Shield : {CurrentShield}/{MaxShield}");
            Console.WriteLine($"→ Structure : {CurrentStructure}/{MaxStructure}");

            if (IsDestroyed)
                Console.WriteLine("The spaceship is destroyed !");
        }

        public virtual void ShootTarget(Spaceship target)
        {
            if (weapons.Count == 0)
            {
                Console.WriteLine("No weapon to shoot !");
                return;
            }

            double totalDamage = 0;
            foreach (var weapon in weapons)
            {
                double damage = weapon.Shoot();
                totalDamage += damage;
            }

            target.TakeDamage(totalDamage);
        }
    }
}