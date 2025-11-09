using System;
using System.Collections.Generic;
using Models.SpaceShips;

namespace Models.SpaceShips
{
    public class F18 : Spaceship, IAbility{

        public F18(){
            MaxStructure = 15;
            MaxShield = 0;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            for (int i = 0; i < spaceships.Count; i++)
            {
                if (spaceships[i] is ViperMKII)
                {
                    int joueur = i;
                    if (spaceships[i+1] is F18 || spaceships[i-1] is F18)
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
