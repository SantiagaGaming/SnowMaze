using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private Player _player;


  public void OnShowEndText(bool value)
    {
        if(value)
            _gameOverText.GetComponent<Text>().text = Helper.GAME_OVER;
        
        else if(!value)
            _gameOverText.GetComponent<Text>().text = Helper.LEVEL_PASSED;
        
        _gameOverText.SetActive(true);

    }
    private void OnEnable()
    {
        _player.RestartEvent += OnShowEndText;
    }
    private void OnDisable()
    {
        _player.RestartEvent -= OnShowEndText;
    }
}
