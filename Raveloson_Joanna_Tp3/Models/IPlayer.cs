using Models.SpaceShips;

namespace Models
{
    public interface IPlayer
    {
        Spaceship spaceship { get; set; }
        string Name { get; }
        string Alias { get; }
    }
}