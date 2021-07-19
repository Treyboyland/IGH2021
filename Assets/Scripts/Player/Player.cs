using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerEvent onPlayerDeath;

    [SerializeField]
    GameEventGenericSO<int> onScoreChanged;

    [SerializeField]
    GameEventSO onRunUpdate;

    [Tooltip("Player's current points")]
    [SerializeField]
    int score;

    [Tooltip("True if the player cannot take damage")]
    [SerializeField]
    bool isInvincible;
    public bool IsInvincible { get { return isInvincible; } set { isInvincible = value; } }

    /// <summary>
    /// Player's current points
    /// </summary>
    /// <value></value>
    public int Score { get { return score; } set { score = value; onScoreChanged.Value = score; onScoreChanged.Invoke(); } }

    [SerializeField]
    GameEventGenericSO<int> onLivesChanged;

    [SerializeField]
    Vector3Event onPlayerDamaged;

    [SerializeField]
    GameEventSO onPlayerGainedLife;

    [Tooltip("Number of lives the player has")]
    [SerializeField]
    int lives;

    [Tooltip("Max Number of lives able to be obtained")]
    [SerializeField]
    int maxLives;

    /// <summary>
    /// Number of lives the player has
    /// </summary>
    /// <value></value>
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value > maxLives)
            {
                value = maxLives;
            }
            if (lives < value)
            {
                onPlayerGainedLife.Invoke();
            }
            else if (lives > value)
            {
                onPlayerDamaged.Value = transform.position;
                onPlayerDamaged.Invoke();
            }
            lives = value;
            onLivesChanged.Value = lives;
            onLivesChanged.Invoke();
            onRunUpdate.Invoke();
        }
    }

    [Tooltip("True if the player has the ball")]
    [SerializeField]
    bool hasBall;

    /// <summary>
    /// True if the player has the ball
    /// </summary>
    /// <value></value>
    public bool HasBall
    {
        get { return hasBall; }
        set
        {
            hasBall = value;
            if (hasBall)
            {
                OnConsumeBall.Invoke();
            }
        }
    }

    [SerializeField]
    Rigidbody2D body;

    public Rigidbody2D Body { get { return body; } }

    public UnityEvent OnConsumeBall;

    public void DamagePlayer()
    {
        if (isInvincible)
        {
            return;
        }
        Lives--;
        if (lives <= 0)
        {
            onPlayerDeath.Value = this;
            onPlayerDeath.Invoke();
            gameObject.SetActive(false);
        }
    }
}
