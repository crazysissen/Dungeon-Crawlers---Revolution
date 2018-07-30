using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static Controller MainController { get; private set; }

    static void Main(string[] args)
    {
        Console.Title = "Dungeon Crawlers: Extreme Edition";
        Console.ForegroundColor = ConsoleColor.White;
        MainController = new Controller();
        MainController.Start();
    }
}
