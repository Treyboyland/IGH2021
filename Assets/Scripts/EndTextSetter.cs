using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTextSetter : MonoBehaviour
{
    [SerializeField]
    TMP_Text title;

    [SerializeField]
    TMP_Text message;

    // Start is called before the first frame update
    void Start()
    {
        title.text = EndScenarioManager.Manager.FinalScenario.Title;
        message.text = EndScenarioManager.Manager.FinalScenario.EndText;
    }


}
