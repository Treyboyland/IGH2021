using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    [SerializeField]
    Player player1;

    [SerializeField]
    Player player2;

    [SerializeField]
    Cubewano cubewano;

    [SerializeField]
    EndScenario player1Wins;

    [SerializeField]
    EndScenario player2Wins;

    [SerializeField]
    EndScenario cubewanoWins;

    [SerializeField]
    EndScenario bothDeath;

    [SerializeField]
    EndScenario theGoodEnding;

    [SerializeField]
    SceneLoader loader;

    [SerializeField]
    TheWorldTree finalTree;

    bool isLoading = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void HandlePlayerDeath(Player deadPlayer)
    {
        StartCoroutine(HandleDeath(deadPlayer));
    }

    IEnumerator HandleDeath(Player deadPlayer)
    {
        if (isLoading)
        {
            yield break;
        }
        yield return null;
        if (cubewano.IsEnraged)
        {
            if (!player1.gameObject.activeInHierarchy && !player2.gameObject.activeInHierarchy)
            {
                EndScenarioManager.Manager.FinalScenario = cubewanoWins;
                StartCoroutine(WaitThenLaunchEnd());
            }
        }
        else if (!player1.gameObject.activeInHierarchy && !player2.gameObject.activeInHierarchy)
        {
            EndScenarioManager.Manager.FinalScenario = bothDeath;
            StartCoroutine(WaitThenLaunchEnd());
        }
        else if (deadPlayer == player1)
        {
            player2.IsInvincible = true;
            EndScenarioManager.Manager.FinalScenario = player2Wins;
            StartCoroutine(WaitThenLaunchEnd());
        }
        else if (deadPlayer == player2)
        {
            player1.IsInvincible = true;
            EndScenarioManager.Manager.FinalScenario = player1Wins;
            StartCoroutine(WaitThenLaunchEnd());
        }
    }

    public void HandleTreeGrowth()
    {
        EndScenarioManager.Manager.FinalScenario = theGoodEnding;
        StartCoroutine(DoTreeCutScene());
    }


    IEnumerator WaitThenLaunchEnd()
    {
        yield return new WaitForSeconds(3.0f);
        loader.LoadScene();
    }

    IEnumerator DoTreeCutScene()
    {
        cubewano.ShouldWait = true;
        cubewano.IsEndGame = true;
        yield return StartCoroutine(cubewano.WaitUntilCubewanoWaiting());

        finalTree.ActivateFinalBlast();
        yield return StartCoroutine(finalTree.WaitForFinalBlast());
        cubewano.ShouldWait = false;
        yield return StartCoroutine(cubewano.WaitForDisappearance());
        StartCoroutine(WaitThenLaunchEnd());
    }
}
