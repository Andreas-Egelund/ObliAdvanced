using ObliAdvanced.Core;

namespace ObliAdvanced.Entities.Base
{
    public abstract class WorldObject
    {
        /// <summary>
        /// Name of the world object
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Whether the object can be looted by creatures
        /// </summary>
        public bool Lootable { get; set; }
        
        /// <summary>
        /// Whether the object can be removed from the world
        /// </summary>
        public bool Removeable { get; set; }
        
        /// <summary>
        /// Position of the object in the world
        /// </summary>
        public Position Position { get; set; }

        protected WorldObject(string name, bool lootable, bool removeable, Position position)
        {
            Name = name;
            Lootable = lootable;
            Removeable = removeable;
            Position = position;
        }
    }
}
