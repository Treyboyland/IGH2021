using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField]
    int numTaps;

    int count;

    [SerializeField]
    GameEventSO onMakeSound;

    [SerializeField]
    EndScenario easterEgg;

    [SerializeField]
    SceneLoader endScene;

    public void IncreaseCount()
    {
        count++;
        onMakeSound.Invoke();
        if (count >= numTaps)
        {
            EndScenarioManager.Manager.FinalScenario = easterEgg;
            endScene.LoadScene();
        }
    }
}
