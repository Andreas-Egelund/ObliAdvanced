using System;
using System.Collections.Generic;
using System.Linq;
using ObliAdvanced.Core;
using ObliAdvanced.Items.Base;
using ObliAdvanced.Patterns.Observer;
using ObliAdvanced.Patterns.Strategy;
using ObliAdvanced.Utilities;

namespace ObliAdvanced.Entities.Base
{
    /// <summary>
    /// Abstract base class for all creatures implementing template method pattern
    /// </summary>
    public abstract class Creature : WorldObject
    {
        private readonly List<ICreatureObserver> _observers = new List<ICreatureObserver>();
        private readonly List<AttackItem> _attackItems = new List<AttackItem>();
        private readonly List<DefenceItem> _defenceItems = new List<DefenceItem>();

        public int HitPoint { get; protected set; }
        public IAttackStrategy AttackStrategy { get; set; }

        protected Creature(string name, int hitPoint, Position position) : base(name, false, false, position)
        {
            HitPoint = hitPoint;
            AttackStrategy = new StandardAttackStrategy();
        }

        // Observer Pattern
        public void AddObserver(ICreatureObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(ICreatureObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void NotifyHit(int damage)
        {
            foreach (var observer in _observers)
            {
                observer.OnCreatureHit(this, damage);
            }
        }

        protected void NotifyDeath()
        {
            foreach (var observer in _observers)
            {
                observer.OnCreatureDeath(this);
            }
        }

        // Template Method Pattern
        public int Hit()
        {
            int baseDamage = CalculateBaseDamage();
            int weaponDamage = AttackStrategy.CalculateAttack(_attackItems);
            int totalDamage = baseDamage + weaponDamage;
            
            MyLogger.Instance.Log($"{Name} attacks for {totalDamage} damage");
            return totalDamage;
        }

        protected abstract int CalculateBaseDamage();

        public virtual void ReceiveHit(int hit)
        {
            int totalDefence = _defenceItems.Sum(d => d.ReduceHitPoint);
            int actualDamage = Math.Max(0, hit - totalDefence);
            
            HitPoint -= actualDamage;
            MyLogger.Instance.Log($"{Name} receives {actualDamage} damage (reduced from {hit} by {totalDefence} defence)");
            
            NotifyHit(actualDamage);
            
            if (HitPoint <= 0)
            {
                MyLogger.Instance.Log($"{Name} has died!");
                NotifyDeath();
            }
        }

        public virtual void Loot(WorldObject worldObject)
        {
            if (worldObject.Lootable)
            {
                MyLogger.Instance.Log($"{Name} looted {worldObject.Name}");
                // Implementation for specific loot types would go here
            }
        }

        public void AddAttackItem(AttackItem item)
        {
            _attackItems.Add(item);
        }

        public void AddDefenceItem(DefenceItem item)
        {
            _defenceItems.Add(item);
        }
    }
}
