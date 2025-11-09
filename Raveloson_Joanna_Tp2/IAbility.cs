using System.Collections.Generic;
using Models.SpaceShips;

public interface IAbility
{
    void UseAbility(List<Spaceship> spaceships);
}
