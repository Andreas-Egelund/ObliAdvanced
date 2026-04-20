using ObliAdvanced.Entities.Base;

namespace ObliAdvanced.Patterns.Observer
{
    public interface ICreatureObserver
    {
        void OnCreatureHit(Creature creature, int damage);
        void OnCreatureDeath(Creature creature);
    }
}
