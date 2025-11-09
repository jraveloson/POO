using System;
using Models.SpaceShips;

namespace Models.SpaceShips
{
    public class B_Wings : Spaceship
    {
        public B_Wings()
        {
            MaxStructure = 30;
            MaxShield = 0;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;

            AddWeapon(new Weapon("Hammer", 1, 8, EWeaponType.EXPLOSIVE, 1.5));
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
                if (weapon.Type == EWeaponType.EXPLOSIVE)
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

