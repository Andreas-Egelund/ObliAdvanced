using System.Collections.Generic;
using ObliAdvanced.Items.Base;

namespace ObliAdvanced.Patterns.Strategy
{
    public interface IAttackStrategy
    {
        int CalculateAttack(List<AttackItem> weapons);
    }
}
