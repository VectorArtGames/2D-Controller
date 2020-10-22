using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.Events;

public class PlayerEntity : Entity
{

    [Header("Configuration"), Space(5f)]
    public int DefaultRetries;

    [Header("Important Configuration"), Space(5)]
    public int _retries;
    public int Retries
    {
        get => _retries;
        set
        {
            if (value >= 0)
            {
                _retries = value;
            }
            else
            {
                Lives--;
            }
        }
    }

    public int _lives;
    public int Lives
    {
        get => _lives;
        set
        {
            if (value > 0)
            {
                _lives = value;
                Retries = DefaultRetries;
                OnPermanentKilled?.Invoke();
            }
            else
            {
                OnPermanentKilled?.Invoke();
            }
        }
    }

    [Header("Events"), Space(5f)]
    public UnityEvent onKilled;

    public UnityEvent OnPermanentKilled;

    public UnityEvent OnContinuedPlayed;

    private void Awake()
    {
        Retries = DefaultRetries;
    }

    public void Test()
    {
        TakeDamage(10.0f);
    }

    public override void OnKilled()
    {
        Retries--;
        GameEffects.PlayRandomEffectByType(PlayerEffectType.Death, transform.position);

        if (!(SpawnPoint.Instance is SpawnPoint spawn)) return;
        gameObject.transform.position = spawn.transform.position;

        onKilled?.Invoke();
    }

    public void Restart()
    {
        if (!(SpawnPoint.Instance is SpawnPoint spawn && GameEvent.Instance is GameEvent gEvent)) return;
        gameObject.transform.position = spawn.transform.position;
        if (gameObject.TryGetComponent(out PlayerMovement movement))
            movement.CanMove = false;

        gEvent.RestartGame();
    }

}
