using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI optionYes;
    public TextMeshProUGUI optionNo;

    public SelectedOption _selectedOption;
    public SelectedOption selectedOption
    {
        get => _selectedOption;
        set
        {
            ColorUtility.TryParseHtmlString("#8B5179", out Color off);
            ColorUtility.TryParseHtmlString("#EF8BD0", out Color on);

            _selectedOption = value;
            if (value == SelectedOption.Yes)
            {
                optionYes.color = on;
                optionNo.color = off;
            }
            else
            {
                optionNo.color = on;
                optionYes.color = off;
            }
        }
    }

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Option_Yes")?.TryGetComponent(out optionYes);
        GameObject.FindGameObjectWithTag("Option_No")?.TryGetComponent(out optionNo);
    }
    private void OnGUI()
    {
        var e = Event.current;
        if (e.isKey && e.type == EventType.KeyUp)
        {
            if (e.keyCode == KeyCode.A)
            {
                selectedOption = SelectedOption.Yes;
            }
            else if (e.keyCode == KeyCode.D)
            {
                selectedOption = SelectedOption.No;
            }
            else if (e.keyCode == KeyCode.Space)
            {
                if (selectedOption == SelectedOption.Yes)
                    RestartGame();
                else
                    Application.Quit(1);
            }
        }
    }

    private void RestartGame()
    {
        var player = GameObject.FindObjectOfType<PlayerEntity>();
        player.Restart();
    }

    public enum SelectedOption
    {
        Yes,
        No
    }
}
