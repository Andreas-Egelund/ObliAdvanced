using System;
using ObliAdvanced.Items.Base;

namespace ObliAdvanced.Items.AttackItems
{
    public class SimpleAttackItem : AttackItem
    {
        private int _hit;
        private int _weight;

        public override int Hit => _hit;
        public override int Weight => _weight;

        public SimpleAttackItem(string name, int hit, int range, int weight) : base(name, range)
        {
            _hit = hit;
            _weight = weight;
        }

        public override void Add(AttackItem item)
        {
            throw new NotSupportedException("Cannot add items to a simple attack item");
        }

        public override void Remove(AttackItem item)
        {
            throw new NotSupportedException("Cannot remove items from a simple attack item");
        }
    }
}
