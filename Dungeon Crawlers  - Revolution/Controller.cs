using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Controller
{
    // Start stats
    const int
        startHp = 100,
        startMana = 50,
        startAttack = 20,
        startDefense = 10;

    int seed = 0;
    bool gameRunning, classicLayout;

    // Player stats
    string name;
    int level = 23,
        exp = 0,
        hp = startHp,
        gold = 0,
        mana = startMana,
        floorNumber = 1;

    int ExpToNextLevel
    {
        get
        {
            int value = 100;

            for (int i = 0; i < level; i++)
            {
                value += (int)(Math.Pow(1.25, i + 1) * 100);
            }

            return value;
        }
    }        

    int BaseMaxHp => (int)(startHp * Math.Pow(1.15, level));
    int MaxHp
    {
        get
        {
            int collectiveBonus = 0;
            foreach (Armor item in armors)
            {
                if (item != null)
                {
                    collectiveBonus += item.health;
                }
            }
            return BaseMaxHp + collectiveBonus;
        }
    }

    int MaxMana
    {
        get
        {
            int collectiveBonus = 0;
            foreach (Wand item in wands)
            {
                if (item != null)
                {
                    collectiveBonus += item.mana;
                }
            }
            return startMana + collectiveBonus;
        }
    }

    int BaseAttack => (int)(startAttack * Math.Pow(1.15, level));
    int Attack
    {
        get
        {
            int collectiveBonus = 0;
            foreach (Weapon item in weapons)
            {
                if (item != null)
                {
                    collectiveBonus += item.damage;
                }
            }
            return BaseAttack + collectiveBonus;
        }
    }

    int BaseDefense => (int)(startDefense * Math.Pow(1.15, level));
    int Defense
    {
        get
        {
            int collectiveBonus = 0;
            foreach (Armor item in armors)
            {
                if (item != null)
                {
                    collectiveBonus += item.defense;
                }
            }
            return BaseDefense + collectiveBonus;
        }
    }

    Weapon[] weapons = new Weapon[2];
    Wand[] wands = new Wand[2];
    Armor[] armors = new Armor[5];

    /// <summary>
    /// The startup sequence to the game
    /// </summary>
    public void Start()
    {
        Console.WriteLine("----------------------------------------------");
        Console.Write(" Welcome to ");
        Game.WriteColor("Dungeon Crawlers: ", ConsoleColor.Red);
        Game.WriteLineColor("Extreme Edition", ConsoleColor.Yellow);
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine();

        Game.WriteLineColor("Adventurer, what is your name? ", ConsoleColor.Gray);
        Game.WriteColor("Name: ", ConsoleColor.DarkGray);
        name = Console.ReadLine();
        Console.WriteLine();

        Game.WriteLineColor("What path will you take in these depths?", ConsoleColor.Gray);
        int seedChoice = Game.GetChoiceFromList("Random Seed", "Custom Seed");
        Console.WriteLine();

        if (seedChoice == 0)
        {
            seed = (new Random()).Next(0, 0xFFFFFF);
        }
        else
        {
            Game.WriteColor("Seed: ", ConsoleColor.DarkGray);
            seed = (Console.ReadLine()).GetHashCode();
            Console.WriteLine();
        }

        Game.WriteLineColor("Will you explore the new dungeon, or the old one?", ConsoleColor.Gray);
        classicLayout = Game.GetChoiceFromList("New Open-Ended Layout", "Classic Linear Layout") == 1;
        Console.WriteLine();

        Game.WriteLineColor("Press any button to begin...", ConsoleColor.Red);
        Console.ReadKey(true);

        Console.Clear();
        gameRunning = true;
        Main();
    }

    /// <summary>
    /// The main game loop from which most functions are called
    /// </summary>
    public void Main()
    {
        // Loop for each floor
        while (gameRunning)
        {
            if (classicLayout)
            {
                // Classic floor
                Console.WriteLine("Not yet implemented, press any key to quit...");
                Console.ReadKey(true);
                gameRunning = false;

                return;
            }

            // New floor
            Floor floor = new Floor(seed, floorNumber);

            DrawHeader();

            // Increase floor number
            ++floorNumber;

            Console.ReadKey(true);
        }
    }

    /// <summary>
    /// Draws: Name, exp, level,
    /// hp, mana
    /// </summary>
    void DrawHeader()
    {
        Console.WriteLine("- ------------------- -");

        Console.WriteLine(name + " | EXP: " + exp + "  LEVEL: " + level);

        Console.WriteLine("- ------------------- -");

        Game.WriteColor("HP: ", ConsoleColor.Gray);
        Game.WriteColor(hp + "/" + MaxHp, ConsoleColor.Red);

        Game.WriteColor("  MANA: ", ConsoleColor.Gray);
        Game.WriteLineColor(mana + "/" + MaxMana, ConsoleColor.Blue);

        Console.WriteLine("- ------------------- -");
    }
}
