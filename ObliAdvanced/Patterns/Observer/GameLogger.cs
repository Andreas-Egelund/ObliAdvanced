using ObliAdvanced.Entities.Base;
using ObliAdvanced.Utilities;

namespace ObliAdvanced.Patterns.Observer
{
    public class GameLogger : ICreatureObserver
    {
        public void OnCreatureHit(Creature creature, int damage)
        {
            MyLogger.Instance.Log($"Observer: {creature.Name} took {damage} damage, HP: {creature.HitPoint}");
        }



        public void OnCreatureDeath(Creature creature)
        {
            MyLogger.Instance.Log($"Observer: {creature.Name} has fallen in battle!");
        }
    }
}
