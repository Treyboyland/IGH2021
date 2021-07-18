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



    int attackIndex = 0;

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
            if (!appeared && secondsToWait - elapsed < 5)
            {
                appearanceSound.Play();
                appeared = true;
                appearanceAnimator.SetTrigger("Appear");
            }
            yield return null;
        }

    }

    IEnumerator AttackLoop()
    {
        int attackStage = 0;
        while (true)
        {
            var attack = attackStage < attackPatterns.Count ? attackPatterns[attackStage] : endAttack;
            yield return StartCoroutine(WaitToAppear(attack.SecondsToWait));
            particle.gameObject.SetActive(true);
            pulseSound.Play();
            animator.SetTrigger(attackTrigger);

            while (particle.gameObject.activeInHierarchy)
            {
                yield return null;
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
            yield return new WaitForSeconds(7.0f);
            appearanceAnimator.SetTrigger("Shrink");
            while (appearanceAnimator.GetCurrentAnimatorStateInfo(0).IsName("Initial"))
            {
                yield return null;
            }
            attackStage++;
        }
    }
}
