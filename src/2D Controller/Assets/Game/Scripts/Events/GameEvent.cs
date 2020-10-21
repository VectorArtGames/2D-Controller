using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public bool HasStarted;

    public GameObject TutorialPanel;
    public GameObject InGamePanel;
    public GameObject GameOverPanel;

    public List<TutorialKeys> tutorialKeys = new List<TutorialKeys>();

    void Awake()
    {
        if (TutorialPanel == null || InGamePanel == null || GameOverPanel == null)
        {
            Debug.LogError("[-] GameEvent.cs:60\nOne of the panels does not exist");
            return;
        }
        TutorialPanel.SetActive(true);
        InGamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    void OnGUI()
    {
        if (HasStarted) return;

        Event e = Event.current;
        if (e.isKey && e.type == EventType.KeyDown)
        {
            var key = tutorialKeys.Find(x => x.key == e.keyCode);
            if (key == null) return;
            key.Clicked = true;

            if (tutorialKeys.TrueForAll(x => x.Clicked))
            {
                if (TutorialPanel == null || InGamePanel == null)
                {
                    Debug.LogError("[-] GameEvent.cs:33\nOne of the panels does not exist");
                    return;
                }

                TutorialPanel.SetActive(false);
                InGamePanel.SetActive(true);

                var players = GameObject.FindObjectsOfType<PlayerMovement>();
                foreach (var p in players)
                    p.CanMove = true;

                HasStarted = true;

                Debug.Log("[+] Game Starting ..");
            }
        }
    }

    public void ActivateGameOverPanel()
    {
        if (TutorialPanel == null || InGamePanel == null || GameOverPanel == null)
        {
            Debug.LogError("[-] GameEvent.cs:60\nOne of the panels does not exist");
            return;
        }
        TutorialPanel.SetActive(false);
        InGamePanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }
}

[Serializable]
public class TutorialKeys
{
    public KeyCode key;
    public GameObject obj;

    private bool _clicked;
    public bool Clicked
    {
        get => _clicked;
        set
        {
            _clicked = value;

            if (obj != null)
                obj.SetActive(!value);
        }
    }
}