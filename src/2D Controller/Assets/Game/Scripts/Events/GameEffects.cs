using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEffects : MonoBehaviour
{
    public static GameEffects Instance { get; set; }

    [Header("Effects"), Space(2f)]
    public List<PlayerParticles> PlayerEffects;

    void Awake()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
        Instance = this;
    }

    public static void PlayRandomEffectByType(PlayerEffectType effect, Vector2 Position, Action<float> callback = null)
    {
        if (!(GameEffects.Instance is GameEffects instance)) return;
        var prefab = instance.PlayerEffects.Find(x => x.Prefab != null && x.effectType == effect);
        if (prefab == null) return;
        var obj = Instantiate(prefab.Prefab, Position, Quaternion.identity);
        var particle = obj.GetComponent<ParticleSystem>();
        Destroy(obj, particle.main.duration);
        callback?.Invoke(particle.main.duration);
    }
}

public enum PlayerEffectType
{
    Death = 0,
    Damaged = 1
}

[Serializable]
public class PlayerParticles
{
    public string Name;
    public GameObject Prefab;

    public PlayerEffectType effectType;
}