using ObliAdvanced.Core;
using ObliAdvanced.Entities.Base;

namespace ObliAdvanced.Entities.Creatures
{
    public class Warrior : Creature
    {
        public Warrior(string name, Position position) : base(name, 100, position)
        {
        }

        protected override int CalculateBaseDamage()
        {
            return 10; // Warriors have higher base damage
        }
    }
}
