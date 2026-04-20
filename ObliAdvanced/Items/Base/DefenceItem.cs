namespace ObliAdvanced.Items.Base
{
    /// <summary>
    /// Represents defensive equipment that reduces incoming damage
    /// </summary>
    public class DefenceItem
    {
        public string Name { get; set; }
        public int ReduceHitPoint { get; set; }

        public DefenceItem(string name, int reduceHitPoint)
        {
            Name = name;
            ReduceHitPoint = reduceHitPoint;
        }
    }
}
