using System.Collections.Generic;
using System.Linq;
using ObliAdvanced.Items.Base;

namespace ObliAdvanced.Patterns.Strategy
{
    public class BerserkerAttackStrategy : IAttackStrategy
    {
        public int CalculateAttack(List<AttackItem> weapons)
        {
            return (int)(weapons.Sum(w => w.Hit) * 1.5);
        }
    }
}
