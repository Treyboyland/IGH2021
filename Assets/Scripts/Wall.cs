using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    Vector3Event onBallCollision;

    [SerializeField]
    Vector3Event onWallDestruction;

    [SerializeField]
    bool destructible;

    [SerializeField]
    int maxNumBounces;

    int currentNumBounces = 0;
    private void OnEnable()
    {
        currentNumBounces = 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var ball = other.gameObject.GetComponent<MovingBall>();

        if (ball == null || !ball.gameObject.activeInHierarchy)
        {
            return;
        }


        onBallCollision.Value = other.GetContact(0).point;
        onBallCollision.Invoke();
        currentNumBounces++;
        if (destructible && currentNumBounces == maxNumBounces)
        {
            onWallDestruction.Value = transform.position;
            onWallDestruction.Invoke();
            gameObject.SetActive(false);
        }
    }

}
