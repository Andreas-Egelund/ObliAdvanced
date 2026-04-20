using ObliAdvanced.Items.Base;

namespace ObliAdvanced.Items.AttackItems.Decorators
{
    public class EnhancedAttackDecorator : AttackItemDecorator
    {
        private int _bonus;

        public override int Hit => _attackItem.Hit + _bonus;
        public override int Weight => _attackItem.Weight;

        public EnhancedAttackDecorator(AttackItem attackItem, int bonus) : base(attackItem)
        {
            _bonus = bonus;
            Name = $"Enhanced {attackItem.Name}";
        }
    }
}
