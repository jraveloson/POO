using System;
using Models.SpaceShips;

namespace Models.SpaceShips
{
    public class B_Wings : Spaceship
    {
        public B_Wings() : base("B-Wings", 30, 0, false)
        {
            AddWeapon(Armory.CreatWeapon(Armory.GetWeaponByName("Hammer")));
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

