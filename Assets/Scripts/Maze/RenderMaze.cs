using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMaze : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _treesPrefubs;
    [SerializeField] private GameObject _finish;
    [SerializeField] private GameObject[] _enemy;

    private Maze _maze;

    private int _xSize;
    private int _ySize;

    private void Start()
    {
        SetMazeSize();
        _maze = new Maze(_xSize, _ySize);
        _maze.GenerateWalls();
        _maze.GeneratePath();
        _maze.GenerateMaze();

        StartRenderMaze();
    }
    private void StartRenderMaze()
    {
        for (int i = 0; i <_xSize ; i++)
        {
            for (int j = 0; j <_ySize; j++)
            {
                if (_maze.GetMaze()[i,j] ==1)
                {
                    BuildObject(_treesPrefubs[Random.Range(0,_treesPrefubs.Length)], new Vector2(transform.position.x + i, transform.position.y - j));
                }
                else if(_maze.GetMaze()[i, j] == 3)
                {
                    SetPlayerPosition(new Vector2(transform.position.x + i, transform.position.y - j));
                }
                else if (_maze.GetMaze()[i, j] == 4)
                {
                    BuildObject(_finish, new Vector2(transform.position.x + i, transform.position.y - j));
                }
                else
                {

                    int rnd = Random.Range(0, GetDifficulty());
                    if(rnd ==1)
                    {
                        BuildObject(_enemy[Random.Range(0, _enemy.Length)], new Vector2(transform.position.x + i, transform.position.y - j));
                    }
                }
            }

            }
        }
    private void BuildObject(GameObject obj, Vector2 position)
    {
        Instantiate(obj, position, Quaternion.identity);
    }
    private void SetPlayerPosition(Vector2 pos)
    {
        _player.transform.position = pos;
    }
    private void SetMazeSize()
    {
  
        if (PlayerPrefs.GetInt(Helper.DIFFICULTY) == 0)
        {
            _xSize = Random.Range(10, 20);
            _ySize = Random.Range(10, 20);
        }
        else if (PlayerPrefs.GetInt(Helper.DIFFICULTY) == 1)
        {
            _xSize = Random.Range(20, 50);
            _ySize = Random.Range(20, 50);
        }
        else if (PlayerPrefs.GetInt(Helper.DIFFICULTY) == 2)
        {
            _xSize = Random.Range(50, 120);
            _ySize = Random.Range(50, 120);
        }

    }
    private int GetDifficulty()
    {
        if (PlayerPrefs.GetInt(Helper.DIFFICULTY) == 0)
        {
            return 30;
        }
        else if (PlayerPrefs.GetInt(Helper.DIFFICULTY) == 1)
        {
            return 20;
        }
        else if (PlayerPrefs.GetInt(Helper.DIFFICULTY) == 2)
        {
            return 10;
        }
        else return 20;

    }
}



