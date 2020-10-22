using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    public string TextFormat;
    private TextMeshProUGUI textMeshPro;
    private PlayerEntity player;

    private void Awake()
    {
        TryGetComponent(out textMeshPro);
        player = GameObject.FindObjectOfType<PlayerEntity>();
    }

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        if (textMeshPro == null || player == null) return;
        textMeshPro.SetText(GetFormattedText());
    }

    private string GetFormattedText()
    {
        var txt = TextFormat;
        txt = txt.Replace("%lives%", player.Lives.ToString()).Replace("%retries%", player.Retries.ToString());
        return txt;
    }

    public void UpdateAllTexts()
    {
        var updaters = GameObject.FindObjectsOfType<TextUpdater>();
        for (var i = 0; i < updaters.Length; i++)
        {
            updaters[i].UpdateText();
        }
    }
}
