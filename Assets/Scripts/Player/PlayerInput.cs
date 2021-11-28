using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }
    private void Update()
    {
        _mover.TryMove(_joystick.Horizontal, _joystick.Vertical);
    }
}
