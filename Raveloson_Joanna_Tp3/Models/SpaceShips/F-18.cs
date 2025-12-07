using System;
using System.Collections.Generic;
using Models.SpaceShips;

namespace Models.SpaceShips
{
    public class F18 : Spaceship, IAbility{

        public F18() : base("F-18", 5, 0, false){}

        public void UseAbility(List<Spaceship> spaceships)
        {
            for (int i = 0; i < spaceships.Count; i++)
            {
                if (spaceships[i] is ViperMKII)
                {
                    int joueur = i;
                    if (i > 0 && spaceships[i - 1] is F18 || i < spaceships.Count - 1 && spaceships[i + 1] is F18)
                    {
                        Console.WriteLine("Le F-18 explodes !");
                        spaceships[joueur].TakeDamage(10);
                        this.CurrentStructure = 0;
                    }
                }
            }
        }

    }
}
