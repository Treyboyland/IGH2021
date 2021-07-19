using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Cubewano : MonoBehaviour
{
    [Serializable]
    public struct AttackPattern
    {
        public int NumAttacks;
        public float SecondsToWait;
    }

    [SerializeField]
    DisableParticleAfterPlay particle;

    [SerializeField]
    Player cubePlayer;

    [SerializeField]
    float secondsToWait;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Animator appearanceAnimator;

    [SerializeField]
    AudioSource appearanceSound;

    [SerializeField]
    AudioSource pulseSound;

    [SerializeField]
    string attackTrigger;

    [SerializeField]
    string normalTrigger;

    [SerializeField]
    BallLauncher launcher;

    [SerializeField]
    AttackPattern endAttack;

    [SerializeField]
    List<AttackPattern> attackPatterns;

    [SerializeField]
    bool isBigMad;

    public bool IsEndGame;

    public bool ShouldWait = true;

    public bool IsEnraged { get { return isBigMad || attackStage == attackPatterns.Count; } }

    public bool IsWaiting = false;

    int attackStage = 0;

    private void Start()
    {
        particle.gameObject.SetActive(false);
        StartCoroutine(AttackLoop());
    }

    IEnumerator WaitToAppear(float secondsToWait)
    {
        bool appeared = false;
        float elapsed = 0;
        while (elapsed < secondsToWait)
        {
            elapsed += Time.deltaTime;
            if (!appeared && (secondsToWait - elapsed < 5) || IsEndGame)
            {
                appearanceSound.Play();
                appeared = true;
                appearanceAnimator.SetTrigger("Appear");
            }
            if (IsEndGame)
            {
                yield break;
            }
            yield return null;
        }

    }

    public IEnumerator WaitForDisappearance()
    {
        Debug.LogWarning(gameObject.name + " Waiting");
        while (!appearanceAnimator.GetCurrentAnimatorStateInfo(0).IsName("Initial"))
        {
            yield return null;
        }
        Debug.LogWarning(gameObject.name + " Wait Done");
    }

    IEnumerator WaitThenDisappear()
    {
        IsWaiting = true;
        while (ShouldWait)
        {
            yield return null;
        }

        yield return new WaitForSeconds(3.0f);
        appearanceAnimator.SetTrigger("Shrink");
        while (!appearanceAnimator.GetCurrentAnimatorStateInfo(0).IsName("Initial"))
        {
            yield return null;
        }
    }

    public IEnumerator WaitUntilCubewanoWaiting()
    {
        while (!IsWaiting)
        {
            yield return null;
        }
    }

    IEnumerator AttackLoop()
    {

        while (true)
        {
            if (isBigMad)
            {
                attackStage = attackPatterns.Count;
            }
            var attack = attackStage < attackPatterns.Count ? attackPatterns[attackStage] : endAttack;
            yield return StartCoroutine(WaitToAppear(attack.SecondsToWait));

            if (IsEndGame)
            {
                yield return new WaitForSeconds(5.0f);
            }

            particle.gameObject.SetActive(true);
            pulseSound.Play();
            animator.SetTrigger(attackTrigger);

            while (particle.gameObject.activeInHierarchy)
            {
                yield return null;
            }

            if (IsEndGame)
            {
                yield return StartCoroutine(WaitThenDisappear());
                yield break;
            }

            var directions = new List<PlayerMovement.PlayerDirection>(){ PlayerMovement.PlayerDirection.NORTH_WEST, PlayerMovement.PlayerDirection.WEST,
            PlayerMovement.PlayerDirection.SOUTH_WEST, PlayerMovement.PlayerDirection.SOUTH, PlayerMovement.PlayerDirection.SOUTH_EAST,
            PlayerMovement.PlayerDirection.EAST, PlayerMovement.PlayerDirection.NORTH_EAST};
            directions.Shuffle();
            int count = 0;
            int index = 0;
            while (count < attack.NumAttacks)
            {
                count++;
                launcher.SpawnBall(directions[index], cubePlayer);
                index = (index + 1) % directions.Count;
                yield return null;
            }
            animator.SetTrigger(normalTrigger);
            if (!IsEnraged)
            {
                yield return new WaitForSeconds(7.0f);
            }

            appearanceAnimator.SetTrigger("Shrink");
            while (!appearanceAnimator.GetCurrentAnimatorStateInfo(0).IsName("Initial"))
            {
                yield return null;
            }
            attackStage = attackStage + 1 <= attackPatterns.Count ? attackStage + 1 : attackPatterns.Count;
        }
    }
}
