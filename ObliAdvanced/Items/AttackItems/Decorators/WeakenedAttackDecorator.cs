using System;
using ObliAdvanced.Items.Base;

namespace ObliAdvanced.Items.AttackItems.Decorators
{
    public class WeakenedAttackDecorator : AttackItemDecorator
    {
        private int _penalty;

        public override int Hit => Math.Max(0, _attackItem.Hit - _penalty);
        public override int Weight => _attackItem.Weight;

        public WeakenedAttackDecorator(AttackItem attackItem, int penalty) : base(attackItem)
        {
            _penalty = penalty;
            Name = $"Weakened {attackItem.Name}";
        }
    }
}
