using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _easyButton;
    [SerializeField] private Button _normalButton;
    [SerializeField] private Button _hardButton;

    [SerializeField]private MainMenuController _controller;
    private void Start()
    {
        _easyButton.onClick.AddListener(() => _controller.SetDifficultyAndStartGame(0));
        _normalButton.onClick.AddListener(() => _controller.SetDifficultyAndStartGame(1));
        _hardButton.onClick.AddListener(() => _controller.SetDifficultyAndStartGame(2));
    }

}
