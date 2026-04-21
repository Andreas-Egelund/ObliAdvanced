using System;
using System.Diagnostics;
using ObliAdvanced.Core;
using ObliAdvanced.Entities.Creatures;
using ObliAdvanced.Entities.Objects;
using ObliAdvanced.Items.AttackItems;
using ObliAdvanced.Items.Base;
using ObliAdvanced.Patterns.Observer;
using ObliAdvanced.Utilities;

class Program
{
    static void Main()
    {
        // Setup logger to output to console
        var consoleListener = new ConsoleTraceListener();
        MyLogger.Instance.AddListener(consoleListener);

        /*
        ConfigurationManager config = new ConfigurationManager();

        config.LoadConfiguration("config.xml");

    */

        // Create world
        var world = new World(20, 20);

        // Create creatures
        var warrior = new Warrior("Conan", new Position(1, 1));
        var mage = new Mage("Merlin", new Position(2, 2));

        // Add observer for logging
        var observer = new GameLogger();
        warrior.AddObserver(observer);
        mage.AddObserver(observer);

        // Add creatures to world
        world.AddCreature(warrior);
        world.AddCreature(mage);

        // Create and add items
        var sword = new SimpleAttackItem("Sword", hit: 15, range: 1, weight: 5);
        var shield = new DefenceItem("Shield", reduceHitPoint: 5);
        warrior.AddAttackItem(sword);
        warrior.AddDefenceItem(shield);

        // Add a treasure chest
        var chest = new TreasureChest(new Position(3, 3));
        world.AddWorldObject(chest);

        // Simulate attack
        int damage = warrior.Hit();
        mage.ReceiveHit(damage);

        // Simulate looting
        warrior.Loot(chest);

        // Clean up logger
        MyLogger.Instance.RemoveListener(consoleListener);

        Console.WriteLine("Demo complete. Press any key to exit.");
        Console.ReadKey();
    }
}