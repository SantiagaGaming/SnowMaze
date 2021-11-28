using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyMover _enemyMover;

    private int _dmg = -1;

    private void Start()
    {
        _enemyMover = GetComponent<EnemyMover>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag ==Helper.TREE_OBJECT || collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            ChangeVector();
        }
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            player.RecountHp(_dmg);
            Destroy(gameObject);
        }
    }
    private void ChangeVector()
    {
        if(_enemyMover._currentVector==Vector2.left)
        {
            _enemyMover._currentVector = Vector2.right;
        }
        else if(_enemyMover._currentVector == Vector2.right)
        {
            _enemyMover._currentVector = Vector2.left;
        }
        else if (_enemyMover._currentVector == Vector2.down)
        {
            _enemyMover._currentVector = Vector2.up;
        }
        else if (_enemyMover._currentVector == Vector2.up)
        {
            _enemyMover._currentVector = Vector2.down;
        }


    }
}
