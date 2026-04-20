using ObliAdvanced.Core;
using ObliAdvanced.Entities.Base;

namespace ObliAdvanced.Entities.Objects
{
    public class Wall : WorldObject
    {
        public Wall(Position position) : base("Wall", false, false, position)
        {
        }
    }
}
