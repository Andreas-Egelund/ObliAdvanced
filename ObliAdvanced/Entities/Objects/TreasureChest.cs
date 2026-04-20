using ObliAdvanced.Core;
using ObliAdvanced.Entities.Base;

namespace ObliAdvanced.Entities.Objects
{
    public class TreasureChest : WorldObject
    {
        public TreasureChest(Position position) : base("Treasure Chest", true, true, position)
        {
        }
    }
}
