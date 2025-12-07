using System;
using Models.SpaceShips;

namespace Models.SpaceShips
{
    public class ViperMKII : Spaceship
    {
        public ViperMKII() : base("Viper MK II", 3, 5, false) 
        {
            AddWeapon(Armory.CreatWeapon(Armory.GetWeaponByName("Mitrailleuse")));
            AddWeapon(Armory.CreatWeapon(Armory.GetWeaponByName("EMG")));
            AddWeapon(Armory.CreatWeapon(Armory.GetWeaponByName("Missile")));
        }

            public override void ShootTarget(Spaceship target)
            {
                var readyWeapons = weapons
                .Where(w => w.TimeBeforReload <= 0)
                .ToList();
                if (readyWeapons.Count == 0)
                {
                    Console.WriteLine("No weapon is ready to fire !");
                    return;
                }
                Random rnd = new Random();
                int index = rnd.Next(readyWeapons.Count);

                double damage = readyWeapons[index].Shoot();
                target.TakeDamage(damage);
            }
        }

}
