using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EndScenario")]
public class EndScenario : ScriptableObject
{
    [SerializeField]
    string title;

    public string Title { get { return title; } }

    [TextArea(5, 8)]
    [SerializeField]
    string endText;

    public string EndText { get { return endText; } }
}
