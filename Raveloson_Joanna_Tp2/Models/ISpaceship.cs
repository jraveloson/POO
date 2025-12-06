using Models.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface ISpaceship
    {
        string Name { get; set; }
        double MaxStructure { get; set; }
        double MaxShield { get; set; }
        bool IsDestroyed { get; }
        int MaxWeapons { get; }
        List<Weapon> weapons { get; }
        double AverageDamages { get; }
        double CurrentStructure { get; set; }
        double CurrentShield { get; set; }
        bool BelongsPlayer { get; }
        void TakeDamage(double damage);
        void RepairShield(double repair);
        void ShootTarget(Spaceship target);
        void ReloadWeapons();
        void AddWeapon(Weapon weapon);
        void RemoveWeapon(Weapon oWeapon);
        void ClearWeapons();
        void ViewShip();
        void ViewWeapons();
        
    }
}