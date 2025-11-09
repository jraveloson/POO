using System;
using Models.SpaceShips;

namespace Models.SpaceShips
{
    public class ViperMKII : Spaceship
    {
        public ViperMKII()
        {
            MaxStructure = 10;
            MaxShield = 15;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;

            AddWeapon(new Weapon("Mitrailleuse", 6, 8, EWeaponType.DIRECT, 1));
            AddWeapon(new Weapon("EMG", 1, 7, EWeaponType.EXPLOSIVE, 1.5));
            AddWeapon(new Weapon("Missile", 4, 100, EWeaponType.GUIDED, 4));
            }

            public override void ShootTarget(Spaceship target)
            {
                var readyWeapons = weapons
                .Where(w => w.TimeBeforReload <= 0)
                .ToList();
                if (readyWeapons.Count == 0)
                {
                    Console.WriteLine("No weapon is ready to fire !");
                }
                Random rnd = new Random();
                int index = rnd.Next(readyWeapons.Count);

                double damage = readyWeapons[index].Shoot();
                target.TakeDamage(damage);
            }
        }

}
