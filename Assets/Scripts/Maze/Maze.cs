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
public int[,] GetMaze()
    {
        return _maze;
    }
       
        public void GenerateWalls()
        {
            for (int i = 0; i < _x; i++)
            {
                for (int j = 0; j < _y; j++)
                {
                    if (i == 0 || j == 0 || i == _x - 1 || j == _y - 1)
                    {
                        _maze[i, j] = 1;
                    }
                }

            }

        }
        public void GeneratePath()
        {
            _maze[1, 1] = 3;
            while (true)
            {
            int choice = UnityEngine.Random.Range(0, 2);
            if (choice == 0)
                {
                    _tempX++;
                }
                else if(choice == 1)
                {
                    _tempY++;
                }
                if (_tempX >= _x || _tempY >= _y)
            {
                _maze[_tempX - 2, _tempY - 2] = 4;
                return;
            }
             

                if (_maze[_tempX, _tempY] ==1)
            {
                _maze[_tempX, _tempY] = 1;
            }
                else
            { _maze[_tempX, _tempY] = 2; }
              
            
            }
        }
        public void GenerateMaze()
        {
            for (int i = 0; i < _x; i++)
            {
                for (int j = 0; j < _y; j++)
                {
                    if (_maze[i, j] == 1)
                    {
                        _maze[i, j] = 1;
                    }
                    else if(_maze[i, j] == 2)
                {
                    _maze[i, j] = 2;
                }
                    else if(_maze[i, j] == 3)
                {
                    _maze[i, j] = 3;
                }
                else if (_maze[i, j] == 4)
                {
                    _maze[i, j] = 4;
                }
                else
                    {
                    int choice = UnityEngine.Random.Range(0, 2);
                        if (choice == 0)
                        {
                            _maze[i, j] = 1;
                        }
                    }
                }

            }
 
    }

    }



