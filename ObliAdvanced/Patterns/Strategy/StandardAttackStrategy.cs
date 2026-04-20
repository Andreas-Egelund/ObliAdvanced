using System.Collections.Generic;
using System.Linq;
using ObliAdvanced.Items.Base;

namespace ObliAdvanced.Patterns.Strategy
{
    public class StandardAttackStrategy : IAttackStrategy
    {
        public int CalculateAttack(List<AttackItem> weapons)
        {
            return weapons.Sum(w => w.Hit);
        }
    }
}
