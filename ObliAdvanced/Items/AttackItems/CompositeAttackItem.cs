using System.Collections.Generic;
using System.Linq;
using ObliAdvanced.Items.Base;
using ObliAdvanced.Utilities;

namespace ObliAdvanced.Items.AttackItems
{
    public class CompositeAttackItem : AttackItem
    {
        private readonly List<AttackItem> _items = new List<AttackItem>();
        private int _maxWeight;

        public override int Hit => _items.Sum(item => item.Hit);
        public override int Weight => _items.Sum(item => item.Weight);

        public CompositeAttackItem(string name, int range, int maxWeight) : base(name, range)
        {
            _maxWeight = maxWeight;
        }

        public override void Add(AttackItem item)
        {
            if (Weight + item.Weight <= _maxWeight)
            {
                _items.Add(item);
                MyLogger.Instance.Log($"Added {item.Name} to {Name}");
            }
            else
            {
                MyLogger.Instance.Log($"Cannot add {item.Name} to {Name} - weight limit exceeded");
            }
        }

        public override void Remove(AttackItem item)
        {
            _items.Remove(item);
            MyLogger.Instance.Log($"Removed {item.Name} from {Name}");
        }
    }
}
