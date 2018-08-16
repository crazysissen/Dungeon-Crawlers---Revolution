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

    readonly static float[] borderRoomChance = new float[] { 0.6f, 0.8f };

    public Floor(int seed, int floorNumber)
    {
        Generate(seed, floorNumber);
    }

    public void Generate(int seed, int floorNumber)
    {
        r = new Random(seed * floorNumber);
        roomGrid = new Room[width, height];

        width = r.Next(minWidth, maxWidth + 1);
        height = r.Next(minWidth, maxWidth + 1);

        bool[,] layout = FillRoomLayout(width, height, r);

        List<Vector> eglibleRooms = new List<Vector>();
        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {

            }
        }
    }

    public static bool[,] FillRoomLayout(int width, int height, Random random)
    {
        bool[,] array = new bool[width, height];

        for (int x = 0; x < width; ++x)
        {
            int distanceToBorderX = Math.Min(x, width - x - 1);

            for (int y = 0; y < height; ++y)
            {
                int distanceToBorder = Math.Min(distanceToBorderX, Math.Min(y, height - y - 1));

                if (distanceToBorder >= borderRoomChance.Length)
                {
                    array[x, y] = true;
                    continue;
                }

                array[x, y] = Game.RandomFloat(random, 0, 1) < borderRoomChance[distanceToBorder];
            }
        }

        return array;
    }
}