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
        onKilled?.Invoke();
        GameEffects.PlayRandomEffectByType(PlayerEffectType.Death, transform.position);

        if (!(SpawnPoint.Instance is SpawnPoint spawn)) return;
        gameObject.transform.position = spawn.transform.position;
    }

}