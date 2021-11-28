using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public UnityAction ExitMenuTapEvent;

    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _exitButton.onClick.AddListener(ExitButtonTap);
    }
    private void ExitButtonTap()
    {
        ExitMenuTapEvent.Invoke();
    }
}
