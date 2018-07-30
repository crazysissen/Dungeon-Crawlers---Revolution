using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Rarity { Common, Uncommon, Rare, Legendary }

public abstract class Item
{
    static ConsoleColor[] rarityColors = new ConsoleColor[] { ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Yellow };

    public string name, floorName;
    public Rarity rarity;
    public ConsoleColor RarityColor => rarityColors[(int)rarity];

    public Item(string name, Rarity rarity)
    {
        this.name = name;
        this.rarity = rarity;
    }

    public virtual void WriteInspection(bool showFloorName)
    {
        //Console.WriteLine("<------------------->");
        Game.WriteLineColor(name, RarityColor);

        if (showFloorName)
        {
            Game.WriteColor("Found on ", ConsoleColor.DarkGray);
            Game.WriteLineColor(floorName, ConsoleColor.Gray);
        }

        Console.WriteLine();
        //Console.WriteLine(" |||>");
    }
}

public class Weapon : Item
{
    public int damage;

    public Weapon(string name, Rarity rarity, int damage) : base(name, rarity)
    {
        this.damage = damage;
    }

    public override void WriteInspection(bool showFloorName)
    {
        base.WriteInspection(showFloorName);

        Game.WriteColor("Class: ", ConsoleColor.Gray);
        Console.WriteLine("Weapon");

        Game.WriteColor("Damage: ", ConsoleColor.Gray);
        Console.WriteLine(damage);
    }
}

public class Wand : Item
{
    public int magic, mana;

    public Wand(string name, Rarity rarity, int magic, int mana) : base(name, rarity)
    {
        this.magic = magic;
        this.mana = mana;
    }

    public override void WriteInspection(bool showFloorName)
    {
        base.WriteInspection(showFloorName);

        Game.WriteColor("Class: ", ConsoleColor.Gray);
        Console.WriteLine("Wand");

        Game.WriteColor("Magic Power: ", ConsoleColor.Gray);
        Console.WriteLine(magic);

        Game.WriteColor("Mana Bonus: ", ConsoleColor.Gray);
        Console.WriteLine(mana);
    }
}

public class Armor : Item
{
    public int defense, health;

    public Armor(string name, Rarity rarity, int armor, int health) : base(name, rarity)
    {
        this.defense = armor;
        this.health = health;
    }

    public override void WriteInspection(bool showFloorName)
    {
        base.WriteInspection(showFloorName);

        Game.WriteColor("Class: ", ConsoleColor.Gray);
        Console.WriteLine("Armor");

        Game.WriteColor("Defense: ", ConsoleColor.Gray);
        Console.WriteLine(defense);

        Game.WriteColor("Health Bonus: ", ConsoleColor.Gray);
        Console.WriteLine(health);
    }
}

