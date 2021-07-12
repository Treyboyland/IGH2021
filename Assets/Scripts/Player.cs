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
    [Tooltip("True if the player has the ball")]
    [SerializeField]
    bool hasBall;

    /// <summary>
    /// True if the player has the ball
    /// </summary>
    /// <value></value>
    public bool HasBall { get { return hasBall; } set { hasBall = value; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
