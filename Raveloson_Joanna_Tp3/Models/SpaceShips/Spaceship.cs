using System;
using System.Collections.Generic;
using System.Linq;
using Models.SpaceShips;

namespace Models.SpaceShips
{

    public class Spaceship : ISpaceship
    {
        public string Name { get; set; }
        public double MaxStructure { get; set; }
        public double MaxShield { get; set; }
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public bool IsDestroyed { get { return CurrentStructure <= 0; }}
        public bool BelongsPlayer { get; private set; }
        public double AverageDamages => (weapons.Sum(x => x.MinDamage) + weapons.Sum(x => x.MaxDamage)) / 2;
        public int MaxWeapons { get; } = 3;

        public List<Weapon> weapons { get; } = new List<Weapon>();

        public Spaceship(string name, int maxStructure, int maxShield, bool belongsPlayer) 
        {
            this.Name = name;
            this.MaxStructure = maxStructure;
            this.MaxShield = maxShield;
            this.CurrentStructure = maxStructure;
            this.CurrentShield = maxShield;
            this.BelongsPlayer = belongsPlayer;
        }

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

        public void ViewShip()
        {
            Console.WriteLine("=== Spaceship Info ===");
            Console.WriteLine($"Structure: {CurrentStructure}/{MaxStructure}");
            Console.WriteLine($"Shield: {CurrentShield}/{MaxShield}");
            Console.WriteLine($"Destroyed: {(IsDestroyed ? "Yes" : "No")}");
            Console.WriteLine($"Average Damage: {AverageDamages:0.0}");
            
            ViewWeapons();
        }

        public virtual void TakeDamage(double totalDamage)
        {
            if (IsDestroyed)
                return;

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
                return;
        }

        public virtual void ShootTarget(Spaceship target)
        {
            if (IsDestroyed)
                return;

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

        public void ReloadWeapons()
        {
            foreach (var item in weapons)
            {
                item.TimeBeforReload--;
            }
        }

        public void RepairShield(double repair)
        {
            CurrentShield += repair;
            if (CurrentShield > MaxShield) { CurrentShield = MaxShield; }
        }
    }
}