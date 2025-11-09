using System;
using Models.SpaceShips;

namespace Models.SpaceShips
{
    public class Rocinante : Spaceship
    {
        public Rocinante()
        {
            MaxStructure = 3;
            MaxShield = 5;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;

            AddWeapon(new Weapon("Torpille", 3, 3, EWeaponType.GUIDED, 2));
        }

        public override void TakeDamage(double totalDamage)
        {
            Random rand = new Random();
            int chance = rand.Next(1, 5);
            if (chance == 1)
            {
                Console.WriteLine("Rocinante esquive habilement le tir !");
                return;
            }
            
            else {
                base.TakeDamage(totalDamage);
            }
        }
    }
}
