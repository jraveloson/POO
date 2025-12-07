using System;
using Models.SpaceShips;

namespace Models.SpaceShips
{
    public class Rocinante : Spaceship
    {
        public Rocinante() : base("Rocinante", 2, 4, false)
        {
            AddWeapon(Armory.CreatWeapon(Armory.GetWeaponByName("Torpille")));
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
