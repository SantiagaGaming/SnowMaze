using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [HideInInspector] public Vector2 _currentVector;

    private Rigidbody2D _rb;
    private float _speed;
  
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        SetSpeed();
        SetVector();
    }
    private void Update()
    {
        _rb.velocity = _currentVector * _speed;
    }
    private void SetVector()
    {
        int rnd = Random.Range(0, 2);
        if(rnd ==0)
        {
            _currentVector = Vector2.left;
        }
        else 
        {
            _currentVector = Vector2.down;
        }
    }
    private void SetSpeed()
    {
        _speed = Random.Range(0.2f, 1);
    }

}
