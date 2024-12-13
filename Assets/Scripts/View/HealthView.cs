using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image[] _hp;
    [SerializeField] private Sprite _dmgSprite;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.RecountHPEvent += OnRenderHealth;
    }
    private void OnDisable()
    {
        _player.RecountHPEvent -= OnRenderHealth;
    }
    private void OnRenderHealth(int value)=> _hp[value].sprite = _dmgSprite;
}
