using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBase : MonoBehaviour
{
    [SerializeField]
    Player controllingPlayer;

    [SerializeField]
    Player cubeWanoPlayer;

    [SerializeField]
    int health;

    public UnityEvent OnBallDeposited;

    public UnityEvent OnBaseDamaged;

    public void DamageBase()
    {
        OnBaseDamaged.Invoke();
        health--;
        if (health == 0)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null && player == controllingPlayer && player.HasBall)
        {
            player.HasBall = false;
            player.Lives++;
            OnBallDeposited.Invoke();
            return;
        }

        var ball = other.GetComponent<MovingBall>();
        if (ball != null && ball.LaunchedPlayer != controllingPlayer && ball.LaunchedPlayer != cubeWanoPlayer)
        {
            DamageBase();
            ball.DestroyBall();
        }
    }
}
