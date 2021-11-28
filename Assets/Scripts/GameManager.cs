using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private ExitButton _exitButton;
    [SerializeField] private ScoreViev _scoreViev;

    private int _score;

    private void Start()
    {
        LoadScore();
    
    }
    private void OnEnable()
    {
        _player.RestartEvent += OnRestartLavel;
        _exitButton.ExitMenuTapEvent += OnLoadMenuScene;
    }
    private void OnDisable()
    {
        _player.RestartEvent -= OnRestartLavel;
        _exitButton.ExitMenuTapEvent -= OnLoadMenuScene;
    }
    private void OnRestartLavel(bool value)
    {
        SetScore(value);
        StartCoroutine(Restarter());
    }
    private IEnumerator Restarter()
    {
        yield return new WaitForSeconds(2f);
        _sceneLoader.LoadScene(Helper.GAME_SCENE);
    }
    private void OnLoadMenuScene()
    {
        _sceneLoader.LoadScene(Helper.MENU_SCENE);
    }
    private void LoadScore()
    {
        _score = PlayerPrefs.GetInt(Helper.PLAYER_SCORE);
        _scoreViev.SetScoreText(_score);
    }
    private void SetScore(bool gameOver)
    {
        if(gameOver)
        {
            _score = 0;
            PlayerPrefs.SetInt(Helper.PLAYER_SCORE, _score);
        }
        if(!gameOver)
        {
            _score ++;
            PlayerPrefs.SetInt(Helper.PLAYER_SCORE, _score);
        }
    }

}
