using System;
using System.Collections.Generic;
using Models.SpaceShips;

namespace Models.SpaceShips
{
    public class Tardis : Spaceship, IAbility{

        public Tardis(){
            MaxStructure = 1;
            MaxShield = 0;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            // Déplacer un vaisseau au hasard et le mettre à un endroit au hasard de la liste
            Random rand = new Random();
            int i = rand.Next(spaceships.Count);
            Spaceship selectedSpaceship = spaceships[i];
            spaceships.RemoveAt(i);
            int newPosition = rand.Next(spaceships.Count + 1);
            spaceships.Insert(newPosition, selectedSpaceship);
        }

    }
}