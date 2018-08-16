using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Vector
{
    public int x, y;

    public Vector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

class Grid<T>
{
    T[,] grid;

    public T this[int x, int y]
    {
        get => grid[x, y];
        set => grid[x, y] = value;
    }

    public T this[Vector vector]
    {
        get => grid[vector.x, vector.y];
        set => grid[vector.x, vector.y] = value;
    }

    public Grid(int width, int height)
    {
        grid = new T[width, height];
    }

    public Grid(T[,] array)
    {
        grid = array;
    }

    public static implicit operator Grid<T> (T[,] a)
    {
        return new Grid<T>(a);
    }

    public static implicit operator T[,] (Grid<T> a)
    {
        return a.grid;
    }
}

