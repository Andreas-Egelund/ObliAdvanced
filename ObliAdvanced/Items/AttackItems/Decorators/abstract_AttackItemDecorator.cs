using ObliAdvanced.Items.Base;

namespace ObliAdvanced.Items.AttackItems.Decorators
{
    public abstract class AttackItemDecorator : AttackItem
    {
        protected AttackItem _attackItem;

        protected AttackItemDecorator(AttackItem attackItem) : base(attackItem.Name, attackItem.Range)
        {
            _attackItem = attackItem;
        }

        public override void Add(AttackItem item)
        {
            _attackItem.Add(item);
        }

        public override void Remove(AttackItem item)
        {
            _attackItem.Remove(item);
        }
    }
}
