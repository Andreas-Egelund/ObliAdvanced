using ObliAdvanced.Core;
using ObliAdvanced.Entities.Base;

namespace ObliAdvanced.Entities.Creatures
{
    public class Mage : Creature
    {
        public Mage(string name, Position position) : base(name, 70, position)
        {
        }

        protected override int CalculateBaseDamage()
        {
            return 15; // Mages have high magical base damage but low health
        }
    }
}
