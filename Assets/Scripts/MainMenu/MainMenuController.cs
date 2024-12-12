using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;

public void SetDifficultyAndStartGame(int value)
    {
        PlayerPrefs.SetInt(Helper.DIFFICULTY, value);
        PlayerPrefs.SetInt(Helper.PLAYER_SCORE, 0);
        StartGame();

    }
    private void StartGame()=> _sceneLoader.LoadScene(Helper.GAME_SCENE);
}
