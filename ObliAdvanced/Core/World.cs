using System;
using System.Collections.Generic;
using System.Linq;
using ObliAdvanced.Entities.Base;
using ObliAdvanced.Utilities;

namespace ObliAdvanced.Core
{
    /// <summary>
    /// Represents the 2D game world containing creatures and objects
    /// </summary>
    public class World
    {
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        
        private readonly List<Creature> _creatures = new List<Creature>();
        private readonly List<WorldObject> _worldObjects = new List<WorldObject>();

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            MyLogger.Instance.Log($"World created with dimensions {MaxX}x{MaxY}");
        }

        public void AddCreature(Creature creature)
        {
            if (IsValidPosition(creature.Position))
            {
                _creatures.Add(creature);
                MyLogger.Instance.Log($"Added creature {creature.Name} at position ({creature.Position.X}, {creature.Position.Y})");
            }
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            if (IsValidPosition(worldObject.Position))
            {
                _worldObjects.Add(worldObject);
                MyLogger.Instance.Log($"Added world object {worldObject.Name} at position ({worldObject.Position.X}, {worldObject.Position.Y})");
            }
        }

        public void RemoveWorldObject(WorldObject worldObject)
        {
            if (worldObject.Removeable && _worldObjects.Remove(worldObject))
            {
                MyLogger.Instance.Log($"Removed world object {worldObject.Name}");
            }
        }

        private bool IsValidPosition(Position position)
        {
            return position.X >= 0 && position.X < MaxX && position.Y >= 0 && position.Y < MaxY;
        }

        public IReadOnlyList<Creature> Creatures => _creatures.AsReadOnly();
        public IReadOnlyList<WorldObject> WorldObjects => _worldObjects.AsReadOnly();
    }
}
