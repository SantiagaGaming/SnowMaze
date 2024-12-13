using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [HideInInspector] public bool CanMove = true;

    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rb;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void TryMove(float directionX, float directionY)
    {
        _rb.velocity = new Vector2(directionX * _moveSpeed, directionY * _moveSpeed);
        ShowAnimation();

    }
    private void ShowAnimation()
    {
        if (_rb.velocity.magnitude > 0.1f)
        {
            _player.PlayAnimation(true);
        }
        else
        {
            _player.PlayAnimation(false);
        }
    }

}
