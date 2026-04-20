namespace ObliAdvanced.Items.Base
{
    /// <summary>
    /// Base class for attack items implementing composite pattern
    /// </summary>
    public abstract class AttackItem
    {
        public string Name { get; set; }
        public abstract int Hit { get; }
        public int Range { get; set; }
        public abstract int Weight { get; }

        protected AttackItem(string name, int range)
        {
            Name = name;
            Range = range;
        }

        public abstract void Add(AttackItem item);
        public abstract void Remove(AttackItem item);
    }
}
