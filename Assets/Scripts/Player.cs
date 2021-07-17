using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameEventGenericSO<int> onScoreChanged;

    [Tooltip("Player's current points")]
    [SerializeField]
    int score;

    /// <summary>
    /// Player's current points
    /// </summary>
    /// <value></value>
    public int Score { get { return score; } set { score = value; onScoreChanged.Value = score; onScoreChanged.Invoke(); } }

    [SerializeField]
    GameEventGenericSO<int> onLivesChanged;

    [SerializeField]
    GameEventSO onPlayerDamaged;

    [SerializeField]
    GameEventSO onPlayerGainedLife;

    [Tooltip("Number of lives the player has")]
    [SerializeField]
    int lives;

    /// <summary>
    /// Number of lives the player has
    /// </summary>
    /// <value></value>
    public int Lives
    {
        get { return lives; }
        set
        {
            if (lives < value)
            {
                onPlayerGainedLife.Invoke();
            }
            else if (lives > value)
            {
                onPlayerDamaged.Invoke();
            }
            lives = value;
            onLivesChanged.Value = lives;
            onLivesChanged.Invoke();
        }
    }

    [Tooltip("True if the player has the ball")]
    [SerializeField]
    bool hasBall;

    /// <summary>
    /// True if the player has the ball
    /// </summary>
    /// <value></value>
    public bool HasBall { get { return hasBall; } set { hasBall = value; } }

    [SerializeField]
    Rigidbody2D body;

    public Rigidbody2D Body { get { return body; } }

    public void DamagePlayer()
    {
        Lives--;
        if (lives == 0)
        {

        }
    }
}
