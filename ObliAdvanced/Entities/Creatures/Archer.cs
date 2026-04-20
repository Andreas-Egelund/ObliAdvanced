using ObliAdvanced.Core;
using ObliAdvanced.Entities.Base;

namespace ObliAdvanced.Entities.Creatures
{
    public class Archer : Creature
    {
        public Archer(string name, Position position) : base(name, 80, position)
        {
        }

        protected override int CalculateBaseDamage()
        {
            return 8; // Archers have moderate base damage
        }
    }
}
