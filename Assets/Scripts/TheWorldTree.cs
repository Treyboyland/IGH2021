using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorldTree : MonoBehaviour
{
    [SerializeField]
    GameEventSO onTreeFullyGrown;

    [SerializeField]
    GameEventSO onTreeStagedReached;

    [SerializeField]
    List<int> depositsPerStage;

    [SerializeField]
    List<Sprite> sprites;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    float depositsPerMinute;

    [SerializeField]
    Animator finalBlastAnimator;

    int currentNumDeposits;

    int currentStage = 0;

    float additionalDeposits;

    private void Start()
    {
        finalBlastAnimator.gameObject.SetActive(false);
        SetStage();
    }

    public void IncrementDeposits()
    {
        currentNumDeposits++;
        SetStage();
    }

    private void Update()
    {
        additionalDeposits += Time.deltaTime * depositsPerMinute / 60.0f;
        if (additionalDeposits >= 1)
        {
            additionalDeposits -= 1;
            IncrementDeposits();
        }
    }


    void SetStage()
    {
        int newId = 0;
        for (int i = 0; i < depositsPerStage.Count; i++)
        {
            if (depositsPerStage[i] > currentNumDeposits)
            {
                break;
            }
            newId = i;
        }
        if (currentStage != newId)
        {
            onTreeStagedReached.Invoke();
            if (newId == depositsPerStage.Count - 1)
            {
                onTreeFullyGrown.Invoke();
            }
        }

        currentStage = newId;
        SetSprite();
    }

    void SetSprite()
    {
        spriteRenderer.sprite = sprites[currentStage];
    }

    public void ActivateFinalBlast()
    {
        finalBlastAnimator.gameObject.SetActive(true);
    }

    public IEnumerator WaitForFinalBlast()
    {
        while (!finalBlastAnimator.GetCurrentAnimatorStateInfo(0).IsName("Blast Finished"))
        {
            yield return null;
        }
    }
}
