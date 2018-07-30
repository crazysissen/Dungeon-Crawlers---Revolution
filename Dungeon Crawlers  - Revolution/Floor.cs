using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Floor
{
    const int
        minWidth = 4,
        maxWidth = 8;

    int width, height;

    Random r;
    Room[,] roomGrid;
    Room[] rooms;

    public Floor(int seed, int floorNumber)
    {
        Generate(seed, floorNumber);
    }

    public void Generate(int seed, int floorNumber)
    {
        r = new Random(seed * floorNumber);

        width = r.Next(minWidth, maxWidth + 1);
        height = r.Next(minWidth, maxWidth + 1);

        roomGrid = new Room[width, height];
    }
}