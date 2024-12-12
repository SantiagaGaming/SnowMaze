using System;

public class Maze
{
    private int[,] _maze;
    private int _x;
    private int _y;
    private int _tempX = 1;
    private int _tempY = 1;

    public Maze(int x, int y)
    {
        _x = x;
        _y = y;
        _maze = new int[x, y];
    }

    public int[,] GetMaze => _maze;
    public void GenerateMaze()
    {
        GenerateWalls();
        GeneratePath();
        GenerateMoreWalls();
    }

    private void GenerateWalls()
    {
        for (int i = 0; i < _x; i++)
        {
            for (int j = 0; j < _y; j++)
            {
                if (i == 0 || j == 0 || i == _x - 1 || j == _y - 1)
                    _maze[i, j] = Helper.WALL;
            }
        }
    }
    private void GeneratePath()
    {
        _maze[1, 1] = Helper.START;

        while (true)
        {
            int choice = UnityEngine.Random.Range(0, 2);
            if (choice == 0)
                _tempX++;
            else
                _tempY++; 

            if (_tempX >= _x-1 || _tempY >= _y-1)
            {
                _maze[_tempX , _tempY] = Helper.FINISH;
                return;
            }

            if (_maze[_tempX, _tempY] != Helper.WALL)
                _maze[_tempX, _tempY] = Helper.FLOOR;
        }
    }

    private void GenerateMoreWalls()
    {
        for (int i = 1; i < _x - 1; i++)
        {
            for (int j = 1; j < _y - 1; j++)
            {
                if (_maze[i, j] == Helper.EMPTY) 
                {
                    int choice = UnityEngine.Random.Range(0, 2);
                    _maze[i, j] = choice == 0 ? Helper.WALL : _maze[i, j];
                }
            }
        }
    }
}