using System;
using Models.SpaceShips;

namespace Models.SpaceShips
{
    public class Dart : Spaceship
    {
        public Dart()
        {
            MaxStructure = 10;
            MaxShield = 3;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;

            AddWeapon(new Weapon("Laser", 2, 3, EWeaponType.DIRECT, 2));
        }

        public override void ShootTarget(Spaceship target)
        {
            if (weapons.Count == 0)
            {
                Console.WriteLine("No weapon to shoot !");
                return;
            }

            double totalDamage = 0;
            foreach (var weapon in weapons)
            {
                double reloadTime = weapon.ReloadTime;
                if (weapon.Type == EWeaponType.DIRECT)
                {
                    weapon.ReloadTime = 0;
                }
                double damage = weapon.Shoot();
                totalDamage += damage;
                weapon.ReloadTime = reloadTime;
            }

            target.TakeDamage(totalDamage);
        }
    }
}

